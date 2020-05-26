using Attributes;
using Models.Separators;
using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Collections.System;
using SecretSauce.Delegates.Confirmations;

namespace GOG.Delegates.Confirmations.Languages.ProductTypes
{
    public class ConfirmGameDetailsContainsLanguageDelegate : ConfirmStringMatchesAllDelegate
    {
        [Dependencies(
            typeof(MapStringDelegate))]
        public ConfirmGameDetailsContainsLanguageDelegate(
            IMapDelegate<string> mapStringDelegate) :
            base(
                mapStringDelegate,
                Separators.GameDetailsDownloadsStart,
                Separators.GameDetailsDownloadsEnd)
        {
            // ...
        }
    }
}