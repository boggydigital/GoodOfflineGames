using System.Threading.Tasks;
using Models.ArgsDefinitions;
using SecretSauce.Delegates.Data.Interfaces;
using Tests.TestModels.ArgsDefinitions;

namespace Tests.TestDelegates.Data.ArgsDefinitions
{
    public class TestArgsDefinitionsDataAsyncDelegate : IGetDataAsyncDelegate<ArgsDefinition, string>
    {
        public async Task<ArgsDefinition> GetDataAsync(string uri = null)
        {
            return await Task.Run(() => { return ReferenceArgsDefinition.ArgsDefinition; });
        }
    }
}