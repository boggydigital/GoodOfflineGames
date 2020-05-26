using System.Threading.Tasks;
using Attributes;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.Units;
using SecretSauce.Delegates.Throttling.Interfaces;

namespace SecretSauce.Delegates.Throttling
{
    public class ThrottleAsyncDelegate : IThrottleAsyncDelegate<int>
    {
        private readonly ICompleteDelegate completeDelegate;
        private readonly IConvertDelegate<long, string> convertSecondsToStringDelegate;
        private readonly IStartDelegate startDelegate;

        [Dependencies(
            typeof(ConvertSecondsToStringDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public ThrottleAsyncDelegate(
            IConvertDelegate<long, string> convertSecondsToStringDelegate,
            IStartDelegate startDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.convertSecondsToStringDelegate = convertSecondsToStringDelegate;
            this.startDelegate = startDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task ThrottleAsync(int delaySeconds)
        {
            startDelegate.Start(
                $"Sleeping {convertSecondsToStringDelegate.Convert(delaySeconds)} before next operation");

            for (var ii = 0; ii < delaySeconds; ii++)
                await Task.Delay(1000);
            // await statusController.UpdateProgressAsync(
            //     throttleTask,
            //     ii + 1,
            //     delaySeconds,
            //     "Countdown",
            //     TimeUnits.Seconds);

            completeDelegate.Complete();
        }
    }
}