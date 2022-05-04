using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;


namespace WinFormsweather
{
    public partial class Form1 : Form
    {
        public string selectedState;

        public Form1()
        {
            InitializeComponent();

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }


        private async void Form1_Load_1(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[] { "Moscow", "Tver", "London" });


            //WebRequest request = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=Moscow&appid=166bc89c9edeb7a0e90cc18bf9fe8861");

            //request.ContentType = "application/x-www-urlencoded";
            //WebResponse response = await request.GetResponseAsync();
            //string answer = string.Empty;

            //using (Stream stream = response.GetResponseStream())
            //{
            //    using (StreamReader reader = new StreamReader(stream))
            //    {
            //        answer = await reader.ReadToEndAsync();
            //    }
            //}
            //response.Close();

            //richTextBox1.Text = answer;

            //UseWeather.UseWeather useWeather = JsonConvert.DeserializeObject<UseWeather.UseWeather>(answer);

            //panel1.BackgroundImage = useWeather.weather[0].Icon;
            //label1.Text = useWeather.weather[0].main;
            //label2.Text = useWeather.weather[0].description;
            label3.Text = "Средняя температура (°C): ";
            label4.Text = "Скорость (м/с): ";
            label5.Text = "Направление °: ";
            label6.Text = "Влажность (%): ";
            label7.Text = "Давление (мм): ";

        }

        /// <summary>
        ///     Конструктор ссылки для отправки на сайт чтобы получить данные
        /// </summary>
        /// <param name="City">Город</param>
        /// <param name="key">Ключ Json</param>
        /// <returns>Ссылка на Json</returns>
        private static WebRequest NewJson(string city, string key)
        {
            //  коструктор Json
            string rez1 = "https://api.openweathermap.org/data/2.5/weather?q=";
            string rez2 = "&appid=";
            string rez = rez1 + city + rez2 + key;
            /// https://api.openweathermap.org/data/2.5/weather?q=Moscow&appid=166bc89c9edeb7a0e90cc18bf9fe8861
            WebRequest request = WebRequest.Create(rez);
            return request;
        }


        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedState = comboBox1.SelectedItem.ToString();
            if (selectedState == null)
            {
                selectedState = comboBox1.Items[0].ToString();
            }
            //  Город
            string city = selectedState;
            //  ключ для Json
            string Key = "166bc89c9edeb7a0e90cc18bf9fe8861";
            //  коструктор Json
            // WebRequest request = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=Moscow&appid=166bc89c9edeb7a0e90cc18bf9fe8861");
            WebRequest request = NewJson(city, Key);
            request.ContentType = "application/x-www-urlencoded";

            //  Дожен быть асинхроным "async"
            WebResponse response = await request.GetResponseAsync();
            string answer = string.Empty;

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }
            response.Close();

            //  Json код из сайта
            richTextBox1.Text = answer;
            //  Преоброзование в класс
            UseWeather.UseWeather useWeather = JsonConvert.DeserializeObject<UseWeather.UseWeather>(answer);

            //  Заполнение Данных
            panel1.BackgroundImage = useWeather.weather[0].Icon;
            label1.Text = useWeather.weather[0].main;
            label2.Text = useWeather.weather[0].description;
            label3.Text = "Средняя температура (°C): " + useWeather.main.temp.ToString("0.##");//перегрузка формата
            label4.Text = "Скорость (м/с): " + useWeather.wind.speed.ToString();
            label5.Text = "Направление °: " + useWeather.wind.deg.ToString();
            label6.Text = "Влажность (%): " + useWeather.main.humidity.ToString();
            label7.Text = "Давление (мм): " + ((int)useWeather.main.pressure).ToString();

        }
    }
}
