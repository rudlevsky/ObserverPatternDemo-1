using System;
using System.Collections.Generic;
using System.Threading;

namespace ObserverPatternDemo.Implemantation.Observable
{
    /// <summary>
    /// Class manages IObserver objects.
    /// </summary>
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> observers;
        private WeatherInfo currentData;
        public bool GeneratorWork { get; set; } = true;

        /// <summary>
        /// Initializes a list of all observers.
        /// </summary>
        public WeatherData()
        {
            observers = new List<IObserver<WeatherInfo>>();
        }

        public void StartGenerator()
        {
            while(GeneratorWork)
            {
                Random rand = new Random();
                var currentData = new WeatherInfo { Temperature = rand.Next(40), Humidity = rand.Next(400, 500), Pressure = rand.Next(990, 1010) };

                IObservable<WeatherInfo> obj = this;
                obj.Notify(this, currentData);

                Thread.Sleep(3000);
            }
        }

        /// <summary>
        /// Notifies all observers.
        /// </summary>
        void IObservable<WeatherInfo>.Notify(object sender, WeatherInfo info)
        {
            foreach (IObserver<WeatherInfo> observer in observers)
            {
                observer.Update(this, info);
            }
        }

        /// <summary>
        /// Registers an observer.
        /// </summary>
        /// <param name="observer">Observer for registration.</param>
        public void Register(IObserver<WeatherInfo> observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// Unregisters an observer.
        /// </summary>
        /// <param name="observer">Observer for unregistration.</param>
        public void Unregister(IObserver<WeatherInfo> observer)
        {
            observers.Remove(observer);
        }
    }
}