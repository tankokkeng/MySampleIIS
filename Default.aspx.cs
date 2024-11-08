using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;

namespace YourNamespace
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTime.Text = DateTime.Now.ToString("F");
                GetWeather().Wait();
            }
        }

        private async Task GetWeather()
        {
            string apiKey = "YOUR_API_KEY";
            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q=Singapore&appid={apiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string weatherData = await response.Content.ReadAsStringAsync();
                    dynamic weatherJson = Newtonsoft.Json.JsonConvert.DeserializeObject(weatherData);
                    lblWeather.Text = $"{weatherJson.weather.description}, {weatherJson.main.temp}°C";
                }
                else
                {
                    lblWeather.Text = "Unable to retrieve weather data.";
                }
            }
        }
    }
}
