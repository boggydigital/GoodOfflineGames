using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Interfaces.Delegates.Convert;
using Models.ArgsTokens;
using TestDelegates.Convert.Types;

namespace Delegates.Convert.ArgsTokens.Tests
{
    public class ConvertMethodsSetTokensToMethodTitleTokensDelegateTests
    {
        private readonly IConvertAsyncDelegate<IEnumerable<string>, IAsyncEnumerable<(string, Tokens)>>
            convertTokensToLikelyTypedTokensDelegate;

        private readonly IConvertAsyncDelegate<IAsyncEnumerable<(string, Tokens)>, IAsyncEnumerable<(string, Tokens)>>
            convertLikelyTypedToTypedTokensDelegate;

        private readonly IConvertAsyncDelegate<IAsyncEnumerable<(string, Tokens)>, IAsyncEnumerable<(string, Tokens)>>
            convertMethodsSetTokensToMethodTitleTokensDelegate;

        public ConvertMethodsSetTokensToMethodTitleTokensDelegateTests()
        {
            convertTokensToLikelyTypedTokensDelegate = ConvertTypeToInstanceDelegateInstances.Test.Convert(
                    typeof(ConvertTokensToLikelyTypedTokensDelegate))
                as ConvertTokensToLikelyTypedTokensDelegate;

            convertLikelyTypedToTypedTokensDelegate = ConvertTypeToInstanceDelegateInstances.Test.Convert(
                    typeof(ConvertLikelyTypedToTypedTokensDelegate))
                as ConvertLikelyTypedToTypedTokensDelegate;

            convertMethodsSetTokensToMethodTitleTokensDelegate = ConvertTypeToInstanceDelegateInstances.Test.Convert(
                    typeof(ConvertMethodsSetTokensToMethodTitleTokensDelegate))
                as ConvertMethodsSetTokensToMethodTitleTokensDelegate;
        }

        private async Task<List<(string, Tokens)>> ConvertTokensToTypedMethodTitleTokens(params string[] tokens)
        {
            var likelyTypedTokes = convertTokensToLikelyTypedTokensDelegate.ConvertAsync(
                tokens);

            var typedTokens = convertLikelyTypedToTypedTokensDelegate.ConvertAsync(
                likelyTypedTokes);

            var methodTitleTokens = convertMethodsSetTokensToMethodTitleTokensDelegate.ConvertAsync(
                typedTokens);

            var typedMethodTitleTokens = new List<(string, Tokens)>();

            await foreach (var token in methodTitleTokens)
                typedMethodTitleTokens.Add(token);

            return typedMethodTitleTokens;
        }

        [Theory]
        [InlineData("sync")]
        public async Task CanConvertMethodsSetTokensToMethodTitleTokens(string token)
        {
            var typedTokens = await ConvertTokensToTypedMethodTitleTokens(
                new string[] {token});

            Assert.Equal(3, typedTokens.Count());
            foreach (var typedToken in typedTokens)
                Assert.Equal(Tokens.MethodTitle, typedToken.Item2);
        }

        [Theory]
        [InlineData("products")]
        [InlineData("-u")]
        [InlineData("--id")]
        [InlineData("update")]
        [InlineData("arbitrarystring")]
        public async void ConvertMethodsSetTokensToMethodTitleTokensDelegatePassesThroughOtherTypes(string token)
        {
            var typedTokens = await ConvertTokensToTypedMethodTitleTokens(
                new string[] {token});

            Assert.Single(typedTokens);
            Assert.NotEqual(Tokens.MethodsSet, typedTokens.ElementAt(0).Item2);
        }
    }
}