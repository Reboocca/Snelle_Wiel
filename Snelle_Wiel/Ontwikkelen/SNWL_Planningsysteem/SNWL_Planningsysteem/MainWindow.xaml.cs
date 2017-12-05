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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SNWL_Planningsysteem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private async void Login()
        {
            if (tbUsername.Text == "" || pbPassword.Password == "")
            {
                MessageBox.Show("Zorg ervoor dat u beide invoervelden hebt gegevuld.", "Foutmelding");
            }
            else
            {
                string webadres = "https://hobbithole.000webhostapp.com/snwl/login_planning.php?user=" + tbUsername.Text + " &pwd=" + pbPassword.Password;
                HttpClient connect = new HttpClient();
                HttpResponseMessage logincheck = await connect.GetAsync(webadres);
                // gebruik eventueel PostAsync
                logincheck.EnsureSuccessStatusCode();

                string login  = await logincheck.Content.ReadAsStringAsync();

                if (login != "false")
                {
                    Homepage f = new Homepage(login);
                    f.Show();
                    this.Close();
                    
                }
                else if(login == "false")
                {
                    MessageBox.Show("Het ingevoerde gebruikersnaam en/of wachtwoord is onjuist.", "Foutmelding");
                }
            }
        }

        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }

        private void pbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }
    }
}
