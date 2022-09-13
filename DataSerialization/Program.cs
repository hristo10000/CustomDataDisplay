using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace SerilisationLearning
{
    class Program
    {
        public static void Main(string[] args)
        {
            Model model = new Model();
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
            string fileName = "Model.xml";
            string fullname = Path.GetFullPath(fileName);
            XmlSerializer serializer = new XmlSerializer(typeof(Model));
            using (TextWriter writer = new StreamWriter($"{fullname}"))
            {
                serializer.Serialize(writer, model);
            }
        }
    }
}