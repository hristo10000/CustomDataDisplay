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
                "| where timestamp > ago(8h) " +
                "| project Date = customDimensions.Date, " +
                "User = customDimensions.User, " +
                "Result = customDimensions.Result, " +
                "Operation = customDimensions.Operation, " +
                "Guid = customDimensions.Guid";
            var response =  await applicationInsightsClient.Query.ExecuteWithHttpMessagesAsync(applicationId, query);
            IEnumerable<IDictionary<string, object>> data = response.Body.Results;
            return View(data);
        }

        public IActionResult Search()
        {
            return View(new SearchModel { Time = "", User = "", Operation = "", Result = "" });
        }
        public async Task<IActionResult> SearchResult(IFormCollection collection)
        {
            var credentials = new ApiKeyClientCredentials(key);
            var applicationInsightsClient = new ApplicationInsightsDataClient(credentials);
            var user = Convert.ToString(collection["User"]);
            string operation = Convert.ToString(collection["Operation"]);
            string result = Convert.ToString(collection["Result"]);
            string time = Convert.ToString(collection["Time"]);
            var query = "customEvents " +
               "| where timestamp > ago(8h) ";
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
            query += "| project Date = customDimensions.Date, " +
               "User = customDimensions.User, " +
               "Result = customDimensions.Result, " +
               "Operation = customDimensions.Operation, " +
               "Guid = customDimensions.Guid";
            var response = await applicationInsightsClient.Query.ExecuteWithHttpMessagesAsync(applicationId, query);
            IEnumerable<IDictionary<string, object>> data = response.Body.Results;
            return View("Index",data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}