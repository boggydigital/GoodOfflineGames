using System.Collections.Generic;
using Models.QueryParameters;

namespace SecretSauce.Delegates.Values.QueryParameters.ProductTypes
{
    public class GetProductsUpdateQueryParametersDelegate : GetConstValueDelegate<Dictionary<string, string>>
    {
        public GetProductsUpdateQueryParametersDelegate() :
            base(QueryParametersCollections.GamesAjaxFiltered)
        {
            // ...
        }
    }
}