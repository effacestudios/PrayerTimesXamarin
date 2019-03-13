using Newtonsoft.Json;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Mussalman
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

   

        private void AutoDet_Clicked(object sender, EventArgs e)
        {
            var client = new WebClient();


            var text = client.DownloadString("http://api.aladhan.com/v1/timingsByCity?city="+City.Text+"&country="+Country.Text);

            RootObject result = JsonConvert.DeserializeObject<RootObject>(text);

            Fajrbox.Text = result.data.timings.Fajr;
            Sunrisebox.Text = result.data.timings.Sunrise;
            Zuhrbox.Text = result.data.timings.Dhuhr;
            Asrbox.Text = result.data.timings.Asr;
            Sunsetbox.Text = result.data.timings.Sunset;
            MaghribBox.Text = result.data.timings.Maghrib;
            Ishabox.Text = result.data.timings.Isha;
            Imsakbox.Text = result.data.timings.Imsak;
            midnightbox.Text = result.data.timings.Midnight;

            TitleTxt.Text = "Prayer Timings for " + City.Text + ", " + Country.Text + ":";
        }

    }
}
