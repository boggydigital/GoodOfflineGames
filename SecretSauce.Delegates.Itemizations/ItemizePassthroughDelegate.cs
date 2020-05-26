using System.Collections.Generic;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace SecretSauce.Delegates.Itemizations
{
    public class ItemizePassthroughDelegate : IItemizeDelegate<string, string>
    {
        public IEnumerable<string> Itemize(string item)
        {
            return new[] {item};
        }
    }
}