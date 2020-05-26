using Attributes;
using GOG.Models;
using SecretSauce.Delegates.Collections;
using SecretSauce.Delegates.Collections.Interfaces;

namespace GOG.Delegates.Collections.ProductTypes
{
    public class FindGameDetailsDelegate : FindDelegate<GameDetails>
    {
        [Dependencies(
            typeof(FindAllGameDetailsDelegate))]
        public FindGameDetailsDelegate(
            IFindAllDelegate<GameDetails> findAllGameDetailsDelegate) :
            base(findAllGameDetailsDelegate)
        {
            // ...
        }
    }
}