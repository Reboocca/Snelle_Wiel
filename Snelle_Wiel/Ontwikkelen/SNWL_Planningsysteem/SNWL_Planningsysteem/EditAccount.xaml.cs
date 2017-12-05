using System;
using System.Collections.Generic;
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

namespace SNWL_Planningsysteem
{
    /// <summary>
    /// Interaction logic for EditAccount.xaml
    /// </summary>
    public partial class EditAccount : Window
    {
        dbs db = new dbs();
        string accountid;
        string accountrol;
        string table1;

        public EditAccount(string accid, string accrol)
        {
            InitializeComponent();

            accountid = accid;
            accountrol = accrol;

            getGegevens();
        }

        private void getGegevens()
        {
            if (accountrol == "Chauffeur")
            {
                table1 = "chauffeurinfo";
            }
            else
            {
                table1 = "plannerinfo";
            }

            DataTable dtAccountinfo = db.SearchParameter(table1, "ID", accountid);

            foreach (DataRow row in dtAccountinfo.Rows)
            {
                tbVoornaam.Text = row["Firstname"].ToString();
                tbTussenvoegsel.Text = row["Insertion"].ToString();
                tbAchternaam.Text = row["Lastname"].ToString();
                tbAdres.Text = row["Streetname"].ToString();
                tbNummer.Text = row["Housenumber"].ToString();
                tbWoonplaats.Text = row["City"].ToString();
            }
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            if (tbVoornaam.Text == "" ||  tbAchternaam.Text == "" || tbAdres.Text == "" || tbNummer.Text == "" || tbWoonplaats.Text == "")
            {
                MessageBox.Show("Zorg ervoor dat ieder veld ingevoerd is, voordat u het account wijzigt", "Foutmelding");
            }
            else
            {
                bool resultaat = db.updateAccount(table1, accountid, tbVoornaam.Text, tbTussenvoegsel.Text, tbAchternaam.Text, tbAdres.Text, tbNummer.Text, tbWoonplaats.Text);

                if (resultaat)
                {

                    MessageBox.Show("De gegevens van het account zijn gewijzigd.", "Succes");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Er is iets mis gegaan bij het wijzigen van de gegevens, probeer het opnieuw of neem contact op met een beheerder", "Foutmelding");
                }
            }
        }
    }
}
