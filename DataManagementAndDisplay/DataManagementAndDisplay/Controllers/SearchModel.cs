using System;
using System.Collections.Generic;

namespace Controllers
{
    public class SearchModel
    {
        public string Time { get; set; }
        public string User { get; set; }
        public string Operation { get; set; }
        public string Result { get; set; }
        public string Guid { get; set; }
        public List<string> Fields { get; set; }
    }
}
