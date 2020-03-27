using System.Collections.Generic;

using Attributes;

using Interfaces.Delegates.Convert;
using Interfaces.Delegates.GetData;

namespace Delegates.GetData.Storage.ProductTypes
{
    public class GetUpdatedDataAsyncDelegate : GetJSONDataAsyncDelegate<List<long>>
    {
        [Dependencies(
            "Delegates.GetData.Storage.GetStringDataAsyncDelegate,Delegates",
            "Delegates.Convert.JSON.System.ConvertJSONToListLongDelegate,Delegates")]
        public GetUpdatedDataAsyncDelegate(
            IGetDataAsyncDelegate<string> getStringDataAsyncDelegate,
            IConvertDelegate<string, List<long>> convertJSONToListLongDelegate) :
            base(
                getStringDataAsyncDelegate,
                convertJSONToListLongDelegate)
        {
            // ...
        }
    }
}