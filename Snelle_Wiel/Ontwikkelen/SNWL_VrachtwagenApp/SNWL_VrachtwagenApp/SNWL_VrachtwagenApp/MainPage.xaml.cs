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
        }
    }
}
