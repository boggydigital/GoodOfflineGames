using System;
using System.Collections.Generic;
using Attributes;
using Interfaces.Models.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Values.Activities;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Activities
{
    public class CompleteDelegate : ICompleteDelegate
    {
        private readonly IGetInstanceDelegate<List<IActivity>> getCompletedActivitiesInstanceDelegate;
        private readonly IGetInstanceDelegate<Stack<IActivity>> getOngoingActivitiesInstanceDelegate;

        [Dependencies(
            typeof(GetOngoingActivitiesInstanceDelegate),
            typeof(GetCompletedActivitiesInstanceDelegate))]
        public CompleteDelegate(
            IGetInstanceDelegate<Stack<IActivity>> getOngoingActivitiesInstanceDelegate,
            IGetInstanceDelegate<List<IActivity>> getCompletedActivitiesInstanceDelegate)
        {
            this.getOngoingActivitiesInstanceDelegate = getOngoingActivitiesInstanceDelegate;
            this.getCompletedActivitiesInstanceDelegate = getCompletedActivitiesInstanceDelegate;
        }

        public void Complete()
        {
            var ongoingActivities = getOngoingActivitiesInstanceDelegate.GetInstance();
            var currentActivity = ongoingActivities.Pop();
            currentActivity.Complete = true;
            currentActivity.Completed = DateTime.UtcNow;

            var completedActivities = getCompletedActivitiesInstanceDelegate.GetInstance();
            completedActivities.Add(currentActivity);

            Console.WriteLine($"Completed action {currentActivity.Title}");
        }
    }
}