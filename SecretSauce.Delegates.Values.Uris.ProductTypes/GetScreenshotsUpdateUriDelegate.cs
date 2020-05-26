namespace SecretSauce.Delegates.Values.Uris.ProductTypes
{
    public class GetScreenshotsUpdateUriDelegate : GetConstValueDelegate<string>
    {
        public GetScreenshotsUpdateUriDelegate() :
            base(Models.Uris.Uris.Endpoints.ProductPage.ProductTemplate)
        {
            // ...
        }
    }
}