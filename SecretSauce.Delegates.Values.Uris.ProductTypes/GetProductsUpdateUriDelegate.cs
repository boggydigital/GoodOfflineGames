namespace SecretSauce.Delegates.Values.Uris.ProductTypes
{
    public class GetProductsUpdateUriDelegate : GetConstValueDelegate<string>
    {
        public GetProductsUpdateUriDelegate() :
            base(Models.Uris.Uris.Endpoints.Games.AjaxFiltered)
        {
            // ...
        }
    }
}