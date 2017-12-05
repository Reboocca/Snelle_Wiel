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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public List<Account> lstAccounts = new List<Account>();
        dbs db = new dbs();
        string id;

        public Admin(string userid)
        {
            InitializeComponent();

            id = userid;
            getAccounts();
        }

        private void getAccounts()
        {
            lstAccounts.Clear();
            dgMedewerkers.ItemsSource = null;

            DataTable dtChauffeurs = db.Search("chauffeurinfo");

            foreach (DataRow row in dtChauffeurs.Rows)
            {
                lstAccounts.Add(new Account() { PersoneelsNr = row["ID"].ToString(), Voornaam = row["Firstname"].ToString(), Tussenvoegsel = row["Insertion"].ToString(), Achternaam = row["Lastname"].ToString(), Rol = "Chauffeur" });
            }

            DataTable dtPlanners = db.Search("plannerinfo");

            foreach (DataRow row in dtPlanners.Rows)
            {
                lstAccounts.Add(new Account() { PersoneelsNr = row["ID"].ToString(), Voornaam = row["Firstname"].ToString(), Tussenvoegsel = row["Insertion"].ToString(), Achternaam = row["Lastname"].ToString(), Rol = "Planner" });
            }

            dgMedewerkers.ItemsSource = lstAccounts;
        }

        private void SearchOnID()
        {
            lstAccounts.Clear();
            dgMedewerkers.ItemsSource = null;

            DataTable dtChauffeurs = db.SearchParameterLike("chauffeurinfo", "ID", tbZoek.Text);

            foreach (DataRow row in dtChauffeurs.Rows)
            {
                lstAccounts.Add(new Account() { PersoneelsNr = row["ID"].ToString(), Voornaam = row["Firstname"].ToString(), Tussenvoegsel = row["Insertion"].ToString(), Achternaam = row["Lastname"].ToString(), Rol = "Chauffeur" });
            }

            DataTable dtPlanners = db.SearchParameterLike("plannerinfo", "ID", tbZoek.Text);

            foreach (DataRow row in dtPlanners.Rows)
            {
                lstAccounts.Add(new Account() { PersoneelsNr = row["ID"].ToString(), Voornaam = row["Firstname"].ToString(), Tussenvoegsel = row["Insertion"].ToString(), Achternaam = row["Lastname"].ToString(), Rol = "Planner" });
            }

            dgMedewerkers.ItemsSource = lstAccounts;
        }

        private void SearchOnName()
        {
            lstAccounts.Clear();
            dgMedewerkers.ItemsSource = null;

            DataTable dtChauffeurs = db.SearchNameAccount("chauffeurinfo", tbZoek.Text);

            foreach (DataRow row in dtChauffeurs.Rows)
            {
                lstAccounts.Add(new Account() { PersoneelsNr = row["ID"].ToString(), Voornaam = row["Firstname"].ToString(), Tussenvoegsel = row["Insertion"].ToString(), Achternaam = row["Lastname"].ToString(), Rol = "Chauffeur" });
            }

            DataTable dtPlanners = db.SearchNameAccount("plannerinfo", tbZoek.Text);

            foreach (DataRow row in dtPlanners.Rows)
            {
                lstAccounts.Add(new Account() { PersoneelsNr = row["ID"].ToString(), Voornaam = row["Firstname"].ToString(), Tussenvoegsel = row["Insertion"].ToString(), Achternaam = row["Lastname"].ToString(), Rol = "Planner" });
            }

            dgMedewerkers.ItemsSource = lstAccounts;
        }

        private void btNieuw_Click(object sender, RoutedEventArgs e)
        {
            AddAccount f = new AddAccount();
            f.Show();
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            Homepage f = new Homepage(id);
            f.Show();
            this.Close();
        }

        private void btBewerken_Click(object sender, RoutedEventArgs e)
        {
            if (dgMedewerkers.SelectedCells.Count > 0)
            {
                string personeelsnr = ((Account)(dgMedewerkers.SelectedItem)).PersoneelsNr;
                string rol = ((Account)(dgMedewerkers.SelectedItem)).Rol;

                EditAccount f = new EditAccount(personeelsnr, rol);
                f.Show();
            }
            else
            {
                MessageBox.Show("Selecteer eerst een medeweker voordat u verder kunt", "Foutmelding");
            }
        }

        private void btVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (dgMedewerkers.SelectedCells.Count > 0)
            {
                string personeelsnr = ((Account)(dgMedewerkers.SelectedItem)).PersoneelsNr;
                string rol = ((Account)(dgMedewerkers.SelectedItem)).Rol;

                DeleteAccount f = new DeleteAccount(personeelsnr, rol);
                f.Show();                      
            }
            else
            {
                MessageBox.Show("Selecteer eerst een medeweker voordat u verder kunt", "Foutmelding");
            }
        }

        private void btZoek_Click(object sender, RoutedEventArgs e)
        {
            if(tbZoek.Text == "")
            {
                getAccounts();
            }
            else
            {
                if (cbZoek.SelectedIndex == 0)
                {
                    SearchOnID();
                }
                else if (cbZoek.SelectedIndex == 1)
                {
                    SearchOnName();
                }
            }
        }

        private void tbZoek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (tbZoek.Text == "")
                {
                    getAccounts();
                }
                else
                {
                    if (cbZoek.SelectedIndex == 0)
                    {
                        SearchOnID();
                    }
                    else if (cbZoek.SelectedIndex == 1)
                    {
                        SearchOnName();
                    }
                }
            }
        }

        private void btRefresh_Click(object sender, RoutedEventArgs e)
        {
            getAccounts();
        }
    }
}
