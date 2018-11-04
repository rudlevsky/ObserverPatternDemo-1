using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;
using System;

namespace WeatherStation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var weather = new WeatherData();
            var statistic = new StatisticReport();
            var current = new CurrentConditionsReport();

            weather.Register(statistic);
            weather.Register(current);

            WeatherInfo[] array =
            {
                new WeatherInfo(32, 1002, 65),
                new WeatherInfo(30, 1001, 60),
                new WeatherInfo(28, 1000, 55)
            };

            // Updating WeatherData and getting reports from subscribers.
            foreach (var item in array)
            {
                weather.CurrentData = item;

                Console.WriteLine(current.GetReport());
                string[] stat = statistic.GetStatisticReport();

                Console.WriteLine();

                foreach (var report in stat)
                {
                    Console.WriteLine(report);
                }

                Console.WriteLine();
            }

            // Data doesn't refresh after unsubscribing.
            weather.Unregister(current);
            weather.CurrentData = new WeatherInfo(10, 1000, 100);

            Console.WriteLine(current.GetReport());
        }
    }
}
