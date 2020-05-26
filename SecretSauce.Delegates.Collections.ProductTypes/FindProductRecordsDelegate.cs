using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.ProductTypes
{
    public class FindProductRecordsDelegate : FindDelegate<ProductRecords>
    {
        [Dependencies(
            typeof(FindAllProductRecordsDelegate))]
        public FindProductRecordsDelegate(
            IFindAllDelegate<ProductRecords> findAllProductRecordsDelegate) :
            base(findAllProductRecordsDelegate)
        {
            // ...
        }
    }
}