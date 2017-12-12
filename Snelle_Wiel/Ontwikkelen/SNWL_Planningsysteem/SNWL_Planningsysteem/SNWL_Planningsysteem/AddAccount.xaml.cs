    using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SNWL_Planningsysteem
{
    /// <summary>
    /// Interaction logic for AddAccount.xaml
    /// </summary>
    public partial class AddAccount : Window
    {
        string sRijbewijs;
        public AddAccount()
        {
            InitializeComponent();
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            if( tbPersNr.Text == "" || tbUsername.Text == "" || tbWachtwoord.Text == "" || tbVoornaam.Text == "" || tbAchternaam.Text == "" || tbAdres.Text == "" || tbNummer.Text == "" || tbWoonplaats.Text == "")
            {
                MessageBox.Show("Zorg ervoor dat ieder veld ingevoerd is, voordat u het account opslaat", "Foutmelding");
            }
            else
            {
                if (cbRol.SelectedIndex == 0)
                {
                    CheckIDUsernamePlanner();
                }
                else if (cbRol.SelectedIndex == 1)
                {
                    CheckIDUsernameChauffeur();
                }
            }
            
        }

        private async void CheckIDUsernameChauffeur()
        {
            string webadres = "https://hobbithole.000webhostapp.com/snwl/check_uniek_id_username_chauffeur.php?id=" + tbPersNr.Text + " &uname=" + tbUsername.Text;
            HttpClient connect = new HttpClient();
            HttpResponseMessage check = await connect.GetAsync(webadres);
            // gebruik eventueel PostAsync
            check.EnsureSuccessStatusCode();

            string resultaat = await check.Content.ReadAsStringAsync(); ;

            switch (resultaat)
            {
                case "username_bestaat.id_bestaat":
                    MessageBox.Show("Het ingevoerde personeelsnummer en de gebruikersnaam bestaan al, voer iets anders in.", "Foutmelding");
                    break;
                case "username_bestaat.uniek":
                    MessageBox.Show("De ingevoerde gebruikersnaam bestaat al, voer iets anders in", "Foutmelding");
                    break;
                case "uniek.id_bestaat":
                    MessageBox.Show("Het ingevoerde personeelsnummer bestaat al, voer iets anders in.", "Foutmelding");
                    break;
                case "uniek.uniek":
                    SaveNewChauffeur();
                    break;
                default:
                    break;
            }
        }
        private async void CheckIDUsernamePlanner()
        {
            string webadres = "https://hobbithole.000webhostapp.com/snwl/check_uniek_id_username_planner.php?id=" + tbPersNr.Text + " &uname=" + tbUsername.Text;
            HttpClient connect = new HttpClient();
            HttpResponseMessage check = await connect.GetAsync(webadres);
            // gebruik eventueel PostAsync
            check.EnsureSuccessStatusCode();

            string resultaat = await check.Content.ReadAsStringAsync(); ;

            switch (resultaat)
            {
                case "username_bestaat.id_bestaat":
                    MessageBox.Show("Het ingevoerde personeelsnummer en de gebruikersnaam bestaan al, voer iets anders in.", "Foutmelding");
                    break;
                case "username_bestaat.uniek":
                    MessageBox.Show("De ingevoerde gebruikersnaam bestaat al, voer iets anders in", "Foutmelding");
                    break;
                case "uniek.id_bestaat":
                    MessageBox.Show("Het ingevoerde personeelsnummer bestaat al, voer iets anders in.", "Foutmelding");
                    break;
                case "uniek.uniek":
                    SaveNewPlanner();
                    break;
                default:
                    break;
            }
        }
        private async void SaveNewChauffeur()
        {
            IEnumerable<CheckBox> selectedBoxes =
            from checkbox in this.spRijbewijs.Children.OfType<CheckBox>()
            where checkbox.IsChecked.Value
            select checkbox;

            foreach (CheckBox cb in selectedBoxes)
            {
                sRijbewijs = sRijbewijs + " "  + cb.Content;
            }

            string webadres = "https://hobbithole.000webhostapp.com/snwl/save_new_chauffeur.php?id=" + tbPersNr.Text + "&uname=" + tbUsername.Text + "&pwd=" + tbWachtwoord.Text +  "&fname=" + tbVoornaam.Text + "&insrt=" + tbTussenvoegsel.Text + "&lname=" + tbAchternaam.Text + "&strname=" + tbAdres.Text +"&nr=" + tbNummer.Text +"&city=" + tbWoonplaats.Text + "&license=" + sRijbewijs;
            HttpClient connect = new HttpClient();
            HttpResponseMessage save = await connect.GetAsync(webadres);
            // gebruik eventueel PostAsync
            save.EnsureSuccessStatusCode();

            string resultaat = await save.Content.ReadAsStringAsync();

            if (resultaat == "success")
            {
                MessageBox.Show("Het account is succesvol aangemaakt.", "Succes");
                this.Close();
            }
            else
            {
                MessageBox.Show("Er is iets mis gegaan met het aanmaken van de werknemer, probeer het opnieuw of contacteer een beheerder.", "Foutmelding");
            }
        }

        private async void SaveNewPlanner()
        {
            string webadres = "https://hobbithole.000webhostapp.com/snwl/save_new_planner.php?id=" + tbPersNr.Text + "&uname=" + tbUsername.Text + "&pwd=" + tbWachtwoord.Text + "&fname=" + tbVoornaam.Text + "&insrt=" + tbTussenvoegsel.Text + "&lname=" + tbAchternaam.Text + "&strname=" + tbAdres.Text + "&nr=" + tbNummer.Text + "&city=" + tbWoonplaats.Text;
            HttpClient connect = new HttpClient();
            HttpResponseMessage save = await connect.GetAsync(webadres);
            // gebruik eventueel PostAsync
            save.EnsureSuccessStatusCode();

            string resultaat = await save.Content.ReadAsStringAsync();

            if(resultaat == "success")
            {
                MessageBox.Show("Het account is succesvol aangemaakt.", "Succes");
                this.Close();
            }
            else
            {
                MessageBox.Show("Er is iets mis gegaan met het aanmaken van de werknemer, probeer het opnieuw of contacteer een beheerder.", "Foutmelding");
            }
        }
    }
}
