using DataManagementAndDisplay.Helpers;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;

namespace DataManagementAndDisplay.Models
{
    public class ResultModel : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        DateTimeOffset ITableEntity.Timestamp { get; set; }
        string ITableEntity.ETag { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string XmlModel { get; set; }

        void ITableEntity.ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            TableEntityHelper.ReadEntity(this, properties, operationContext);
        }

        public IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            var result = TableEntityHelper.WriteEntity(this, operationContext);
            return result;
        }
    }
}
