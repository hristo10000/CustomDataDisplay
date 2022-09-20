using System.Collections.Generic;

namespace Controllers
{
    public class MultipleModels
    {
        public IEnumerable<IDictionary<string, object>> Data;
        public DataModel.Model Model;
        public SearchModel searchModel;
        public MultipleModels(IEnumerable<IDictionary<string, object>> data, DataModel.Model model)
        {
            Data = data;
        }
        public MultipleModels(SearchModel data, DataModel.Model model)
        {
            searchModel = data;
            Model = model;
        }
        public MultipleModels(IEnumerable<IDictionary<string, object>> data, DataModel.Model model, SearchModel newSearchModel)
        {
            Data = data;
            Model = model;
            searchModel = newSearchModel;
        }
    }
}
