using System.Collections.Generic;
using System.Linq;
using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Confirmations.Interfaces;

namespace SecretSauce.Delegates.Confirmations
{
    public abstract class ConfirmExclusiveDelegate<T> :
        IConfirmDelegate<(IEnumerable<T>, IEnumerable<T>)>
    {
        private IIntersectDelegate<T> intersectDelegate;

        public ConfirmExclusiveDelegate(IIntersectDelegate<T> intersectDelegate)
        {
            this.intersectDelegate = intersectDelegate;
        }

        public bool Confirm((IEnumerable<T>, IEnumerable<T>) collections)
        {
            return !intersectDelegate.Intersect(
                collections.Item1,
                collections.Item2).Any();
        }
    }
}