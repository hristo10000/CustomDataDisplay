using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;

namespace DataFillingPoject
{
    class Program
    {
        //user, operation, result(success, warning or fail), datetime(random), guid
        [Obsolete]
        static void Main(string[] args)
        {
            var random = new Random();
            string user, operation, result, guid;
            DateTime dateTime;
            List<string> users = new() { "Viktor", "Hristo", "Slavi", "Vilian", "Martin", "Daniel" };
            List<string> operations = new() { "Delete", "Add", "Update", "View" };
            List<string> results = new() { "Success", "Warning", "Fail"};
            var ai = new TelemetryClient(new Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration() { InstrumentationKey = "93282e89-6ef0-4513-b4a4-d5f07c63ac2e" })
            {
                InstrumentationKey = "93282e89-6ef0-4513-b4a4-d5f07c63ac2e"
            };
            for(int i = 0; i < 200; i++)
            {
                dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, random.Next(0, 23), random.Next(0, 59), random.Next(0, 59), random.Next(0, 999));
                user = users[random.Next(users.Count)];
                operation = operations[random.Next(operations.Count)];
                result = results[random.Next(results.Count)];
                guid = Guid.NewGuid().ToString();
                ai.TrackEvent($"Index", new Dictionary<string, string>() { { "User", user }, { "Operation", operation }, { "Result", result }, { "Date", $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {random.Next(0, 23)}:{random.Next(0, 59)}:{random.Next(0, 59)}.{random.Next(0, 999)}" }, { "Guid", guid } });
            }
            ai.Flush();
        }
    }
}