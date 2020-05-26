using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Attributes;
using Models.ArgsDefinitions;
using Models.Requests;
using SecretSauce.Delegates.Collections.ArgsDefinitions;
using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Confirmations.System;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Conversions.Requests
{
    public class ConvertRequestsDataToResolvedCollectionsDelegate :
        IConvertAsyncDelegate<RequestsData, Task<RequestsData>>
    {
        private readonly IConfirmDelegate<(IEnumerable<string>, IEnumerable<string>)> confirmExlusiveStringDelegate;
        private readonly IFindDelegate<Method> findMethodDelegate;
        private readonly IGetDataAsyncDelegate<ArgsDefinition, string> getArgsDefinitionsDataFromPathAsyncDelegate;

        [Dependencies(
            typeof(Data.Storage.ArgsDefinitions.GetStoredArgsDefinitionsDataAsyncDelegate),
            typeof(FindMethodDelegate),
            typeof(ConfirmExclusiveStringDelegate))]
        public ConvertRequestsDataToResolvedCollectionsDelegate(
            IGetDataAsyncDelegate<ArgsDefinition, string> getArgsDefinitionsDataFromPathAsyncDelegate,
            IFindDelegate<Method> findMethodDelegate,
            IConfirmDelegate<(IEnumerable<string>, IEnumerable<string>)> confirmExlusiveStringDelegate)
        {
            this.getArgsDefinitionsDataFromPathAsyncDelegate = getArgsDefinitionsDataFromPathAsyncDelegate;
            this.findMethodDelegate = findMethodDelegate;
            this.confirmExlusiveStringDelegate = confirmExlusiveStringDelegate;
        }

        public async Task<RequestsData> ConvertAsync(RequestsData requestsData)
        {
            var defaultCollections = new List<string>();
            var argsDefinitions =
                await getArgsDefinitionsDataFromPathAsyncDelegate.GetDataAsync(string.Empty);

            foreach (var method in requestsData.Methods)
            {
                var methodDefinition = findMethodDelegate.Find(
                    argsDefinitions.Methods,
                    m => m.Title == method);

                if (methodDefinition == null) throw new ArgumentException();

                if (confirmExlusiveStringDelegate.Confirm(
                        (methodDefinition.Collections, requestsData.Collections)) &&
                    methodDefinition.Collections != null)
                    defaultCollections.AddRange(methodDefinition.Collections);
            }

            foreach (var collection in defaultCollections)
                if (!requestsData.Collections.Contains(collection))
                    requestsData.Collections.Add(collection);

            return requestsData;
        }
    }
}