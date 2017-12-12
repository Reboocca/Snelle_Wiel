using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SNWL_VrachtwagenApp
{
    public partial class MainPage : ContentPage
    {
        Chauffeur chauffeur = new Chauffeur();

        public MainPage()
        {
            InitializeComponent();

            //Snel
            //tbUsername.Text = "e.borg";
            //tbPassword.Text = "123";

            imgLogo.Source = ImageSource.FromResource("SNWL_VrachtwagenApp.img.logo.png");
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            if(tbPassword.Text == "" || tbUsername.Text == "")
            {
                DisplayAlert("Melding", "Zorg ervoor dat beide invoervelden gevuld zijn", "Terug");
            }
            else
            {
                btnLogin.IsEnabled = false;
                checklogin();
            }
        }

        private async void checklogin()
        {

            try
            {
                string webadres = "https://hobbithole.000webhostapp.com/snwl/login_vrachtwagen.php?user=" + tbUsername.Text + "&pwd=" + tbPassword.Text;
                HttpClient connect = new HttpClient();
                HttpResponseMessage logincheck = await connect.GetAsync(webadres);
                // gebruik eventueel PostAsync
                logincheck.EnsureSuccessStatusCode();

                string login = await logincheck.Content.ReadAsStringAsync();

                if (login != "false")
                {
                    chauffeur.id = login;
                    Navigate();
                }
                else
                {
                    await DisplayAlert("Foutmelding", "Gebruikersnaam of wachtwoord is onjuist.", "terug");
                    btnLogin.IsEnabled = true;
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Foutmelding", "Kan geen verbinding maken met de database, check uw internet verbinding of neem contact op met een beheerder.", "terug");
                btnLogin.IsEnabled = true;
            }
            
        }

        private async void Navigate()
        {
            Homepage home = new Homepage(chauffeur);
            await Navigation.PushAsync(home);

            btnLogin.IsEnabled = true;
        }
    }
}

