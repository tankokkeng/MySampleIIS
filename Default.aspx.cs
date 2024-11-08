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
                GetParkingAvailability().Wait();
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

        private async Task GetParkingAvailability()
        {
            string apiUrl = "https://api.data.gov.sg/v1/transport/carpark-availability";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string parkingData = await response.Content.ReadAsStringAsync();
                    dynamic parkingJson = Newtonsoft.Json.JsonConvert.DeserializeObject(parkingData);
                    foreach (var carpark in parkingJson.items.carpark_data)
                    {
                        if (carpark.carpark_info.carpark_number == "PLAZA_SINGAPURA")
                        {
                            lblParking.Text = $"Available Lots: {carpark.carpark_info.lots_available}";
                            break;
                        }
                    }
                }
                else
                {
                    lblParking.Text = "Unable to retrieve parking data.";
                }
            }
        }
    }
}
