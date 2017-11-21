using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public List<Account> lstAccounts = new List<Account>();

        public Admin()
        {
            InitializeComponent();
            LoadList();
        }


        public void LoadList()
        {
            lstAccounts.Add(new Account() { PersoneelsNr = "1523", Voornaam = "Piet", Tussenvoegsel = "", Achternaam = "Meeresman", Woonplaats = "Eindhoven", Adres = "Florencelaan 43", Rol = "Planner" });
            lstAccounts.Add(new Account() { PersoneelsNr = "1386", Voornaam = "Erik", Tussenvoegsel = "van den", Achternaam = "Borg", Woonplaats = "Veldhoven", Adres = "Buizerd 170", Rol = "Chauffeur" });
            lstAccounts.Add(new Account() { PersoneelsNr = "1832", Voornaam = "Frans", Tussenvoegsel = "", Achternaam = "Keizer", Woonplaats = "Helmond", Adres = "Tivoli 14", Rol = "Chauffeur" });
            lstAccounts.Add(new Account() { PersoneelsNr = "1588", Voornaam = "Jan", Tussenvoegsel = "van", Achternaam = "Dongeren", Woonplaats = "Geldrop", Adres = "Gimli 6", Rol = "Chauffeur" });

            dgMedewerkers.ItemsSource = lstAccounts;
        }



        public class Account
        {
            public string PersoneelsNr { get; set; }
            public string Voornaam { get; set; }
            public string Tussenvoegsel { get; set; }
            public string Achternaam { get; set; }
            public string Woonplaats { get; set; }
            public string Adres { get; set; }
            public string Rol { get; set; }
        }

        private void btNieuw_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
