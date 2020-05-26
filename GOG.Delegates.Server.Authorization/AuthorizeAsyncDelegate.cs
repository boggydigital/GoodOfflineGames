using System.Collections.Generic;
using System.Threading.Tasks;
using Attributes;
using GOG.Delegates.Authorization.Interfaces;
using GOG.Delegates.Server.Interfaces;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;

namespace GOG.Delegates.Server.Authorization
{
    [ApiEndpoint(Method = "authorize")]
    public class AuthorizeAsyncDelegate : IProcessAsyncDelegate
    {
        private readonly IAuthorizeAsyncDelegate authorizeAsyncDelegate;
        private readonly ICompleteDelegate completeDelegate;
        private readonly IStartDelegate startDelegate;

        [Dependencies(
            typeof(AuthorizeAsyncDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public AuthorizeAsyncDelegate(
            IAuthorizeAsyncDelegate authorizeAsyncDelegate,
            IStartDelegate startDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.authorizeAsyncDelegate = authorizeAsyncDelegate;
            this.startDelegate = startDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task ProcessAsync(IDictionary<string, IEnumerable<string>> parameters)
        {
            var username = string.Empty;
            var password = string.Empty;

            await authorizeAsyncDelegate.AuthorizeAsync(
                username,
                password);
        }
    }
}