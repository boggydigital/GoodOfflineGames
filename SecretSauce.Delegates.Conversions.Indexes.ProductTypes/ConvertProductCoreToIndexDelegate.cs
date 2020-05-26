using Models.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;

namespace SecretSauce.Delegates.Conversions.Indexes.ProductTypes
{
    public abstract class ConvertProductCoreToIndexDelegate<Type> : IConvertDelegate<Type, long>
        where Type : ProductCore
    {
        public long Convert(Type data)
        {
            return data.Id;
        }
    }
}