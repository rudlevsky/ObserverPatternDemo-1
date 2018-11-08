using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;
using System;
using System.Threading;

namespace WeatherStation
{
    public class Program
    {
        private static WeatherData weather;
        private static StatisticReport statistic;
        private static CurrentConditionsReport current;

        // Gets reports from subscribers.
        private static void GetReports()
        {
            int count = 0;

            while(count < 5)
            {
                Console.WriteLine(current.GetReport());
                string[] stat = statistic.GetStatisticReport();

                Console.WriteLine();

                foreach (var report in stat)
                {
                    Console.WriteLine(report);
                }

                Console.WriteLine();

                Thread.Sleep(3500);
                count++;
            }

            weather.GeneratorWork = false;
        }

        private static void Main(string[] args)
        {
            weather = new WeatherData();
            statistic = new StatisticReport();
            current = new CurrentConditionsReport();

            weather.Register(statistic);
            weather.Register(current);

            Thread getThread = new Thread(GetReports); 

            getThread.Start(); 
            weather.StartGenerator();
        }
    }
}
