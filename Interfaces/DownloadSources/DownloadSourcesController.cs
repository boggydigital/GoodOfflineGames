﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Interfaces.Status;

namespace Interfaces.DownloadSources
{
    public interface IGetDownloadSourcesAsyncDelegate
    {
        Task<IDictionary<long, IList<string>>> GetDownloadSourcesAsync(IStatus status);
    }

    public interface IDownloadSourcesController :
        IGetDownloadSourcesAsyncDelegate
    {
        // ...
    }
}