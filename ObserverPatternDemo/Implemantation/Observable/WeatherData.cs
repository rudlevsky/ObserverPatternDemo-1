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

                Notify(currentData);
                Thread.Sleep(3000);
            }
        }

        /// <summary>
        /// Notifies all observers.
        /// </summary>
        protected virtual void Notify(WeatherInfo info)
        {
            foreach (IObserver<WeatherInfo> observer in observers)
            {
                observer.Update(this, info);
            }
        }

        /// <summary>
        /// Notifies all observers.
        /// </summary>
        void IObservable<WeatherInfo>.Notify(WeatherInfo info)
        {
            Notify(info);
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