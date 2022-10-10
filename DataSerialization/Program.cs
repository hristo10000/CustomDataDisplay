using DataModel;
using System;
using System.IO;
using System.Xml.Serialization;

namespace SerilisationLearning
{
    class Program
    {
        public static void Main(string[] args)
        {
            Model model = new();
            model.fields.Add(new Field
            {
                DisplayName = "Date",
                InternalName = "customDimensions.Date",
                FieldType = FieldType.String
            });
            model.fields.Add(new Field { 
                DisplayName = "User", 
                InternalName = "customDimensions.User", 
                FieldType = FieldType.String 
            });
            model.fields.Add(new Field
            {
                DisplayName = "Result",
                InternalName = "customDimensions.Result",
                FieldType = FieldType.String
            });
            model.fields.Add(new Field
            {
                DisplayName = "Operation",
                InternalName = "customDimensions.Operation",
                FieldType = FieldType.String
            });
            model.fields.Add(new Field
            {
                DisplayName = "Guid",
                InternalName = "customDimensions.Guid",
                FieldType = FieldType.String
            });
            model.timeField = new Field
            {
                DisplayName = "DateOfAdding",
                InternalName = "timestamp",
                FieldType = FieldType.DateTime
            };
            model.timestamps.Add(new TimeFieldOption
            {
                InternalName = "30m",
                DisplayName = "30 minutes ago"
            }) ;
            model.timestamps.Add(new TimeFieldOption
            {
                InternalName = "1h",
                DisplayName = "1 hour ago"
            });
            model.timestamps.Add(new TimeFieldOption
            {
                InternalName = "3h",
                DisplayName = "3 hours ago"
            });
            model.timestamps.Add(new TimeFieldOption
            {
                InternalName = "8h",
                DisplayName = "8 hours ago"
            });
            model.timestamps.Add(new TimeFieldOption
            {
                InternalName = "12h",
                DisplayName = "12 hours ago"
            });
            model.timestamps.Add(new TimeFieldOption
            {
                InternalName = "1d",
                DisplayName = "24 hours ago"
            });
            XmlSerializer serializer = new(typeof(Model));
            var path = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            path = path.Parent.Parent.Parent.Parent;
            string filePath = Path.Combine(path.ToString(), "DataManagementAndDisplay", "DataManagementAndDisplay", "Model.xml");
            using TextWriter writer = new StreamWriter(filePath.ToString());
            serializer.Serialize(writer, model);
        }
    }
}
