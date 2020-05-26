using System.Collections.Generic;
using Models.QueryParameters;

namespace SecretSauce.Delegates.Values.QueryParameters.ProductTypes
{
    public class GetAccountProductsUpdateQueryParametersDelegate : GetConstValueDelegate<Dictionary<string, string>>
    {
        public GetAccountProductsUpdateQueryParametersDelegate() :
            base(QueryParametersCollections.AccountGetFilteredProducts)
        {
            // ...
        }
    }
}