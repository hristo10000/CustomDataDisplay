﻿using Controllers;
using System.Collections.Generic;

namespace DataManagementAndDisplay.Models
{
    public class SearchModel
    {
        public SearchField Time { get; set; }
        public List<SearchField> Fields { get; set; }
        public NameOfModel NameOfModel { get; set; }
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
