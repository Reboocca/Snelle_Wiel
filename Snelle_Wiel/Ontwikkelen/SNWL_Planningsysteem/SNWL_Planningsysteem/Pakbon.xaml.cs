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
    /// Interaction logic for Pakbon.xaml
    /// </summary>
    public partial class Pakbon : Window
    {
        dbs db = new dbs();
        string pakbonnr;

        public Pakbon(TreeViewItem tr, List<allpakbon> lstpkb)
        {
            InitializeComponent();

            tbPakbonNr.Text = tr.Header.ToString();

            foreach (allpakbon pkbn in lstpkb)
            {
                if (pkbn.pkbinfo.Orderref == tr.Header.ToString())
                {
                    pakbonnr = pkbn.pkbinfo.Orderref;
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

            LoadDatabaseGegevens();
        }

        public void LoadDatabaseGegevens()
        {
            DataTable dtChauffeurs = db.PakbonDbsGegevensDBS(pakbonnr);

            foreach (DataRow row in dtChauffeurs.Rows)
            {
                if(row["Insertion"] == null)
                {
                    tbBezorger.Text = row["Firstname"].ToString() + " " + row["Lastname"].ToString();
                }
                else
                {
                    tbBezorger.Text = row["Firstname"].ToString() + " " + row["Insertion"].ToString() + " " + row["Lastname"].ToString();
                }

                tbStatus.Text = row["Status"].ToString();
                tbOpmerking.Text = row["Opmerkingen"].ToString();
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
