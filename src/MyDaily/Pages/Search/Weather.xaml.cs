using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MyDaily.Procy.WeatherProcy;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyDaily.Pages.Search {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Weather : Page {
        public Weather() {
            this.InitializeComponent();
            showWeather("guangzhou");
        }
        private async void showWeather(string city) {
            RootObject wNext = await WeatherProcy.GetWeather(city);

            City.Text = wNext.results[0].location.name;
            TodayDate.Text = wNext.results[0].daily[0].date;
            TodayTemp.Text = wNext.results[0].daily[0].low + "℃ ~ " + wNext.results[0].daily[0].high + "℃";
            TodayText.Text = wNext.results[0].daily[0].text_day;
            TodayWind.Text = wNext.results[0].daily[0].wind_direction + "风 " + wNext.results[0].daily[0].wind_scale + " 级";
            TodayImage.Source = new BitmapImage(new Uri("ms-appx://Weather/Assets/Weather/" + wNext.results[0].daily[0].code_day + ".png"));

            Text1.Text = wNext.results[0].daily[1].text_day;
            Text2.Text = wNext.results[0].daily[2].text_day;

            Date1.Text = wNext.results[0].daily[1].date;
            Date2.Text = wNext.results[0].daily[2].date;

            Temp1.Text = wNext.results[0].daily[1].low + "℃ ~ " + wNext.results[0].daily[1].high + "℃";
            Temp2.Text = wNext.results[0].daily[2].low + "℃ ~ " + wNext.results[0].daily[2].high + "℃";

            Day1.Source = new BitmapImage(new Uri("ms-appx://Weather/Assets/Weather/" + wNext.results[0].daily[1].code_day + ".png"));
            Day2.Source = new BitmapImage(new Uri("ms-appx://Weather/Assets/Weather/" + wNext.results[0].daily[2].code_day + ".png"));
        }

        private void search_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args) {
            string key = search.Text;
            showWeather(key);
        }
    }
}
