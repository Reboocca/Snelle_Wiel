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
        public static List<Pakbon> lstPakbonnen = new List<Pakbon>();

        public Homepage()
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
            Feedbackform fbform = new Feedbackform(((Pakbon)(lstInfo.SelectedItem)).PakbonNr, ((Pakbon)(lstInfo.SelectedItem)).OpAf, lstPakbonnen);
            await Navigation.PushAsync(fbform);
        }

        private void LoadList()
        {
            lstPakbonnen.Add(new Pakbon { PakbonNr = "1332", Straatnaam = "Firmamentlaan", Huisnummer = "3", Postcode = "5632 AA", Plaats = "Eindhoven", OpAf = "Op" });
            lstPakbonnen.Add(new Pakbon { PakbonNr = "1242", Straatnaam = "Boschdijk", Huisnummer = "372", Postcode = "5622 PB", Plaats = "Eindhoven", OpAf = "Op" });
            lstPakbonnen.Add(new Pakbon { PakbonNr = "1332", Straatnaam = "Italiëlaan", Huisnummer = "2", Postcode = "5632 TE", Plaats = "Eindhoven", OpAf = "Af" });
            lstPakbonnen.Add(new Pakbon { PakbonNr = "1242", Straatnaam = "Betuwelaan", Huisnummer = "7", Postcode = "5628 BM", Plaats = "Eindhoven", OpAf = "Af" });
            lstPakbonnen.Add(new Pakbon { PakbonNr = "1920", Straatnaam = "Bilderdijklaan", Huisnummer = "9", Postcode = "5611 NG", Plaats = "Eindhoven", OpAf = "Op" });
            lstPakbonnen.Add(new Pakbon { PakbonNr = "1920", Straatnaam = "Heezerweg", Huisnummer = "215", Postcode = "5643 KA", Plaats = "Eindhoven", OpAf = "Af" });

            lstInfo.ItemsSource = lstPakbonnen;
        }
    }
}