using System.Collections.Generic;
using System.IO;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace SecretSauce.Delegates.Itemizations
{
    public class ItemizeDirectoryFilesDelegate : IItemizeDelegate<string, string>
    {
        public IEnumerable<string> Itemize(string directory)
        {
            return Directory.EnumerateFiles(directory);
        }
    }
}