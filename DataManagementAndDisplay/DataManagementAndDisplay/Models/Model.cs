using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    public class Model
    {
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
        public FieldType fieldType { get; set; }
    }
    public enum FieldType
    {
        String,
        Int,
        DateTime,
        Double
    }
}
