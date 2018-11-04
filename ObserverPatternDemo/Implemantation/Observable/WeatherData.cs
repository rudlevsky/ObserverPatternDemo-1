using System;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    /// <summary>
    /// Class manages IObserver objects.
    /// </summary>
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> observers;
        private WeatherInfo currentData;

        /// <summary>
        /// Initializes a list of all observers.
        /// </summary>
        public WeatherData()
        {
            observers = new List<IObserver<WeatherInfo>>();
        }

        /// <summary>
        /// Returns and sets current data.
        /// </summary>
        public WeatherInfo CurrentData
        {
            get
            {
                if (currentData == null)
                {
                    throw new ArgumentNullException($"{nameof(currentData)} was null.");
                }

                return currentData.Clone();
            }
            set
            {
                currentData = value;
                Notify();
            }
        }

        /// <summary>
        /// Notifies all observers.
        /// </summary>
        public void Notify()
        {
            foreach (IObserver<WeatherInfo> observer in observers)
            {
                observer.Update(CurrentData);
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