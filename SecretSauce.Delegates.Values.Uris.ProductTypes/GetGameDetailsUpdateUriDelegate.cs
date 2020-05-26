namespace SecretSauce.Delegates.Values.Uris.ProductTypes
{
    public class GetGameDetailsUpdateUriDelegate : GetConstValueDelegate<string>
    {
        public GetGameDetailsUpdateUriDelegate() :
            base(Models.Uris.Uris.Endpoints.Account.GameDetailsRequestTemplate)
        {
            // ...
        }
    }
}