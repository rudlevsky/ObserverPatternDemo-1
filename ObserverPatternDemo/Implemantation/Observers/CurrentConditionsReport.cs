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

        /// <summary>
        /// Updates current report.
        /// </summary>
        /// <param name="data">New data for report.</param>
        public void Update(WeatherInfo data)
        {
            currentInfo = data;
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
                    return $"Temperature: {currentInfo.Temperature}, Humidity: {currentInfo.Humidity}, Pressure: {currentInfo.Pressure}";
                case "T":
                    return $"Temperature: {currentInfo.Temperature}";
                case "H":
                    return $"Humidity: {currentInfo.Humidity}";
                case "P":
                    return $"Pressure: {currentInfo.Pressure}";
                case "TH":
                    return $"Temperature: {currentInfo.Temperature}, Humidity: {currentInfo.Humidity}";
                case "HP":
                    return $"Humidity: {currentInfo.Humidity}, Pressure: {currentInfo.Pressure}";
                case "TP":
                    return $"Temperature: {currentInfo.Temperature}, Pressure: {currentInfo.Pressure}";
                default:
                    throw new FormatException(string.Format("The {0} format string is not supported.", format));
            }
        }
    }
}