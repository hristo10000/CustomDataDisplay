using System.Collections.Generic;

namespace Controllers
{
    public class MultipleModels
    {
        public IEnumerable<IDictionary<string, object>> Data;
        public DataModel.Model Model;
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
