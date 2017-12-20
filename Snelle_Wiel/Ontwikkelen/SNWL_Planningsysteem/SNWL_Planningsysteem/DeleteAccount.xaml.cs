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
    /// Interaction logic for DeleteAccount.xaml
    /// </summary>
    public partial class DeleteAccount : Window
    {
        dbs db = new dbs();
        ThisAccount acc = new ThisAccount();
        string accountid;
        string accountrol;
        string table;
        string table2;
        public DeleteAccount(string accid, string accrol)
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
                table = "chauffeurinfo";
                table2 = "chauffeurs";
            }
            else
            {
                table = "plannerinfo";
                table2 = "planners";
            }

            DataTable dtAccountinfo = db.SearchParameter(table, "ID", accountid);

            foreach (DataRow row in dtAccountinfo.Rows)
            {
                acc.voornaam = row["Firstname"].ToString();
                acc.tussenvoegsel = row["Insertion"].ToString();
                acc.achternaam = row["Lastname"].ToString();
            }

            if (acc.tussenvoegsel == "")
            {
                tbText.Text = "Weet u zeker dat u het volgende account van: " + acc.voornaam + " " + acc.achternaam + " wilt verwijderen?";
            }
            else
            {
                tbText.Text = "Weet u zeker dat u het volgende account van: " + acc.voornaam + " " + acc.tussenvoegsel + " " + acc.achternaam + " wilt verwijderen?";
            }
        }

        private void btAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            //sluit deze window af
            this.Close();
        }

        private void btAccepteren_Click(object sender, RoutedEventArgs e)
        {
            //verwijder functie toevoegen
            bool resultaat = db.DeleteAccount(table, accountid);
            bool resultaat2 = db.DeleteAccount(table2, accountid);
            if (resultaat || resultaat2)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Er is iets misgegaan met het verwijderen van het account, probeer het nog eens of neem contact op met een beheerder", "Foutmelding");
                this.Close();
            }


            //sluit deze window af
            this.Close();
        }

        class ThisAccount
        {
            public string voornaam { get; set; }
            public string tussenvoegsel { get; set; }
            public string achternaam { get; set; }
        }

    }
}
