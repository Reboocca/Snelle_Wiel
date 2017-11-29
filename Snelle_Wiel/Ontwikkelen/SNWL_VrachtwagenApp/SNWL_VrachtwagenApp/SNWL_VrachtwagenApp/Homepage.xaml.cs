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
	public partial class Homepage : ContentPage
	{
        List<Pakbon> lstPakbonnen = new List<Pakbon>();

		public Homepage ()
		{
			InitializeComponent();

            LoadList();
        }

        private void lstInfo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigate();
        }

        private async void Navigate()
        {
            Feedbackform fbform = new Feedbackform("1332");
            await Navigation.PushAsync(fbform);

            //Feedbackform fbform = new Feedbackform(((Pakbon)(lstInfo.SelectedItem)).PakbonNr.ToString());
            //await Navigation.PushAsync(fbform);
        }

        private void LoadList()
        {
            lstPakbonnen.Add(new Pakbon { PakbonNr = "1332", Straatnaam = "Firmamentlaan", Huisnummer = "3", Postcode = "5632AA", Plaats = "Eindhoven", OpAf = "Op" });
            lstPakbonnen.Add(new Pakbon { PakbonNr = "1332", Straatnaam = "Firmamentlaan", Huisnummer = "3", Postcode = "5632AA", Plaats = "Eindhoven", OpAf = "Op" });
            lstPakbonnen.Add(new Pakbon { PakbonNr = "1332", Straatnaam = "Firmamentlaan", Huisnummer = "3", Postcode = "5632AA", Plaats = "Eindhoven", OpAf = "Op" });
            lstPakbonnen.Add(new Pakbon { PakbonNr = "1332", Straatnaam = "Firmamentlaan", Huisnummer = "3", Postcode = "5632AA", Plaats = "Eindhoven", OpAf = "Op" });
            lstPakbonnen.Add(new Pakbon { PakbonNr = "1332", Straatnaam = "Firmamentlaan", Huisnummer = "3", Postcode = "5632AA", Plaats = "Eindhoven", OpAf = "Op" });
            lstPakbonnen.Add(new Pakbon { PakbonNr = "1332", Straatnaam = "Firmamentlaan", Huisnummer = "3", Postcode = "5632AA", Plaats = "Eindhoven", OpAf = "Op" });

            lstInfo.ItemsSource = lstPakbonnen;
        }
    }
}