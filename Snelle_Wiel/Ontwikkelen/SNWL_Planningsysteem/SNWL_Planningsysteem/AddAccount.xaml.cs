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
    /// Interaction logic for AddAccount.xaml
    /// </summary>
    public partial class AddAccount : Window
    {
        public AddAccount()
        {
            InitializeComponent();
            //spRijbewijs.Visibility = Visibility.Hidden;
        }

        private void Loadform()
        {
            //if(cbRol.SelectedValue.ToString() == "Planner")
            //{
            //    spRijbewijs.Visibility = Visibility.Collapsed;
            //}
            //else if(cbRol.SelectedValue.ToString() == "Chauffeur")
            //{
            //    spRijbewijs.Visibility = Visibility.Visible;
            //}

           
        }

        private void cbRol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Account is toegevoegd", "Melding");
            this.Close();
        }
    }
}
