﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Interfaces.DownloadSources;
using Interfaces.Data;
using Interfaces.Enumeration;
using Interfaces.TaskStatus;

namespace GOG.TaskActivities.Download.Sources
{
    public class ManualUrlDownloadSourcesController : IDownloadSourcesController
    {
        private IDataController<long> updatedDataController;
        private IEnumerateDelegate<string> gameDetailsManualUrlEnumerationController;

        public ManualUrlDownloadSourcesController(
            IDataController<long> updatedDataController,
            IEnumerateDelegate<string> gameDetailsManualUrlEnumerationController)
        {
            this.updatedDataController = updatedDataController;
            this.gameDetailsManualUrlEnumerationController = gameDetailsManualUrlEnumerationController;
        }

        public async Task<IDictionary<long, IList<string>>> GetDownloadSourcesAsync(ITaskStatus taskStatus)
        {
            var gameDetailsDownloadSources = new Dictionary<long, IList<string>>();

            foreach (var id in updatedDataController.EnumerateIds())
            {
                var manualUrls = await gameDetailsManualUrlEnumerationController.EnumerateAsync(id);

                if (!gameDetailsDownloadSources.ContainsKey(id))
                    gameDetailsDownloadSources.Add(id, new List<string>());

                foreach (var url in manualUrls)
                    if (!gameDetailsDownloadSources[id].Contains(url))
                        gameDetailsDownloadSources[id].Add(url);
            }

            return gameDetailsDownloadSources;
        }
    }
}