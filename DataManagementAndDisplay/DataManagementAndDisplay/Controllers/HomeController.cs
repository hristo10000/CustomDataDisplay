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
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration config;
        readonly string applicationId;
        readonly string key;
        

        [Obsolete]
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            config = configuration;
            applicationId = config.GetSection("ApplicationId").Value;
            key = config.GetSection("APIKey").Value;
            _ = new TelemetryClient(new Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration() { InstrumentationKey = config.GetSection("InstrumentationKey").Value })
            {
                InstrumentationKey = config.GetSection("InstrumentationKey").Value
            };
            var storageAccount = CloudStorageAccount.Parse(config.GetSection("StorageAccountInformation").Value);
            var tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            var table = tableClient.GetTableReference("Models");
            table.CreateIfNotExistsAsync();
        }
        public static async Task<TableResult> InsertTableEntity(CloudTable p_tbl, string name, string description, string xmlString, string key)
        {
            ResultModel resultModel = new(key, description, xmlString ,name);
            TableOperation operation = TableOperation.Retrieve<ResultModel>(resultModel.PartitionKey, resultModel.RowKey);
            TableResult result = p_tbl.Execute(operation);
            ResultModel model = result.Result as ResultModel;
            if (model == null)
            {
                TableOperation insertOperation = TableOperation.InsertOrReplace(resultModel);
                return await p_tbl.ExecuteAsync(insertOperation);
            }
            return null;
        }
        public async Task<IActionResult> Index()
        {
            var storageAccount = CloudStorageAccount.Parse(config.GetSection("StorageAccountInformation").Value);
            var tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            var table = tableClient.GetTableReference("Models");
            await table.CreateIfNotExistsAsync();
            await InsertTableEntity(table, "Default_Model", "This is the default model, which is displayed when the application is first opened.", System.IO.File.ReadAllText("Model.xml"), "Default Model");
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
            var query = sb.ToString().Trim(',');
            var response = await applicationInsightsClient.Query.ExecuteWithHttpMessagesAsync(applicationId, query);
            IEnumerable<IDictionary<string, object>> data = response.Body.Results;
            return Json(data);

        }

        [HttpGet]
        [Route("~/Models")]
        public List<ResultModel> GetAllModels()
        {
            var storageAccount = CloudStorageAccount.Parse(config.GetSection("StorageAccountInformation").Value);
            var tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            var table = tableClient.GetTableReference("Models");
            var entities = table.ExecuteQuery(new TableQuery<ResultModel>()).ToList();
            return entities;
        }

        [HttpPost]
        [Route("~/CreateModel")]
        public async Task<IActionResult> Create([FromBody] Model Model)
        {
            var stringwriter = new StringWriter();
            var serializer = new XmlSerializer(typeof(Model));
            serializer.Serialize(stringwriter, Model);
            string xmlStringOfTheModel = stringwriter.ToString();
            var storageAccount = CloudStorageAccount.Parse(config.GetSection("StorageAccountInformation").Value);
            var tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            var table = tableClient.GetTableReference("Models");
            await InsertTableEntity(table, Model.Name, Model.Description, xmlStringOfTheModel, Model.Name);
            return Json(Model);
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
