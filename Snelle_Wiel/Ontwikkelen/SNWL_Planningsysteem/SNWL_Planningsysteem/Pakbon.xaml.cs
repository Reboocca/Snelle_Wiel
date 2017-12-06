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
    /// Interaction logic for Pakbon.xaml
    /// </summary>
    public partial class Pakbon : Window
    {
        public Pakbon(TreeViewItem tr, List<Homepage.allpakbon> lstpkb)
        {
            InitializeComponent();

            tbPakbonNr.Text = tr.Header.ToString();

            foreach (Homepage.allpakbon pkbn in lstpkb)
            {
                if (pkbn.pkbinfo.Orderref == tr.Header.ToString())
                {
                    tbDatum.Text = pkbn.pkbinfo.Datum;
                    tbKlant.Text = pkbn.opdrgv.nr + ", " + pkbn.opdrgv.naam;
                    tbPakbonNr.Text = pkbn.pkbinfo.Orderref;
                    for (int i = 0; i < pkbn.art.Count; i++)
                    {
                        lvArtikel.Items.Add(new MyArtikel { nr = pkbn.art[i].nr, naam = pkbn.art[i].naam, aantal = pkbn.art[i].aantal });
                    }
                    tbGewicht.Text = pkbn.ldg.kg;
                    tbVan.Text = pkbn.ophladr.nr + ", " + pkbn.ophladr.naam;
                    tbNaar.Text = pkbn.afldres.nr + ", " + pkbn.afldres.naam + ", " + pkbn.afldres.straat + ", " + pkbn.afldres.huisnr + ", " + pkbn.afldres.postcode + ", " + pkbn.afldres.plaats + ", " + pkbn.afldres.telefoonnr;

                }
            }
        }
        public class MyArtikel
        {
            public string nr { get; set; }

            public string naam { get; set; }

            public int aantal { get; set; }
        }
    }
}
