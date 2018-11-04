using System;

namespace ObserverPatternDemo.Implemantation.Observable
{
    /// <summary>
    /// Weather information.
    /// </summary>
    public class WeatherInfo : EventInfo, ICloneable
    {
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }

        /// <summary>
        /// Initializes object's fields.
        /// </summary>
        public WeatherInfo(int temperature, int humidity, int pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }

        object ICloneable.Clone() => Clone();

        /// <summary>
        /// Creates object's clone.
        /// </summary>
        /// <returns>New cloned object.</returns>
        public WeatherInfo Clone() => new WeatherInfo(Temperature, Humidity, Pressure);
    }
}