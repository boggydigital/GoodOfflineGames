using System;
using System.Collections.Generic;
using Attributes;
using Interfaces.Models.Activities;
using Models.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Values.Activities;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Activities
{
    public class StartDelegate : IStartDelegate
    {
        private readonly IGetInstanceDelegate<Stack<IActivity>> getOngoingActivitiesInstanceDelegate;

        [Dependencies(
            typeof(GetOngoingActivitiesInstanceDelegate))]
        public StartDelegate(IGetInstanceDelegate<Stack<IActivity>> getOngoingActivitiesInstanceDelegate)
        {
            this.getOngoingActivitiesInstanceDelegate = getOngoingActivitiesInstanceDelegate;
        }

        public void Start(string title)
        {
            var activity = new Activity {Title = title, Started = DateTime.UtcNow};

            var ongoingActivities = getOngoingActivitiesInstanceDelegate.GetInstance();
            ongoingActivities.Push(activity);

            Console.WriteLine($"Started action {activity.Title}");
        }
    }
}