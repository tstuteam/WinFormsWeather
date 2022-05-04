using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WinFormsweather.UseWeather
{
    /// <summary>
    /// Основной класс для Json
    /// </summary>
    internal class UseWeather
    {
        /// <summary>
        ///     координат
        /// </summary>
        public coord coord;
        /// <summary>
        ///     Основные параметры погоды
        /// </summary>
        public weather[] weather;

        [JsonProperty("base")]
        public string Base;
        /// <summary>
        ///     Группа параметров погоды
        /// </summary>
        public main main;
        /// <summary>
        ///     видимость
        /// </summary>
        public double visibility;
        /// <summary>
        ///     Ветер
        /// </summary>
        public wind wind;
        /// <summary>
        ///     облака
        /// </summary>
        public clouds clouds;

        /// <summary>
        ///     система
        /// </summary>
        public sys sys;

        public int id;
        /// <summary>
        /// Название города
        /// </summary>
        public string name;

        public double cod;

    }
}
