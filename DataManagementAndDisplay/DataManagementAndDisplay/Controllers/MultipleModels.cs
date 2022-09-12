using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    public class MultipleModels
    {
        public IEnumerable<IDictionary<string, object>> Data;
        public SearchModel searchModel;
        public MultipleModels(IEnumerable<IDictionary<string, object>> data)
        {
            Data = data;
        }
        public MultipleModels(SearchModel data)
        {
            searchModel = data;
        }
        public MultipleModels(IEnumerable<IDictionary<string, object>> data, SearchModel data1)
        {
            Data = data;
            searchModel = data1;
        }
    }
}
