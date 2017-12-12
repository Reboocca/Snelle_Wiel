using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        private string opaf { get; set; }
        Chauffeur chauffeur = new Chauffeur();

        private List<Pakbon> lstpakbonnen { get; set; }

        public string sLat { get; set; }
        public string sLong { get; set; }
        public string sMap { get; set; }
        public string sStraat { get; set; }
        public string sHuisnr { get; set; }
        public string sWoonplaats { get; set; }
        public string sPostcode { get; set; }

        public Feedbackform(string PakbonNr, string OpAf, List<Pakbon> lstPakbonnen, Chauffeur chauff)
        {
            InitializeComponent();

            pakbonnr = PakbonNr;
            opaf = OpAf;
            lstpakbonnen = lstPakbonnen;
            chauffeur = chauff;

           

            getInfoPakbon();
            getCurrentLocation();

            btnRoute.IsEnabled = false;
        }

        private void getInfoPakbon()
        {
            
            foreach (Pakbon p in lstpakbonnen)
            {
                if(p.PakbonNr == pakbonnr && p.OpAf == opaf)
                {
                    sStraat = p.Straatnaam;
                    sHuisnr = p.Huisnummer;
                    sWoonplaats = p.Plaats;
                    sPostcode = p.Postcode;
                }
            }
            if(opaf == "Op")
            {
                lbAdrestitel.Text = "Ophaaladres";
            }
            else if(opaf == "Af")
            {
                lbAdrestitel.Text = "Leveradres";
            }
            lbStraatnummer.Text = sStraat + " " + sHuisnr;
            lbPostPlaats.Text = sPostcode + " " + sWoonplaats;
        }

        private async void getCurrentLocation()
        {
            try
            {
                //code van: https://gist.github.com/nuitsjp/44ecb3954bb19779633932ee045bce8d, on de huidige locatie op te slaan in lat en long
                var location = CrossGeolocator.Current;
                var currentposition = await location.GetPositionAsync();

                sLat = currentposition.Latitude.ToString();
                sLong = currentposition.Longitude.ToString();
            }
            catch (Exception)
            {
                DisplayAlert("Foutmelding", "De applicatie heeft geen toegang tot uw locatie, u wordt teruggestuurd naar de vorige pagina", "Ok");
                Homepage home = new Homepage(chauffeur);
                await Navigation.PushAsync(home);
                throw;
            }
           

            //Zorg dat de gebruiker alleen de route op google maps kan bekijken wanneer de lat en long berekend zijn
            btnRoute.IsEnabled = true;

            //Url map voor de image met de juiste parameters
            sMap = "https://maps.googleapis.com/maps/api/staticmap?size=500x310&maptype=roadmap&markers=color:blue%7Clabel:S%7C" + sLat + "," + sLong + "&markers=color:green%7Clabel:E%7C " + sStraat + "+" + sHuisnr + "+" + sWoonplaats + "&path=color:0xe73c04|weight:2|" + sLat + "," + sLong + "|" + sStraat + " + " + sHuisnr + " + " + sWoonplaats + "&feature:road&key=AIzaSyCQasg9DVOSD4ENYi-i9mcdMWwSVm5qMNw";

            LoadMap();
        }

        private void LoadMap()
        {
            imgMap.Source = ImageSource.FromUri(new Uri(sMap));
        }

        private void btnRoute_Clicked(object sender, EventArgs e)
        {
            //code van: https://stackoverflow.com/questions/39781475/xamarin-forms-maps-is-possible-to-call-google-maps-from-a-button
            var uri = new Uri("http://maps.google.com/maps?saddr=" + sLat + "," + sLong +  "&daddr=" + sStraat + "+" + sHuisnr + "+" + sWoonplaats + "&directionsmode=transit");
            Device.OpenUri(uri);
        }

        private void btnGeslaagd_Clicked(object sender, EventArgs e)
        {
            Voltooid(true);
        }

        private void btnMislukt_Clicked(object sender, EventArgs e)
        {
            if(tbOpmerking.Text == null)
            {
                DisplayAlert("Let op", "Wanneer de opdracht niet geslaagd is, dient u een opmerking in te voeren", "Terug");
            }
            else
            {
                Voltooid(false);
            }
            
        }

        private async void Voltooid(bool resultaat)
        {
            //functie voor het opslaan van het resultaat
            string status;
            if (resultaat)
            {
                status = "Geslaagd";
            }
            else
            {
                status = "Mislukt";
            }

            try
            {
                string webadres = "https://hobbithole.000webhostapp.com/snwl/update_feedback.php?pakbon=" + pakbonnr + "&status=" + status + "&opmerking=" + tbOpmerking.Text;
                HttpClient connect = new HttpClient();
                HttpResponseMessage updatetable = await connect.GetAsync(webadres);
                // gebruik eventueel PostAsync
                updatetable.EnsureSuccessStatusCode();

                string result = await updatetable.Content.ReadAsStringAsync();

                if (result == "true")
                {
                    await DisplayAlert("Succes", "Het is opgeslagen in de database en u wordt nu teruggestuurd naar de vorige pagina.", "ok");

                    Homepage home = new Homepage(chauffeur);
                    await Navigation.PushAsync(home);
                }
                else
                {
                    await DisplayAlert("Foutmelding", "De feedback is niet opgeslagen, probeerh het opnieuw of contacteer een beheerder.", "terug");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Foutmelding", "Kan geen verbinding maken met de database, check uw internet verbinding of neem contact op met een beheerder.", "terug");
                
            }

        }
    }
}