using System;
using System.Linq;
using System.Collections.Generic;
using Interfaces.Delegates.Convert;
using Interfaces.Delegates.Collections;
using Interfaces.Delegates.Data;
using Attributes;
using Models.ArgsTokens;
using Models.ArgsDefinitions;

namespace Delegates.Convert.ArgsTokens
{
    public class ConvertLikelyTypedToTypedTokensDelegate :
        IConvertAsyncDelegate<
            IAsyncEnumerable<(string Token, Tokens Type)>,
            IAsyncEnumerable<(string Token, Tokens Type)>>
    {
        private IGetDataAsyncDelegate<ArgsDefinition, string> getArgsDefinitionsDataFromPathAsyncDelegate;
        private IFindDelegate<Method> findMethodDelegate;
        private IFindDelegate<Parameter> findParameterDelegate;

        [Dependencies(
            "Delegates.Data.Storage.ArgsDefinitions.GetArgsDefinitionsDataFromPathAsyncDelegate,Delegates",
            "Delegates.Collections.ArgsDefinitions.FindMethodDelegate,Delegates",
            "Delegates.Collections.ArgsDefinitions.FindParameterDelegate,Delegates")]
        public ConvertLikelyTypedToTypedTokensDelegate(
            IGetDataAsyncDelegate<ArgsDefinition, string> getArgsDefinitionsDataFromPathAsyncDelegate,
            IFindDelegate<Method> findMethodDelegate,
            IFindDelegate<Parameter> findParameterDelegate)
        {
            this.getArgsDefinitionsDataFromPathAsyncDelegate = getArgsDefinitionsDataFromPathAsyncDelegate;
            this.findMethodDelegate = findMethodDelegate;
            this.findParameterDelegate = findParameterDelegate;
        }

        public async IAsyncEnumerable<(string Token, Tokens Type)> ConvertAsync(
            IAsyncEnumerable<(string Token, Tokens Type)> likelyTypedTokens)
        {
            if (likelyTypedTokens == null)
                throw new ArgumentNullException();

            var argsDefinitions = 
                await getArgsDefinitionsDataFromPathAsyncDelegate.GetDataAsync(string.Empty);

            var currentParameterTitle = string.Empty;
            await foreach (var likelyTypedToken in likelyTypedTokens)
            {
                if (string.IsNullOrEmpty(likelyTypedToken.Token)) continue;

                switch (likelyTypedToken.Type)
                {
                    case Tokens.LikelyMethodsAbbrevation:
                        var methodsAbbrevations =
                            string.IsNullOrEmpty(likelyTypedToken.Token)
                                ? string.Empty
                                : likelyTypedToken.Token.Substring(
                                    Prefixes.MethodsAbbrevation.Length);
                        foreach (var methodAbbrevation in methodsAbbrevations)
                        {
                            var abbrevatedMethod = findMethodDelegate.Find(
                                argsDefinitions.Methods,
                                method => method.Title.StartsWith(methodAbbrevation));

                            yield return abbrevatedMethod == null
                                ? (methodAbbrevation.ToString(), Tokens.Unknown)
                                : (abbrevatedMethod.Title, Tokens.MethodTitle);
                        }

                        break;
                    case Tokens.LikelyParameterValue:
                        var tokenType = Tokens.Unknown;

                        var titledParameter = findParameterDelegate.Find(
                            argsDefinitions.Parameters,
                            parameter => parameter.Title == currentParameterTitle);

                        if (titledParameter == null)
                        {
                            tokenType = Tokens.Unknown;
                        }
                        else
                        {
                            if (titledParameter.Values == null) tokenType = Tokens.ParameterValue;
                            else
                                tokenType =
                                    titledParameter.Values.Contains(likelyTypedToken.Token)
                                        ? Tokens.ParameterValue
                                        : Tokens.Unknown;
                        }

                        yield return (likelyTypedToken.Token, tokenType);
                        break;
                    case Tokens.ParameterTitle:
                        currentParameterTitle =
                            string.IsNullOrEmpty(likelyTypedToken.Token)
                                ? string.Empty
                                : likelyTypedToken.Token.Substring(
                                    Prefixes.ParameterTitle.Length);
                        yield return (currentParameterTitle, Tokens.ParameterTitle);
                        break;
                    default:
                        yield return likelyTypedToken;
                        break;
                }
            }
        }
    }
}