using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WinFormsweather.UseWeather
{
    /// <summary>
    ///     Основные параметры погоды
    /// </summary>
    internal class weather
    {
        /// <summary>
        ///     id weather
        /// </summary>
        public int id;
        /// <summary>
        ///     Основная информация погоды
        /// </summary>
        public string main;
        /// <summary>
        ///     Описание погоды
        /// </summary>
        public string description;
        /// <summary>
        /// Иконка погоды
        /// </summary>
        public string icon;
        /// <summary>
        ///     Настройка пути иконок для погоды
        /// </summary>
        public Bitmap Icon
        {
            get
            {
                return new Bitmap(Image.FromFile($"icons/{icon}.png"));
            }
        }
    }
}
