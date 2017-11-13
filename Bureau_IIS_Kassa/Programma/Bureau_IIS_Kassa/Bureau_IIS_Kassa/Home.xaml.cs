using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    }
}
