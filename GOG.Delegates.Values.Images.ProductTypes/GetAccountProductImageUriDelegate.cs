using GOG.Models;
using SecretSauce.Delegates.Values.Interfaces;

namespace GOG.Delegates.Values.Images.ProductTypes
{
    public class GetAccountProductImageUriDelegate : IGetValueDelegate<string, AccountProduct>
    {
        public string GetValue(AccountProduct accountProduct)
        {
            return accountProduct.Image;
        }
    }
}