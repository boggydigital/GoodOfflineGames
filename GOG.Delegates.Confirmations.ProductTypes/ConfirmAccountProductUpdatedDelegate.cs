using GOG.Models;
using SecretSauce.Delegates.Confirmations.Interfaces;

namespace GOG.Delegates.Confirmations.ProductTypes
{
    public class ConfirmAccountProductUpdatedDelegate : IConfirmDelegate<AccountProduct>
    {
        public bool Confirm(AccountProduct accountProduct)
        {
            return accountProduct.IsNew || accountProduct.Updates > 0;
        }
    }
}