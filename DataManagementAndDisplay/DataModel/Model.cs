using System.Collections.Generic;

namespace DataModel
{
    public class Model
    {
        public Field timeField;
        public List<Field> fields;
        public Model()
        {
            fields = new List<Field>();
        }
    }
    public class Field
    {
        public string DisplayName { get; set; }
        public string InternalName { get; set; }
        public FieldType FieldType { get; set; }
        public string Value { get; set; }
    }
    public enum FieldType
    {
        String,
        Int,
        DateTime,
        Double
    }
}
