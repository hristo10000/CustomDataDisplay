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

        [Route("~/Search")]
        public IActionResult Search(SearchModel model)
        {
            SearchModel m = new SearchModel();
            m.Time = new SearchField()
            {
                InternalName = "time",
                Value = "3d"
            };
            m.Fields.Add(new SearchField()
            {
                InternalName = "name",
                Value = "Ime"
            });
            m.Fields.Add(new SearchField()
            {
                InternalName = "age",
                Value = "15"
            });
            var a = JsonConvert.SerializeObject(m, Formatting.Indented);
            var queryString = this.Request.QueryString.ToString();
            
            /*Model model = ModelReader.GetModel();
            var userInput = collection["searchModel.Fields"];
            var time = collection["searchModel.Time"];
            List<Field> fields = model.fields;
            StringBuilder sb = new();
            string yesterday = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day - 1}";
            var credentials = new ApiKeyClientCredentials(key);
            var applicationInsightsClient = new ApplicationInsightsDataClient(credentials);
            List<string> info = new();
            foreach (var item in userInput)
            {
                info.Add(item.ToString());
            }
            info.RemoveAt(info.Count - 1);
            sb.Append($"customEvents | where {model.timeField.InternalName} > ago(24h) ");
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i] != "")
                {
                    sb.Append($"| where {fields[i + 1].InternalName} == '{info[i]}' ");
                }
            }

            if (time == "30 minutes ago")
            {
                sb.Append(
               $"| where todatetime({fields[0].InternalName}) > datetime({yesterday} 23:29:59.0)");
            }
            else if (time == "1 hour ago")
            {
                sb.Append(
              $"| where todatetime({fields[0].InternalName}) > datetime({yesterday} 22:59:59.0)");
            }
            else if (time == "3 hours ago")
            {
                sb.Append(
              $"| where todatetime({fields[0].InternalName}) > datetime({yesterday} 20:59:59.0)");
            }
            else if (time == "8 hours ago")
            {
                sb.Append(
              $"| where todatetime({fields[0].InternalName}) > datetime({yesterday} 15:59:59.0)");
            }
            else if (time == "12 hours ago")
            {
                sb.Append(
              $"| where todatetime({fields[0].InternalName}) > datetime({yesterday} 11:59:59.0)");
            }
            else if (time == "24 hours ago")
            {
                sb.Append(
              $"| where todatetime({fields[0].InternalName}) >= datetime({yesterday} 00:00:00.0)");
            }
            sb.Append("| project ");
            foreach (var field in fields)
            {
                sb.Append($"{ field.DisplayName} = { field.InternalName},");
            }
            var query = sb.ToString().Trim(',');
            var response = await applicationInsightsClient.Query.ExecuteWithHttpMessagesAsync(applicationId, query);
            IEnumerable<IDictionary<string, object>> data = response.Body.Results;
            List<string> newList = new();
            foreach(var item in userInput)
            {
                newList.Add(item);
            }*/
            return Json("1"/*data*/);
            // return View("Index", new MultipleModels(data, model, new SearchModel {Time = time, Fields = newList, IsFirstLoad = false }));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
