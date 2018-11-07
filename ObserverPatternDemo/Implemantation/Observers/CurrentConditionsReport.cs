using ObserverPatternDemo.Implemantation.Observable;
using System;
using System.Globalization;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// Class creates current report.
    /// </summary>
    public class CurrentConditionsReport : IObserver<WeatherInfo>, IFormattable
    {
        private WeatherInfo currentInfo;
        private string senderName;

        /// <summary>
        /// Updates current report.
        /// </summary>
        /// <param name="data">New data for report.</param>
        public void Update(object obj, WeatherInfo data)
        {
            currentInfo = data;
            senderName = obj.ToString();
        }

        /// <summary>
        /// Registers a subscriber.
        /// </summary>
        /// <param name="weather">Object for registration.</param>
        public void Register(WeatherData weather)
        {
            weather.NewMail += Update;
        }

        /// <summary>
        /// Unregisters a subscriber.
        /// </summary>
        /// <param name="weather">Object for unregistration.</param>
        public void UnRegister(WeatherData weather)
        {
            weather.NewMail -= Update;
        }

        /// <summary>
        /// Creates string representation of the current report.
        /// </summary>
        /// <returns>String representation of the current report.</returns>
        public string GetReport() => ToString();

        /// <summary>
        /// Creates string representation of the current report.
        /// </summary>
        /// <returns>String representation of the current report.</returns>
        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        /// <summary>
        /// Creates string representation of the current report according format.
        /// </summary>
        /// <param name="format">Format for creating string report.</param>
        /// <returns>String representation of the current report in the nessesary format.</returns>
        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

        /// <summary>
        /// Creates string representation of the current report according format.
        /// </summary>
        /// <param name="format">Format for creating string report.</param>
        /// <param name="provider">Provider for creating string representation.</param>
        /// <returns>String representation of the current report in the nessesary format.</returns>
        public string ToString(string format, IFormatProvider provider)
        {
            if (currentInfo == null)
            {
                throw new ArgumentNullException($"{nameof(currentInfo)} was null.");
            }

            if (string.IsNullOrEmpty(format))
            {
                format = "G";
            }

            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "THP":
                    return $"Sender: {senderName}, Temperature: {currentInfo.Temperature}, Humidity: {currentInfo.Humidity}, Pressure: {currentInfo.Pressure}";
                case "T":
                    return $"Sender: {senderName}, Temperature: {currentInfo.Temperature}";
                case "H":
                    return $"Sender: {senderName}, Humidity: {currentInfo.Humidity}";
                case "P":
                    return $"Sender: {senderName}, Pressure: {currentInfo.Pressure}";
                case "TH":
                    return $"Sender: {senderName}, Temperature: {currentInfo.Temperature}, Humidity: {currentInfo.Humidity}";
                case "HP":
                    return $"Sender: {senderName}, Humidity: {currentInfo.Humidity}, Pressure: {currentInfo.Pressure}";
                case "TP":
                    return $"Sender: {senderName}, Temperature: {currentInfo.Temperature}, Pressure: {currentInfo.Pressure}";
                default:
                    throw new FormatException(string.Format("The {0} format string is not supported.", format));
            }
        }
    }
}