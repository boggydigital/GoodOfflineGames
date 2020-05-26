using GOG.Models;
using SecretSauce.Delegates.Conversions.Interfaces;

namespace GOG.Delegates.Conversions.UpdateIdentity.ProductTypes
{
    public class ConvertAccountProductToGameDetailsUpdateIdentityDelegate : IConvertDelegate<AccountProduct, string>
    {
        public string Convert(AccountProduct accountProduct)
        {
            return accountProduct.Id.ToString();
        }
    }
}