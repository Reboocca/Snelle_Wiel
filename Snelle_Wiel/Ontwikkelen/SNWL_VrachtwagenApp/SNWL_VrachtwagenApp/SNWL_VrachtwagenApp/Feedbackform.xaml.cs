using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SNWL_VrachtwagenApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Feedbackform : ContentPage
	{
        private string pakbonnr { get; set; }
        public string sLat { get; set; }
        public string sLong { get; set; }
        public string sMap { get; set; }
        public string sStraat { get; set; }
        public string sHuisnr { get; set; }
        public string sWoonplaats { get; set; }

        public Feedbackform (string PakbonNr)
		{
			InitializeComponent ();
            pakbonnr = PakbonNr;

            getCurrentLocation();
            LoadMap();            
        }

        private async void getCurrentLocation()
        {
            //code van: https://gist.github.com/nuitsjp/44ecb3954bb19779633932ee045bce8d
            var location = CrossGeolocator.Current;
            var currentposition = await location.GetPositionAsync();

            sLat = currentposition.Latitude.ToString();
            sLong = currentposition.Longitude.ToString();

            sStraat = "Firmamentlaan";
            sHuisnr = "3";
            sWoonplaats = "Eindhoven";
            sMap = "https://maps.googleapis.com/maps/api/staticmap?600x400&maptype=terrain&markers=color:blue%7Clabel:S%7C" + sLat + "," + sLong + "&markers=color:green%7Clabel:E%7C "+ sStraat + "+" + sHuisnr + "+" + sWoonplaats + "&key=AIzaSyCQasg9DVOSD4ENYi-i9mcdMWwSVm5qMNw";
        }

        private void LoadMap()
        {
            //imgMap.Source = ImageSource.FromUri(new Uri("https://maps.googleapis.com/maps/api/staticmap?600x400&maptype=roadmap&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyCQasg9DVOSD4ENYi-i9mcdMWwSVm5qMNw"));
            imgMap.Source = ImageSource.FromUri(new Uri(sMap));
        }

    }
}