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

namespace Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string applicationId = "a52e0aef-82df-4a0d-bdb2-3523c8c35aea";
        string key = "aj5xbtiii1ejyszyftbie3xzss2ogto82bs8jj1d";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            var ai = new TelemetryClient(new Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration() { InstrumentationKey = "e4259d2b-709c-4167-8900-71dd5c51a453" })
            {
                InstrumentationKey = "e4259d2b-709c-4167-8900-71dd5c51a453"
            };
        }

        public async Task<IActionResult> Index()
        {

            Model model = ModelReader.GetModel();
            List<Field> fields = model.fields;
            StringBuilder sb = new StringBuilder("customEvents");
            var credentials = new ApiKeyClientCredentials(key);
            var applicationInsightsClient = new ApplicationInsightsDataClient(credentials);
            sb.Append($"| where {model.timeField.InternalName} > ago(24h) | project ");
            foreach (var field in fields)
            {
                sb.Append($"{ field.DisplayName} = { field.InternalName},");
            }
            var query = sb.ToString().Trim(',');
            var response = await applicationInsightsClient.Query.ExecuteWithHttpMessagesAsync(applicationId, query);
            IEnumerable<IDictionary<string, object>> data = response.Body.Results;
            return View(new MultipleModels(data, new SearchModel { Time = "", User = "", Operation = "", Result = "", Guid = "" }));
        }

        public async Task<IActionResult> SearchResult(IFormCollection collection)
        {
            Model model = ModelReader.GetModel();
            List<Field> fields = model.fields;
            StringBuilder sb = new StringBuilder();
            string yesterday = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day - 1}";
            var credentials = new ApiKeyClientCredentials(key);
            var applicationInsightsClient = new ApplicationInsightsDataClient(credentials);
            List<string> info = new();
            foreach (var item in collection)
            {
                info.Add(item.Value);
            }
            info.RemoveAt(info.Count - 1);
            sb.Append($"customEvents | where {model.timeField.InternalName} > ago(24h) ");
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i].Contains("ago"))
                {
                    if (info[i] == "30 minutes ago")
                    {
                        sb.Append(
                       $"| where todatetime({fields[0].InternalName}) > datetime({yesterday} 23:29:59.0)");
                    }
                    else if (info[i] == "1 hour ago")
                    {
                        sb.Append(
                      $"| where todatetime({fields[0].InternalName}) > datetime({yesterday} 22:59:59.0)");
                    }
                    else if (info[i] == "3 hours ago")
                    {
                        sb.Append(
                      $"| where todatetime({fields[0].InternalName}) > datetime({yesterday} 20:59:59.0)");
                    }
                    else if (info[i] == "8 hours ago")
                    {
                        sb.Append(
                      $"| where todatetime({fields[0].InternalName}) > datetime({yesterday} 15:59:59.0)");
                    }
                    else if (info[i] == "12 hours ago")
                    {
                        sb.Append(
                      $"| where todatetime({fields[0].InternalName}) > datetime({yesterday} 11:59:59.0)");
                    }
                    else if (info[i] == "24 hours ago")
                    {
                        sb.Append(
                      $"| where todatetime({fields[0].InternalName}) >= datetime({yesterday} 00:00:00.0)");
                    }
                }
                else if (info[i] != "")
                {
                    sb.Append($"| where {fields[i].InternalName} == '{info[i]}' ");
                }
            }
            sb.Append("| project ");
            foreach (var field in fields)
            {
                sb.Append($"{ field.DisplayName} = { field.InternalName},");
            }
            var query = sb.ToString().Trim(',');
            var response = await applicationInsightsClient.Query.ExecuteWithHttpMessagesAsync(applicationId, query);
            IEnumerable<IDictionary<string, object>> data = response.Body.Results;
            return View("Index", new MultipleModels(data, new SearchModel { Time = info[0], User = info[1], Operation = info[2], Result = info[3], Guid = info[4] }));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}