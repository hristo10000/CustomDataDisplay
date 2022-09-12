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
            var credentials = new ApiKeyClientCredentials(key);
            var applicationInsightsClient = new ApplicationInsightsDataClient(credentials);
            var query = "customEvents " +
                "| where timestamp > ago(5h) " +
                "| project Date = customDimensions.Date, " +
                "User = customDimensions.User, " +
                "Result = customDimensions.Result, " +
                "Operation = customDimensions.Operation, " +
                "Guid = customDimensions.Guid";
            var response =  await applicationInsightsClient.Query.ExecuteWithHttpMessagesAsync(applicationId, query);
            IEnumerable<IDictionary<string, object>> data = response.Body.Results;
            return View(new MultipleModels(data, new SearchModel { Time = "", User = "", Operation = "", Result = "", Guid = "" } ));
        }

       /* public IActionResult Search()
        {
           // return View(new MultipleModels ( ));
        }*/
        public async Task<IActionResult> SearchResult(IFormCollection collection)
        {
            string yesterday = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day - 1}";
            var credentials = new ApiKeyClientCredentials(key);
            var applicationInsightsClient = new ApplicationInsightsDataClient(credentials);
            var user = Convert.ToString(collection["searchModel.User"]);
            string operation = Convert.ToString(collection["searchModel.Operation"]);
            string result = Convert.ToString(collection["searchModel.Result"]);
            string time = Convert.ToString(collection["searchModel.Time"]);
            string guid = Convert.ToString(collection["searchModel.Guid"]);
            var query = "customEvents " +
               "| where timestamp > ago(5h) ";
            if (user != "")
            {
                query +=
               $"| where customDimensions.User == '{user}' ";
            }
            if (result != "")
            {
                query +=
               $"| where customDimensions.Result == '{result}' ";
            }
            if ( operation != "")
            {
                query +=
               $"| where customDimensions.Operation == '{operation}' ";
            }
            if (guid != "")
            {
                query +=
               $"| where customDimensions.Guid == '{guid}' ";
            }
            if ( time == "30 minutes ago")
            {
                query +=
              $"| where todatetime(customDimensions.Date) > datetime({yesterday} 23:29:59.0)";
            }
            else if (time == "1 hour ago")
            {
                query +=
              $"| where todatetime(customDimensions.Date) > datetime({yesterday} 22:59:59.0)";
            }
            else if (time == "3 hours ago")
            {
                query +=
              $"| where todatetime(customDimensions.Date) > datetime({yesterday} 20:59:59.0)";
            }
            else if (time == "8 hours ago")
            {
                query +=
              $"| where todatetime(customDimensions.Date) > datetime({yesterday} 15:59:59.0)";
            }
            else if (time == "12 hours ago")
            {
                query +=
              $"| where todatetime(customDimensions.Date) > datetime({yesterday} 11:59:59.0)";
            }
            else if (time == "12 hours ago")
            {
                query +=
              $"| where todatetime(customDimensions.Date) >= datetime({yesterday} 00:00:00.0)";
            }
            query += "| project Date = customDimensions.Date, " +
               "User = customDimensions.User, " +
               "Result = customDimensions.Result, " +
               "Operation = customDimensions.Operation, " +
               "Guid = customDimensions.Guid";
            var response = await applicationInsightsClient.Query.ExecuteWithHttpMessagesAsync(applicationId, query);
            IEnumerable<IDictionary<string, object>> data = response.Body.Results;
            return View("Index",new MultipleModels(data));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}