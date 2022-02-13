using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Library;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<City> cityList = new List<City>();
        const string API_Key = "ENTER YOUR API KEY HERE";
        int dateindex = 1;
        public MainWindow()
        {
            
            using (StreamReader r = new StreamReader("city.list.json"))
            {
                string json = r.ReadToEnd();
                cityList.AddRange(JsonConvert.DeserializeObject<List<City>>(json));
            }
            InitializeComponent();

        }
        private bool isCityValid()
        {
            return cityList.Any(x => x.name.ToLower().Equals(cityName.Text.ToLower()));
        }

        private void GetCurrentForecast_Click(object sender, RoutedEventArgs e)
        {
            if (isCityValid())
            {
                string query = $"http://api.openweathermap.org/data/2.5/weather?q={cityName.Text}&appid={API_Key}&units=metric";
                JObject response = JObject.Parse(new System.Net.WebClient().DownloadString(query));
                if (response.SelectToken("cod").ToString().Equals("200"))
                {
                    displayWeatherImage(Convert.ToInt32(response.SelectToken("weather[0].id").ToString()));
                    cityAndCountry.Content = response.SelectToken("name").ToString() + ", " + response.SelectToken("sys.country").ToString();
                    weatherTemp.Content = "Temperature: " + response.SelectToken("main.temp").ToString() + " °C";
                    weatherWind.Content = "Wind Speed: "+ response.SelectToken("wind.speed").ToString() + " m/s";
                    weatherDescription.Content = response.SelectToken("weather[0].description").ToString();
                    weatherDate.Content = String.Empty;
                    dateRight.Visibility = Visibility.Hidden;
                    dateLeft.Visibility = Visibility.Hidden;
                    this.UpdateLayout();
                }
                else if (response.SelectToken("cod").ToString().Equals("429"))
                {
                    MessageBox.Show("The account is temporary blocked due to exceeding the requests limitition.\nPlease try again later.");
                }
            }
            else
                MessageBox.Show("Enter a valid city name", "Error");
        }

        private void Get4DaysForecast_Click(object sender, RoutedEventArgs e)
        {
            if (isCityValid())
            {
                string namequery = $"http://api.openweathermap.org/data/2.5/weather?q={cityName.Text}&appid={API_Key}&units=metric";
                JObject nameresponse = JObject.Parse(new System.Net.WebClient().DownloadString(namequery));
                if (nameresponse.SelectToken("cod").ToString().Equals("200"))
                {
                    cityAndCountry.Content = nameresponse.SelectToken("name").ToString() + ", " + nameresponse.SelectToken("sys.country").ToString();
                    int index = cityList.FindIndex(x => x.name.ToLower().Equals(cityName.Text.ToLower()));
                    string lat = cityList[index].coord.lat.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    string lon = cityList[index].coord.lon.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    string query = $"http://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&exclude=current,minutely,hourly,alerts&appid={API_Key}&units=metric";
                    JObject response = JObject.Parse(new System.Net.WebClient().DownloadString(query));
                    displayWeatherImage(Convert.ToInt32(response.SelectToken($"daily[{dateindex}].weather[0].id").ToString()));
                    weatherTemp.Content = "Day: " + response.SelectToken($"daily[{dateindex}].temp.day").ToString() + " °C, " + "Night: " + response.SelectToken($"daily[{dateindex}].temp.night").ToString() + " °C";
                    weatherWind.Content = "Wind Speed: " + response.SelectToken($"daily[{dateindex}].wind_speed").ToString() + " m/s";
                    weatherDescription.Content = response.SelectToken($"daily[{dateindex}].weather[0].description").ToString();
                    long time = long.Parse(response.SelectToken($"daily[{dateindex}].dt").ToString());
                    DateTimeOffset date = DateTimeOffset.FromUnixTimeSeconds(time);
                    weatherDate.Content = "Date: " + date.ToString("dd.MM.yyyy");
                    if (dateindex >= 1 && dateindex < 4)
                        dateRight.Visibility = Visibility.Visible;
                    if (dateindex > 1 && dateindex <= 4)
                        dateLeft.Visibility = Visibility.Visible;
                    this.UpdateLayout();
                }
                else if (nameresponse.SelectToken("cod").ToString().Equals("429"))
                {
                    MessageBox.Show("The account is temporary blocked due to exceeding the requests limitition.\nPlease try again later.");
                }

            }
            else
                MessageBox.Show("Enter a valid city name", "Error");
        }

        private void displayWeatherImage(int weatherId)
        {
            BitmapImage image = new BitmapImage();
            if (weatherId >= 200 && weatherId <= 232)
            {
                image = new BitmapImage(new Uri("icons/11d.png", UriKind.Relative));
            }
            else if ((weatherId >= 300 && weatherId <= 321) || (weatherId >= 520 && weatherId <= 531))
            {
                image = new BitmapImage(new Uri("icons/09d.png", UriKind.Relative));
            }
            else if (weatherId >= 500 && weatherId <= 504)
            {
                image = new BitmapImage(new Uri("icons/10d.png", UriKind.Relative));
            }
            else if (weatherId == 511 || (weatherId >= 600 && weatherId <= 622))
            {
                image = new BitmapImage(new Uri("icons/13d.png", UriKind.Relative));
            }
            else if (weatherId >= 700 && weatherId <= 781)
            {
                image = new BitmapImage(new Uri("icons/50d.png", UriKind.Relative));
            }
            else if (weatherId == 800)
            {
                image = new BitmapImage(new Uri("icons/01d.png", UriKind.Relative));
            }
            else if (weatherId == 801)
            {
                image = new BitmapImage(new Uri("icons/02d.png", UriKind.Relative));
            }
            else if (weatherId == 802)
            {
                image = new BitmapImage(new Uri("icons/03d.png", UriKind.Relative));
            }
            else if (weatherId == 803 || weatherId == 804)
            {
                image = new BitmapImage(new Uri("icons/04d.png", UriKind.Relative));
            }
            icon.Source = image;
        }

        private void dateRight_Click(object sender, RoutedEventArgs e)
        {
            if (isCityValid())
            {
                string namequery = $"http://api.openweathermap.org/data/2.5/weather?q={cityName.Text}&appid={API_Key}&units=metric";
                JObject nameresponse = JObject.Parse(new System.Net.WebClient().DownloadString(namequery));
                if (nameresponse.SelectToken("cod").ToString().Equals("200"))
                {
                    dateindex++;
                    cityAndCountry.Content = nameresponse.SelectToken("name").ToString() + ", " + nameresponse.SelectToken("sys.country").ToString();
                    int index = cityList.FindIndex(x => x.name.ToLower().Equals(cityName.Text.ToLower()));
                    string lat = cityList[index].coord.lat.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    string lon = cityList[index].coord.lon.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    string query = $"http://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&exclude=current,minutely,hourly,alerts&appid={API_Key}&units=metric";
                    JObject response = JObject.Parse(new System.Net.WebClient().DownloadString(query));
                    displayWeatherImage(Convert.ToInt32(response.SelectToken($"daily[{dateindex}].weather[0].id").ToString()));
                    weatherTemp.Content = "Day: " + response.SelectToken($"daily[{dateindex}].temp.day").ToString() + " °C, " + "Night: " + response.SelectToken($"daily[{dateindex}].temp.night").ToString() + " °C";
                    weatherWind.Content = "Wind Speed: " + response.SelectToken($"daily[{dateindex}].wind_speed").ToString() + " m/s";
                    weatherDescription.Content = response.SelectToken($"daily[{dateindex}].weather[0].description").ToString();
                    long time = long.Parse(response.SelectToken($"daily[{dateindex}].dt").ToString());
                    DateTimeOffset date = DateTimeOffset.FromUnixTimeSeconds(time);
                    weatherDate.Content = "Date: " + date.ToString("dd.MM.yyyy");
                    dateLeft.Visibility = Visibility.Visible;
                    if (dateindex >= 4)
                        dateRight.Visibility = Visibility.Hidden;
                    this.UpdateLayout();
                }
                else if (nameresponse.SelectToken("cod").ToString().Equals("429"))
                {
                    MessageBox.Show("The account is temporary blocked due to exceeding the requests limitition.\nPlease try again later.");
                }
            }
            else
                MessageBox.Show("Enter a valid city name", "Error");
        }
    

        private void dateLeft_Click(object sender, RoutedEventArgs e)
        {
            if (isCityValid())
            {
                string namequery = $"http://api.openweathermap.org/data/2.5/weather?q={cityName.Text}&appid={API_Key}&units=metric";
                JObject nameresponse = JObject.Parse(new System.Net.WebClient().DownloadString(namequery));
                if (nameresponse.SelectToken("cod").ToString().Equals("200"))
                {
                    dateindex--;
                    cityAndCountry.Content = nameresponse.SelectToken("name").ToString() + ", " + nameresponse.SelectToken("sys.country").ToString();
                    int index = cityList.FindIndex(x => x.name.ToLower().Equals(cityName.Text.ToLower()));
                    string lat = cityList[index].coord.lat.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    string lon = cityList[index].coord.lon.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    string query = $"http://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&exclude=current,minutely,hourly,alerts&appid={API_Key}&units=metric";
                    JObject response = JObject.Parse(new System.Net.WebClient().DownloadString(query));
                    displayWeatherImage(Convert.ToInt32(response.SelectToken($"daily[{dateindex}].weather[0].id").ToString()));
                    weatherTemp.Content = "Day: " + response.SelectToken($"daily[{dateindex}].temp.day").ToString() + " °C, " + "Night: " + response.SelectToken($"daily[{dateindex}].temp.night").ToString() + " °C";
                    weatherWind.Content = "Wind Speed: " + response.SelectToken($"daily[{dateindex}].wind_speed").ToString() + " m/s";
                    weatherDescription.Content = response.SelectToken($"daily[{dateindex}].weather[0].description").ToString();
                    long time = long.Parse(response.SelectToken($"daily[{dateindex}].dt").ToString());
                    DateTimeOffset date = DateTimeOffset.FromUnixTimeSeconds(time);
                    weatherDate.Content = "Date: " + date.ToString("dd.MM.yyyy");
                    dateRight.Visibility = Visibility.Visible;
                    if (dateindex <= 1)
                        dateLeft.Visibility = Visibility.Hidden;
                    this.UpdateLayout();

                }
                else if (nameresponse.SelectToken("cod").ToString().Equals("429"))
                {
                    MessageBox.Show("The account is temporary blocked due to exceeding the requests limitition.\nPlease try again later.");
                }
            }
            else
                MessageBox.Show("Enter a valid city name", "Error");
        }
    }
}
