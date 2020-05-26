using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.Indexes.ProductTypes;
using GOG.Delegates.Conversions.ProductTypes;
using GOG.Delegates.Data.Storage.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models;

namespace GOG.Delegates.Data.Models.ProductTypes
{
    public class UpdateProductAsyncDelegate : UpdateDataAsyncDelegate<Product>
    {
        [Dependencies(
            typeof(DeleteProductsAsyncDelegate),
            typeof(ConvertProductToIndexDelegate),
            typeof(GetStoredListProductDataAsyncDelegate))]
        public UpdateProductAsyncDelegate(
            IDeleteAsyncDelegate<Product> deleteProductsAsyncDelegate,
            IConvertDelegate<Product, long> convertProductToIndexDelegate,
            IGetDataAsyncDelegate<List<Product>, string> getProductsAsyncDelegate) :
            base(
                deleteProductsAsyncDelegate,
                convertProductToIndexDelegate,
                getProductsAsyncDelegate)
        {
            // ...
        }
    }
}