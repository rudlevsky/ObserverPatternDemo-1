using System;

namespace ObserverPatternDemo.Implemantation.Observable
{
    /// <summary>
    /// Class manages IObserver objects.
    /// </summary>
    public class WeatherData : IObservable<WeatherInfo>
    {
        /// <summary>
        /// Contains subscribers methods.
        /// </summary>
        public event Action<object, WeatherInfo> NewMail;

        /// <summary>
        /// Generates data and sends it to subscribers.
        /// </summary>
        public void OnGenerate()
        {
            Random rand = new Random();
            var currentData = new WeatherInfo { Temperature = rand.Next(40), Humidity = rand.Next(400, 500), Pressure = rand.Next(990, 1010) };

            IObservable<WeatherInfo> obj = this;
            obj.Notify(currentData);
        }

        /// <summary>
        /// Registers a subscriber.
        /// </summary>
        /// <param name="observer">Observer for subscribing.</param>
        public void Register(IObserver<WeatherInfo> observer)
        {
            NewMail += observer.Update;
        }

        /// <summary>
        /// Unregisters a subscriber.
        /// </summary>
        /// <param name="observer">Observer for unsubscribing.</param>
        public void Unregister(IObserver<WeatherInfo> observer)
        {
            NewMail += observer.Update;
        }

        /// <summary>
        /// Notifies all observers.
        /// </summary>
        protected virtual void Notify(WeatherInfo info)
        {
            NewMail?.Invoke(this, info);
        }

        /// <summary>
        /// Notifies all observers.
        /// </summary>
        void IObservable<WeatherInfo>.Notify(WeatherInfo info)
        {
            Notify(info);
        }
    }
}