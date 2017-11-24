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
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : Window
    {
        List<Pakbonlijst> lstPakbonnen1 = new List<Pakbonlijst>();
        List<Pakbonlijst> lstPakbonnen2 = new List<Pakbonlijst>();
        List<Pakbonlijst> lstPakbonnen3 = new List<Pakbonlijst>();
        dbs db = new dbs();
        public Homepage()
        {
            InitializeComponent();
        }

        private void btBeheren_Click(object sender, RoutedEventArgs e)
        {
            Admin f = new Admin();
            f.Show();
            this.Close();
        }

        private void OpenPakbon(object sender, RoutedEventArgs e)
        {
            Pakbon f = new Pakbon();
            f.Show();
            f.Topmost = true;
        }

        private void btGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (dpDatum.SelectedDate == null)
            {
                MessageBox.Show("Zorg ervoor dat er een datum geselecteerd is", "Foutmelding");
            }
            else
            {
                LoadList();
            }
        }

        public void LoadList()
        {
            lstPakbonnen1.Add(new Pakbonlijst() { PakbonNr = "1884", Status = "op" });
            lstPakbonnen1.Add(new Pakbonlijst() { PakbonNr = "1742", Status = "af" });
            lstPakbonnen1.Add(new Pakbonlijst() { PakbonNr = "1128", Status = "op" });
            lstPakbonnen1.Add(new Pakbonlijst() { PakbonNr = "1002", Status = "af" });
            lstPakbonnen1.Add(new Pakbonlijst() { PakbonNr = "1532", Status = "af" });


            lstPakbonnen2.Add(new Pakbonlijst() { PakbonNr = "1538", Status = "af" });
            lstPakbonnen2.Add(new Pakbonlijst() { PakbonNr = "1994", Status = "af" });
            lstPakbonnen2.Add(new Pakbonlijst() { PakbonNr = "1402", Status = "af" });
            lstPakbonnen2.Add(new Pakbonlijst() { PakbonNr = "1326", Status = "op" });
            lstPakbonnen2.Add(new Pakbonlijst() { PakbonNr = "1743", Status = "op" });
            lstPakbonnen2.Add(new Pakbonlijst() { PakbonNr = "1244", Status = "af" });
            lstPakbonnen2.Add(new Pakbonlijst() { PakbonNr = "1828", Status = "op" });


            lstPakbonnen3.Add(new Pakbonlijst() { PakbonNr = "1923", Status = "af" });
            lstPakbonnen3.Add(new Pakbonlijst() { PakbonNr = "1289", Status = "op" });
            lstPakbonnen3.Add(new Pakbonlijst() { PakbonNr = "1348", Status = "af" });
            lstPakbonnen3.Add(new Pakbonlijst() { PakbonNr = "1345", Status = "op" });
            lstPakbonnen3.Add(new Pakbonlijst() { PakbonNr = "1854", Status = "op" });
            lstPakbonnen3.Add(new Pakbonlijst() { PakbonNr = "1533", Status = "af" });


            dgTabel1.ItemsSource = lstPakbonnen1;
            dgTabel2.ItemsSource = lstPakbonnen2;
            dgTabel3.ItemsSource = lstPakbonnen3;

        }


        public class Pakbonlijst
        {
            public string PakbonNr { get; set; }
            public string Status { get; set; }
        }
    }
}
