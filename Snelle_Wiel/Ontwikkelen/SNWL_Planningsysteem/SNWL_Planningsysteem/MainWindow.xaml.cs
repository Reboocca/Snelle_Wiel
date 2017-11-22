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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SNWL_Planningsysteem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        dbs db = new dbs();
        public MainWindow()
        {
            InitializeComponent();

            //snel inloggen
            //db.try_login("p.meeresman", "123", this);
        }



        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Login()
        {
            if (tbUsername.Text == "" || pbPassword.Password == "")
            {
                MessageBox.Show("Zorg ervoor dat u beide invoervelden hebt gegevuld.", "Foutmelding");
            }
            else
            {
                //db.newUser(tbUsername.Text, pbPassword.Password);
                db.try_login(tbUsername.Text, pbPassword.Password, this);
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
