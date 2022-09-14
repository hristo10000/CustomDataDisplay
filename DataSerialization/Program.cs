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
            string filePath = AppDomain.CurrentDomain.BaseDirectory;
            XmlSerializer serializer = new(typeof(Model));
            filePath =  Path.Combine(filePath, "Model.xml");
            var path = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            path = path.Parent.Parent.Parent.Parent.CreateSubdirectory("Model.");
            using TextWriter writer = new StreamWriter(path.ToString());
            serializer.Serialize(writer, model);
        }
    }
}