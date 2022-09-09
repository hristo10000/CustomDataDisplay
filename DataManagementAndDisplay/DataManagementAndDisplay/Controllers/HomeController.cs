using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using DataManagementAndDisplay.Models;
using Microsoft.Azure.ApplicationInsights.Query;
using System.Threading;

namespace DataManagementAndDisplay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var ai = new TelemetryClient(new Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration() { InstrumentationKey = "e4259d2b-709c-4167-8900-71dd5c51a453" })
            {
                InstrumentationKey = "e4259d2b-709c-4167-8900-71dd5c51a453"
            };

            string applicationId = "a52e0aef-82df-4a0d-bdb2-3523c8c35aea";
            string key = "aj5xbtiii1ejyszyftbie3xzss2ogto82bs8jj1d";
            var credentials = new ApiKeyClientCredentials(key);
            var applicationInsightsClient = new ApplicationInsightsDataClient(credentials);
            var query = "customEvents " +
                "| where timestamp > ago(8h) " +
                "| extend Date = customDimensions.Date, " +
                "User = customDimensions.User, " +
                "Result = customDimensions.Result, " +
                "Operation = customDimensions.Operation, " +
                "Guid = customDimensions.Guid";
            var response =  await applicationInsightsClient.Query.ExecuteWithHttpMessagesAsync(applicationId, query);
            return View(response.Body.Results);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}