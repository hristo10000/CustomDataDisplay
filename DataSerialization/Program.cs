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
            model.fields.Add(new Field { 
                DisplayName = "User", 
                InternalName = "customDimentions.User", 
                fieldType = FieldType.String 
            });
            model.fields.Add(new Field
            {
                DisplayName = "Date",
                InternalName = "customDimentions.Date",
                fieldType = FieldType.String
            });
            model.fields.Add(new Field
            {
                DisplayName = "Result",
                InternalName = "customDimentions.Result",
                fieldType = FieldType.String
            });
            model.fields.Add(new Field
            {
                DisplayName = "Operation",
                InternalName = "customDimentions.Operation",
                fieldType = FieldType.String
            });
            model.fields.Add(new Field
            {
                DisplayName = "Guid",
                InternalName = "customDimentions.Guid",
                fieldType = FieldType.String
            });
            model.fields.Add(new Field
            {
                DisplayName = "DateOfAdding",
                InternalName = "timestamp",
                fieldType = FieldType.DateTime
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