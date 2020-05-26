using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Collections.ProductTypes;
using GOG.Delegates.Conversions.Indexes.ProductTypes;
using GOG.Delegates.Conversions.ProductTypes;
using GOG.Delegates.Data.Storage.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models;

namespace GOG.Delegates.Data.Models.ProductTypes
{
    public class GetProductByIdAsyncDelegate : GetDataByIdAsyncDelegate<Product>
    {
        [Dependencies(
            typeof(GetStoredListProductDataAsyncDelegate),
            typeof(FindProductDelegate),
            typeof(ConvertProductToIndexDelegate))]
        public GetProductByIdAsyncDelegate(
            IGetDataAsyncDelegate<List<Product>, string> getListProductsAsyncDelegate,
            IFindDelegate<Product> findDelegate,
            IConvertDelegate<Product, long> convertProductToIndexDelegate) :
            base(
                getListProductsAsyncDelegate,
                findDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}