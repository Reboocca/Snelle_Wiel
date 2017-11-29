using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SNWL_VrachtwagenApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            imgLogo.Source = ImageSource.FromResource("SNWL_VrachtwagenApp.img.logo.png");

            //Even snel voor testen
            Navigate();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigate();
        }

        private async void Navigate()
        {
            Homepage home = new Homepage();
            await Navigation.PushAsync(home);
        }
    }
}
