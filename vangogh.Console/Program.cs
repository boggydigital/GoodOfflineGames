using System;
using System.Threading.Tasks;
using GOG.Delegates.Conversions.Requests;
using GOG.Delegates.Server.Interfaces;
using SecretSauce.Delegates.Conversions.Requests;
using SecretSauce.Delegates.Conversions.Types;

namespace vangogh.Console
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var convertTypeToInstanceDelegate =
                new ConvertTypeToInstanceDelegate(
                    new ConvertTypeToDependenciesConstructorInfoDelegate(),
                    new ConvertConstructorInfoToDependenciesTypesDelegate());

            // var getStoredListProductsDataAsyncDelegate = convertTypeToInstanceDelegate.Convert(
            //         typeof(GetStoredListProductDataAsyncDelegate))
            //     as GetStoredListProductDataAsyncDelegate;

            // var products =  await getStoredListProductsDataAsyncDelegate.GetDataAsync();

            // foreach (var product in products)
            // {
            //     if (product.ReleaseDate != null) continue;
            //     System.Console.WriteLine($"{product.Id},{product.Title},{product.ReleaseDate},{product.Type}");
            // }
            // return;

            var convertArgsToRequestsDelegate = convertTypeToInstanceDelegate.Convert(
                    typeof(ConvertArgsToRequestsDelegate))
                as ConvertArgsToRequestsDelegate;

            var convertRequestToProcessDelegateTypeDelegate = convertTypeToInstanceDelegate.Convert(
                    typeof(ConvertRequestToProcessDelegateTypeDelegate))
                as ConvertRequestToProcessDelegateTypeDelegate;

            await foreach (var request in convertArgsToRequestsDelegate.ConvertAsync(args))
            {
                var processDelegateType = convertRequestToProcessDelegateTypeDelegate.Convert(request);

                if (processDelegateType == null)
                    throw new InvalidOperationException(
                        $"No respond delegate registered for request: {request.Method} {request.Collection}");

                var processAsyncDelegate = convertTypeToInstanceDelegate.Convert(
                        processDelegateType)
                    as IProcessAsyncDelegate;

                await processAsyncDelegate.ProcessAsync(request.Parameters);
            }

            System.Console.WriteLine("Press ENTER to exit...");
            System.Console.ReadLine();
        }
    }
}