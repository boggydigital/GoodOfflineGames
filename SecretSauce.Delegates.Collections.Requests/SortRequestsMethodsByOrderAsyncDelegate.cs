using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Attributes;
using Models.ArgsDefinitions;
using SecretSauce.Delegates.Collections.ArgsDefinitions;
using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ArgsDefinitions;

namespace SecretSauce.Delegates.Collections.Requests
{
    public class SortRequestsMethodsByOrderAsyncDelegate : ISortAsyncDelegate<string>
    {
        private readonly IFindDelegate<Method> findMethodDelegate;
        private IGetDataAsyncDelegate<ArgsDefinition, string> getArgsDefinitionsDataFromPathAsyncDelegate;

        [Dependencies(
            typeof(GetStoredArgsDefinitionsDataAsyncDelegate),
            typeof(FindMethodDelegate))]
        public SortRequestsMethodsByOrderAsyncDelegate(
            IGetDataAsyncDelegate<ArgsDefinition, string> getArgsDefinitionsDataFromPathAsyncDelegate,
            IFindDelegate<Method> findMethodDelegate)
        {
            this.getArgsDefinitionsDataFromPathAsyncDelegate = getArgsDefinitionsDataFromPathAsyncDelegate;
            this.findMethodDelegate = findMethodDelegate;
        }

        public async Task SortAsync(List<string> methods)
        {
            var argsDefinitions =
                await getArgsDefinitionsDataFromPathAsyncDelegate.GetDataAsync(string.Empty);

            methods.Sort((x, y) =>
            {
                var cx = findMethodDelegate.Find(argsDefinitions.Methods, c => c.Title == x);
                var cy = findMethodDelegate.Find(argsDefinitions.Methods, c => c.Title == y);

                if (cx == null || cy == null)
                    throw new InvalidOperationException();

                return cx.Order - cy.Order;
            });
        }
    }
}