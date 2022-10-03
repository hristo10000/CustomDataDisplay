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
        readonly string applicationId = "a52e0aef-82df-4a0d-bdb2-3523c8c35aea";
        readonly string key = "aj5xbtiii1ejyszyftbie3xzss2ogto82bs8jj1d";

        [Obsolete]
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _ = new TelemetryClient(new Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration() { InstrumentationKey = "e4259d2b-709c-4167-8900-71dd5c51a453" })
            {
                InstrumentationKey = "e4259d2b-709c-4167-8900-71dd5c51a453"
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
        public async Task<IActionResult> Search([FromBody] SearchModel model)
        {
            var time = model.Time;
            string date = "customDimensions.Date";
            List<SearchField> fields = model.Fields;
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

            if (time.Value == "30 minutes ago")
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
            }
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
