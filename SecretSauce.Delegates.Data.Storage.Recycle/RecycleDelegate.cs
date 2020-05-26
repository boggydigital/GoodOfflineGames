using System.IO;
using Attributes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Directories.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Data.Storage.Recycle
{
    public class DeleteToRecycleDelegate : IDeleteDelegate<string>
    {
        private readonly IGetValueDelegate<string, string> getDirectoryDelegate;
        private readonly IMoveDelegate<string> moveFileDelegate;

        [Dependencies(
            typeof(GetRecycleBinDirectoryDelegate),
            typeof(MoveFileDelegate))]
        public DeleteToRecycleDelegate(
            IGetValueDelegate<string, string> getDirectoryDelegate,
            IMoveDelegate<string> moveFileDelegate)
        {
            this.getDirectoryDelegate = getDirectoryDelegate;
            this.moveFileDelegate = moveFileDelegate;
        }

        public void Delete(string uri)
        {
            var recycleBinUri = Path.Combine(
                getDirectoryDelegate.GetValue(string.Empty),
                uri);
            moveFileDelegate.Move(uri, recycleBinUri);
        }
    }
}