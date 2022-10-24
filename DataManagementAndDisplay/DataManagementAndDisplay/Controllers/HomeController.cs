﻿using Microsoft.ApplicationInsights;
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
using Microsoft.Azure.Cosmos.Table;

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
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=modelsfortable;AccountKey=TD0YnwTxnH514xOZzMX/2ZQXeE/u80esrCMvdg/sx33iKoNiJ9/aXk/I0caswc2pb5mlJYAr1Xot+ASt/UZGAQ==;EndpointSuffix=core.windows.net");
            var tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            var table = tableClient.GetTableReference("Models");
            table.CreateIfNotExistsAsync();
            var a =InsertTableEntity(table);
        }
        public static async Task<TableResult> InsertTableEntity(CloudTable p_tbl)
        {
            ResultModel resultModel = new ResultModel() {
                Name = "Default Model",
                Description = "This is the default model, which is displayed when the application is first opened.",
                XmlModel = System.IO.File.ReadAllText("Model.xml")
            };
            TableOperation insertOperation = TableOperation.InsertOrMerge((ITableEntity)resultModel);
            return await p_tbl.ExecuteAsync(insertOperation);

        }
        public async Task<IActionResult> Index()
        {
            Model model = ModelReader.GetModel();
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
            sb.Append("| project ");
            foreach (var field in fields)
            {
                sb.Append($"{ field.InternalName},");
            }
            sb.Append($"{date}");
            /*sb.Append(
                   $"| sort by {date} desc");*/
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
