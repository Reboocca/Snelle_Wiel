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
    /// Interaction logic for DeleteAccount.xaml
    /// </summary>
    public partial class DeleteAccount : Window
    {
        public DeleteAccount()
        {
            InitializeComponent();
        }

        private void btAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            //sluit deze window af
            this.Close();
        }

        private void btAccepteren_Click(object sender, RoutedEventArgs e)
        {
            //verwijder functie toevoegen

            //sluit deze window af
            this.Close();
        }
    }
}
