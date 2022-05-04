using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsweather.UseWeather
{
    /// <summary>
    ///     Группа параметров погоды
    /// </summary>
    internal class main
    {
        private double _temp;
        /// <summary>
        ///     температура в С
        /// </summary>
        public double temp
        {
            get
            {
                return _temp;
            }
            set
            {
                _temp = value - 273.15; //получаем цельсии
            }
        }

        private double _pressure;

        /// <summary>
        ///     Ртутный столб
        /// </summary>
        public double pressure
        {
            get
            {
                return _pressure;
            }
            set
            {
                _pressure = value / 1.3332239;
            }
        }
        /// <summary>
        ///     Влажность
        /// </summary>
        public double humidity;

        private double _temp_min;
        /// <summary>
        ///     Минимальная температура в данный момент. 
        ///     Это отклонение от текущей температуры, которая возможна для крупных городов и мегаполисов, географически расширенных
        /// </summary>
        public double temp_min
        {
            get
            {
                return _temp_min;
            }
            set
            {
                _temp_min = value - 273.15; //получаем цельсии
            }
        }
        private double _temp_max;
        /// <summary>
        ///     Максимальная температура на данный момент. 
        ///     Это отклонение от текущей температуры, которая возможна для крупных городов и мегаполисов, географически расширенных
        /// </summary>
        public double temp_max
        {
            get
            {
                return _temp_max;
            }
            set
            {
                _temp_max = value - 273.15; //получаем цельсии
            }
        }
    }
}
