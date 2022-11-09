using System.Collections.Generic;

namespace DataModel
{
    public class Model
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Field timeField { get; set; }
        public List<TimeFieldOption> timestamps { get; set; }
        public List<Field> Fields { get; set; }
        public Model()
        {
            Fields = new List<Field>();
            timestamps = new List<TimeFieldOption>();
        }
    }
    public class Field
    {

        public string InternalName { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
        public FieldType FieldType { get; set; }
        public List<PossibleValue> PossibleValues { get; set; }
        public Field()
        {
            PossibleValues = new List<PossibleValue>();
        }
    }

    public class PossibleValue
    {
        public string PossibleOptionValue { get; set; }
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
