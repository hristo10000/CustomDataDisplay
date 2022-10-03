using System.Collections.Generic;

namespace Controllers
{
    public class SearchModel
    {
        public SearchField Time { get; set; }
        public List<SearchField> Fields { get; set; }
        public SearchModel()
        {
            Fields = new List<SearchField>();
        }
    }
    public class SearchField
    {
        public string InternalName { get; set; }
        public string Value { get; set; }

    }
}
