using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SNWL_VrachtwagenApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Homepage : ContentPage
    {
        public static List<Pakbon> lstPakbonnen = new List<Pakbon>();
        Chauffeur chauffeur = new Chauffeur();

        public Homepage(Chauffeur chauff)
        {
            InitializeComponent();

            chauffeur = chauff;

            LoadList();
        }

        private void lstInfo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigate();
        }

        private async void Navigate()
        {
            Feedbackform fbform = new Feedbackform(((Pakbon)(lstInfo.SelectedItem)).PakbonNr, ((Pakbon)(lstInfo.SelectedItem)).OpAf, lstPakbonnen, chauffeur);
            await Navigation.PushAsync(fbform);
        }

        private async void LoadList()
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy".Replace("/","-"));

            lstPakbonnen = await GetPakbonnen.getPakbonlist(chauffeur.id, date);

            if(lstPakbonnen.Count == 0)
            {
                lbGeenPakbon.IsVisible = true;
            }

            lstInfo.ItemsSource = lstPakbonnen;
            aiLoading.IsRunning = false;
        }

        //code van: https://stackoverflow.com/questions/32163471/confirmation-dialog-on-back-button-press-event-xamarin-forms voor terugknop
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Melding", "Weet u zeker dat u wilt uitloggen?", "Ja", "Nee");
                if (result)
                {
                    //Uitloggen
                    lstPakbonnen.Clear();
                    lstInfo.ItemsSource = null;
                    lbGeenPakbon.IsVisible = false;

                    MainPage login = new MainPage();
                    await Navigation.PushAsync(login);
                }

            });

            return true;
        }
    }

}
