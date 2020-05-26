namespace SecretSauce.Delegates.Values.Uris.ProductTypes
{
    public class GetApiProductsUpdateUriDelegate : GetConstValueDelegate<string>
    {
        public GetApiProductsUpdateUriDelegate() :
            base(Models.Uris.Uris.Endpoints.Api.ProductTemplate)
        {
            // ...
        }
    }
}