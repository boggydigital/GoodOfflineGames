using GOG.Models;
using SecretSauce.Delegates.Values.Interfaces;

namespace GOG.Delegates.Values.Images.ProductTypes
{
    public class GetProductImageUriDelegate : IGetValueDelegate<string, Product>
    {
        public string GetValue(Product product)
        {
            return product.Image;
        }
    }
}