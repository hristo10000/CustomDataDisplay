using System.IO;
using System.Xml.Serialization;

namespace DataModel
{
    public class ModelReader
    {
        public static Model GetModel()
        {
            XmlSerializer serializer = new(typeof(Model));
            using Stream reader = new FileStream("Model.xml", FileMode.Open);
            Model model = (Model)serializer.Deserialize(reader);
            return model;
        }
    }
}
