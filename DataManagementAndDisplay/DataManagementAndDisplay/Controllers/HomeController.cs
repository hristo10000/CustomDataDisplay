using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using DataManagementAndDisplay.Models;
using Microsoft.Azure.ApplicationInsights.Query;
using Microsoft.AspNetCore.Http;
using DataModel;
using System.Text;
using System.Web.Helpers;
using System.Web;
using System.Text.Json;
using System.Linq;
using Newtonsoft.Json;

namespace Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly string applicationId = "e2f68eac-26bf-4a8a-b0b8-e486fa6c4084";
        readonly string key = "iav7mz1i7cjiir2pcazxmw3pz54o3ks3c03cq1c0";

        [Obsolete]
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _ = new TelemetryClient(new Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration() { InstrumentationKey = "93282e89-6ef0-4513-b4a4-d5f07c63ac2e" })
            {
                InstrumentationKey = "93282e89-6ef0-4513-b4a4-d5f07c63ac2e"
            };
        }

        public async Task<IActionResult> Index()
        {

            Model model = ModelReader.GetModel();
/*            List<Field> fields = model.fields;
            StringBuilder sb = new("customEvents");
            var credentials = new ApiKeyClientCredentials(key);
            var applicationInsightsClient = new ApplicationInsightsDataClient(credentials);
            sb.Append($"| where {model.timeField.InternalName} > ago(24h) | project ");
            foreach (var field in fields)
            {
                sb.Append($"{ field.DisplayName} = { field.InternalName},");
            }
            var query = sb.ToString().Trim(',');
            var response = await applicationInsightsClient.Query.ExecuteWithHttpMessagesAsync(applicationId, query);*/
            return View(model);
        }

        [HttpPost]
        [Route("~/Search")]
        public async Task<IActionResult> Search([FromBody] SearchModel searchModel)
        {
            Model model = ModelReader.GetModel();
            var time = searchModel.Time;
            string date = "customDimensions.Date";
            List<SearchField> fields = searchModel.Fields;
            StringBuilder sb = new();
            string yesterday = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day - 1}";
            var credentials = new ApiKeyClientCredentials(key);
            var applicationInsightsClient = new ApplicationInsightsDataClient(credentials);
            sb.Append($"customEvents | where {time.InternalName} > ago(24h) ");
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].Value != "")
                {
                    sb.Append($"| where {fields[i].InternalName} == '{fields[i].Value}' ");
                }
            }
            for (int i = 0; i < model.timestamps.Count; i++)
            {
                if (time.Value == model.timestamps[i].InternalName)
                {
                    sb.Append(
                   $"| where todatetime({date}) > ago({model.timestamps[i].InternalName})");
                }
            }
           /* if (time.Value == "30 minutes ago")
            {
                sb.Append(
               $"| where todatetime({date}) > datetime({yesterday} 23:29:59.0)");
            }
            else if (time.Value == "1 hour ago")
            {
                sb.Append(
              $"| where todatetime({date}) > datetime({yesterday} 22:59:59.0)");
            }
            else if (time.Value == "3 hours ago")
            {
                sb.Append(
              $"| where todatetime({date}) > datetime({yesterday} 20:59:59.0)");
            }
            else if (time.Value == "8 hours ago")
            {
                sb.Append(
              $"| where todatetime({date}) > datetime({yesterday} 15:59:59.0)");
            }
            else if (time.Value == "12 hours ago")
            {
                sb.Append(
              $"| where todatetime({date}) > datetime({yesterday} 11:59:59.0)");
            }
            else if (time.Value == "24 hours ago")
            {
                sb.Append(
              $"| where todatetime({date}) >= datetime({yesterday} 00:00:00.0)");
            }*/
            sb.Append("| project ");
            foreach (var field in fields)
            {
                sb.Append($"{ field.InternalName},");
            }
            sb.Append($"{date}");
            var query = sb.ToString().Trim(',');
            var response = await applicationInsightsClient.Query.ExecuteWithHttpMessagesAsync(applicationId, query);
            IEnumerable<IDictionary<string, object>> data = response.Body.Results;
            return Json(data);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
