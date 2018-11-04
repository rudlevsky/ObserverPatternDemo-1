﻿using System;
using System.Collections.Generic;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// Class creates statistic report.
    /// </summary>
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private List<WeatherInfo> listInfo;

        /// <summary>
        /// Constructor creates a list of all reports.
        /// </summary>
        public StatisticReport()
        {
            listInfo = new List<WeatherInfo>();
        }

        /// <summary>
        /// Adds new report in the list of all reports.
        /// </summary>
        /// <param name="data"></param>
        public void Update(WeatherInfo data)
        {
            listInfo.Add(data);
        }

        /// <summary>
        /// Creates string representation of the statistic reports.
        /// </summary>
        /// <returns>Returns a string which contains string representations of all reports.</returns>
        public string[] GetStatisticReport()
        {
            string[] report = new string[listInfo.Count];

            for (int i = 0; i < listInfo.Count; i++)
            {
                report[i] = $"Temperature: {listInfo[i].Temperature}, Humidity: {listInfo[i].Humidity}, Pressure: {listInfo[i].Pressure}";
            }

            return report;
        }
    }
}
