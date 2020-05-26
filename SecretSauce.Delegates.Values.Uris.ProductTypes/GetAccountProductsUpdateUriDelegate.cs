namespace SecretSauce.Delegates.Values.Uris.ProductTypes
{
    public class GetAccountProductsUpdateUriDelegate : GetConstValueDelegate<string>
    {
        public GetAccountProductsUpdateUriDelegate() :
            base(Models.Uris.Uris.Endpoints.Account.GetFilteredProducts)
        {
            // ...
        }
    }
}