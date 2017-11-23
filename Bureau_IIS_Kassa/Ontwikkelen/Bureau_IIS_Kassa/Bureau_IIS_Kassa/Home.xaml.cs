using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Threading;

namespace Bureau_IIS_Kassa
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        dbs db = new dbs();

        double Totaalexcl;
        double Klantenkorting;
        double Totaalincl;
        double Totaalbtw;
        double Totaalinclbtw;

        List<artikelen> lst = new List<artikelen>();

        public Home()
        {
            InitializeComponent();
            //Haal de medewerker naam op
            LoadMedewerker();

            //Vult de datum en tijd in de label continu
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.lbDatum.Content = DateTime.Now.ToString();

            }, this.Dispatcher);

            DatatableLaden();

            Totaalexcl = 1456;
            Klantenkorting = 10;
            Totaalincl = Totaalexcl / 100 * (100 - Klantenkorting);
            Totaalbtw = Totaalincl / 100 * 21;
            Totaalinclbtw = Totaalincl + Totaalbtw;

            tbTotaal1.Text = "€" + Totaalexcl.ToString();
            tbKlantKorting.Text = Klantenkorting.ToString() + "%";
            tbTotaal2.Text = "€" + Totaalincl.ToString();
            tbBTW.Text = "€" + Totaalbtw.ToString();
            tbTotaal3.Text = "€" + Totaalinclbtw.ToString();
        }

        private void DatatableLaden()
        {
            lst.Add(new artikelen() { Artikelnummer = 16, Artikelnaam = "Schutting", Prijs = 49.00, Aantal = 8});
            lst.Add(new artikelen() { Artikelnummer = 32, Artikelnaam = "Olijfboom", Prijs = 249.00, Aantal = 4});
            lst.Add(new artikelen() { Artikelnummer = 92, Artikelnaam = "Orchidee", Prijs = 18.50, Aantal = 3});
            lst.Add(new artikelen() { Artikelnummer = 756, Artikelnaam = "Roos", Prijs = 1.25, Aantal =  10});

            dgArtikelen.ItemsSource = lst;
        }

        public class artikelen
        {
            public int Artikelnummer { get; set; }
            public string Artikelnaam { get; set; }
            public double Prijs { get; set; }
            public int Aantal { get; set; }
        }

        private void LoadMedewerker()
        {
            lbUser.Content = db.getInfoGebruiker("1");
        }

        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            //Crasht momenteel door snelle inlog, maar werkt wanner we de snelle inlog eraf halen
            MainWindow f = new MainWindow();
            f.Show();

            this.Close();
        }

        private void tbTotaal1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Totaalexcl = 1456;
            Klantenkorting = 10;
            Totaalincl = Totaalexcl / 100 * (100 - Klantenkorting);
            Totaalbtw = Totaalincl / 100 * 21;
            Totaalinclbtw = Totaalincl + Totaalbtw;

            tbTotaal1.Text = "€" + Totaalexcl.ToString();
            tbKlantKorting.Text = Klantenkorting.ToString() + "%";
            tbTotaal2.Text = "€" + Totaalincl.ToString();
            tbBTW.Text = "€" + Totaalbtw.ToString();
            tbTotaal3.Text = "€" + Totaalinclbtw.ToString();
        }
    }
}
