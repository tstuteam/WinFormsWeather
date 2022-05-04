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
            label3.Text = "������� ����������� (�C): ";
            label4.Text = "�������� (�/�): ";
            label5.Text = "����������� �: ";
            label6.Text = "��������� (%): ";
            label7.Text = "�������� (��): ";

        }

        /// <summary>
        ///     ����������� ������ ��� �������� �� ���� ����� �������� ������
        /// </summary>
        /// <param name="City">�����</param>
        /// <param name="key">���� Json</param>
        /// <returns>������ �� Json</returns>
        private static WebRequest NewJson(string city, string key)
        {
            //  ���������� Json
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
            //  �����
            string city = selectedState;
            //  ���� ��� Json
            string Key = "166bc89c9edeb7a0e90cc18bf9fe8861";
            //  ���������� Json
            // WebRequest request = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=Moscow&appid=166bc89c9edeb7a0e90cc18bf9fe8861");
            WebRequest request = NewJson(city, Key);
            request.ContentType = "application/x-www-urlencoded";

            //  ����� ���� ���������� "async"
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

            //  Json ��� �� �����
            richTextBox1.Text = answer;
            //  �������������� � �����
            UseWeather.UseWeather useWeather = JsonConvert.DeserializeObject<UseWeather.UseWeather>(answer);

            //  ���������� ������
            panel1.BackgroundImage = useWeather.weather[0].Icon;
            label1.Text = useWeather.weather[0].main;
            label2.Text = useWeather.weather[0].description;
            label3.Text = "������� ����������� (�C): " + useWeather.main.temp.ToString("0.##");//���������� �������
            label4.Text = "�������� (�/�): " + useWeather.wind.speed.ToString();
            label5.Text = "����������� �: " + useWeather.wind.deg.ToString();
            label6.Text = "��������� (%): " + useWeather.main.humidity.ToString();
            label7.Text = "�������� (��): " + ((int)useWeather.main.pressure).ToString();

        }
    }
}
