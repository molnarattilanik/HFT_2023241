using System;
using System.Collections.Generic;

namespace Modul01
{
    public enum Category
    {
        Opinion, BugReport, FeatureRequest
    }

    public class Feedback
    {
        public string Name { get; set; }
        public Category FeedbackType { get; set; }
    }

    public class FeedbackProcess
    {
        private const int Limit = 3;
        private readonly Dictionary<Category, Action<Feedback>> actions;

        private readonly List<Feedback> feedbacks;

        public FeedbackProcess()
        {
            feedbacks = new List<Feedback>();

            actions = new Dictionary<Category, Action<Feedback>>();
            foreach (Category item in Enum.GetValues(typeof(Category)))
            {
                actions.Add(item, (feedback) => Console.WriteLine($"Default Feedback {feedback.Name}"));
            }
        }

        public void AddActionToCategory(Category category, Action<Feedback> action)
        {
            actions[category] += action;
        }

        public void AddFeedback(Feedback feedback)
        {
            feedbacks.Add(feedback);
            if (feedbacks.Count == Limit)
            {
                foreach (var item in feedbacks)
                {
                    actions[item.FeedbackType]?.Invoke(item);
                }
                feedbacks.Clear();
            }
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            FeedbackProcess feedbackProcess = new FeedbackProcess();

            Feedback f1 = new() { Name = "First Feedback", FeedbackType = Category.BugReport };
            Feedback f2 = new() { Name = "Second Feedback", FeedbackType = Category.FeatureRequest };
            Feedback f3 = new() { Name = "Third Feedback", FeedbackType = Category.Opinion };


            feedbackProcess.AddActionToCategory(Category.BugReport, Sms);
            feedbackProcess.AddActionToCategory(Category.FeatureRequest, Sms);
            feedbackProcess.AddActionToCategory(Category.Opinion, Sms);

            feedbackProcess.AddActionToCategory(Category.FeatureRequest, (feedback) =>
            {
                Console.WriteLine($"Email {feedback.Name}");
            });


            feedbackProcess.AddFeedback(f1);
            feedbackProcess.AddFeedback(f2);
            feedbackProcess.AddFeedback(f3);
        }

        private static void Sms(Feedback feedback)
        {
            Console.WriteLine($"SMS {feedback.Name}");
        }
    }
}
