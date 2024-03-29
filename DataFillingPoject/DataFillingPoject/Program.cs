﻿using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;

namespace DataFillingPoject
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            var random = new Random();
            string user, operation, result, guid;
            DateTime dateTime;
            List<string> users = new() { "Viktor", "Hristo", "Slavi", "Vilian", "Martin", "Daniel" };
            List<string> operations = new() { "Delete", "Add", "Update", "View" };
            List<string> results = new() { "Success", "Warning", "Fail"};
            var ai = new TelemetryClient(new Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration() { InstrumentationKey = "874248d8-135f-4abf-9806-1af60a7a5a46" })
            {
                InstrumentationKey = "874248d8-135f-4abf-9806-1af60a7a5a46"
            };
            Console.WriteLine("Number Of Logs:");
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
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
