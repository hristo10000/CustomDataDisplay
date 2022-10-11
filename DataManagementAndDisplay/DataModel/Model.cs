using System.Collections.Generic;

namespace DataModel
{ 
public class Model
{
    public Field timeField;
    public List<TimeFieldOption> timestamps;
    public List<Field> fields;
    public Model()
    {
        fields = new List<Field>();
        timestamps = new List<TimeFieldOption>();
    }
}
public class Field {

        public string InternalName { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
        public FieldType FieldType { get; set; }
    }

    public enum FieldType
    {
        String,
        Int,
        Double,
        DateTime
    }

    public class TimeFieldOption
{
    public TimeFieldOption()
    {

    }
    public string InternalName { get; set; }
    public string DisplayName { get; set; }
}
}
