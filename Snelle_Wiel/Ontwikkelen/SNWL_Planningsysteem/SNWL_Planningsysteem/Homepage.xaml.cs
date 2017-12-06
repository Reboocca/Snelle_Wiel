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
using System.Xml.Linq;

namespace SNWL_Planningsysteem
{
    /// <summary>
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : Window
    {
        List<TreeViewItem> lstPakbonnen = new List<TreeViewItem>();
        List<allpakbon> allepakbonnen = new List<allpakbon>();
        List<artikel> lstartik = new List<artikel>();

        dbs db = new dbs();

        string id;
        public Homepage(string userid)
        {
            InitializeComponent();

            id = userid;

            PakbonnenInvoegen();
        }

        public void PakbonnenInvoegen()
        {
            var doc = XDocument.Load(@"xml\Opdracht.xml");

            lstPakbonnen.Clear();
            TreeViewItem treeitem = null;
            treeitem = new TreeViewItem();
            TreeViewItem treeitemadd = null;
            treeitemadd = new TreeViewItem();
            allpakbon pkbn = new allpakbon();
            string date = String.Empty;
            int icount = 0;
            string infopakbon = "";

            foreach (XElement x in doc.Descendants("bezorgorder"))
            {

                if (icount == 0)
                {
                    infopakbon = "";
                    treeitem = null;
                    treeitem = new TreeViewItem();
                    treeitemadd = null;
                    treeitemadd = new TreeViewItem();
                    date = String.Empty;

                    icount++;

                    date = x.Element("datum").Value.Remove(x.Element("datum").Value.LastIndexOf("/") + 3);
                }

                treeitemadd.Header = x.Element("orderref").Value;
                infopakbon = x.Element("ophaaltijdvanaf").Value + "" + x.Element("aflevertijdtot").Value;

                pkbn.pkbinfo = new PakbonBasicInfo() { Datum = x.Element("datum").Value, Orderref = x.Element("orderref").Value, aflevertijdtot = x.Element("aflevertijdtot").Value, ophaaltijdvanaf = x.Element("ophaaltijdvanaf").Value };

                treeitemadd.Header = x.Element("orderref").Value;

                foreach (XElement a in doc.Descendants("opdrachtgever"))
                {
                    pkbn.opdrgv = new opdrachtgever() { nr = a.Element("nr").Value, naam = a.Element("naam").Value };
                }
                foreach (XElement b in doc.Descendants("zender"))
                {
                    pkbn.znd = new zender() { nr = b.Element("nr").Value, naam = b.Element("naam").Value };
                }
                foreach (XElement c in doc.Descendants("ophaaladres"))
                {
                    pkbn.ophladr = new ophaaladres() { nr = c.Element("nr").Value, naam = c.Element("naam").Value };
                }
                foreach (XElement d in doc.Descendants("afleveradres"))
                {
                    pkbn.afldres = new afleveradres() { nr = d.Element("nr").Value, naam = d.Element("naam").Value, huisnr = d.Element("huisnr").Value, straat = d.Element("nr").Value, plaats = d.Element("plaats").Value, postcode = d.Element("postcode").Value, telefoonnr = d.Element("telefoonnr").Value, };
                }

                foreach (XElement e in doc.Descendants("laadgegevens"))
                {
                    pkbn.ldg = new Laadgegevens() { kg = e.Element("kg").Value, m3 = e.Element("m3").Value, aantal = e.Element("aantal").Value };
                }

                foreach (XElement e in doc.Descendants("artikel"))
                {
                    artikel artkl = new artikel() { nr = e.Element("nr").Value, naam = e.Element("naam").Value, aantal = int.Parse(e.Element("aantal").Value) };
                    lstartik.Add(artkl);
                }

                pkbn.art = lstartik;

                lstPakbonnen.Add(treeitemadd);
                allepakbonnen.Add(pkbn);
            }
            TreeviewAdd(treeitem, date);
        }

        public void TreeviewAdd(TreeViewItem treeitem, string datum)
        {
            treeitem.Header = datum;
            treeitem.ItemsSource = lstPakbonnen;
            tvDatums.Items.Add(treeitem);

            foreach (TreeViewItem tr in treeitem.Items)
            {
                tr.MouseDoubleClick += new MouseButtonEventHandler(OpenPakbon);
            }
        }

        private void btBeheren_Click(object sender, RoutedEventArgs e)
        {
            Admin f = new Admin(id);
            f.Show();
            this.Close();
        }

        private void OpenPakbon(object sender, RoutedEventArgs e)
        {
            Pakbon f = new Pakbon(sender as TreeViewItem, allepakbonnen);
            f.Show();
            f.Topmost = true;
        }

        private void btGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (dpDatum.SelectedDate == null)
            {
                MessageBox.Show("Zorg ervoor dat er een datum geselecteerd is", "Foutmelding");
            }
            else
            {
                LoadList();
            }
        }

        public void LoadList()
        {

        }

        public class allpakbon
        {
            public PakbonBasicInfo pkbinfo { get; set; }
            public opdrachtgever opdrgv { get; set; }
            public zender znd { get; set; }
            public ophaaladres ophladr { get; set; }
            public afleveradres afldres { get; set; }
            public List<artikel> art { get; set; }
            public Laadgegevens ldg { get; set; }

        }

        public class PakbonBasicInfo
        {
            public string Datum { get; set; }
            public string Orderref { get; set; }
            public string ophaaltijdvanaf { get; set; }
            public string aflevertijdtot { get; set; }
        }
        public class opdrachtgever
        {
            public string nr { get; set; }
            public string naam { get; set; }
        }
        public class zender
        {
            public string nr { get; set; }
            public string naam { get; set; }
        }

        public class ophaaladres
        {
            public string nr { get; set; }
            public string naam { get; set; }
        }

        public class afleveradres
        {
            public string nr { get; set; }
            public string naam { get; set; }
            public string straat { get; set; }
            public string huisnr { get; set; }
            public string plaats { get; set; }
            public string postcode { get; set; }
            public string telefoonnr { get; set; }
        }

        public class artikel
        {
            public string nr { get; set; }
            public string naam { get; set; }
            public int aantal { get; set; }
        }
        public class Laadgegevens
        {
            public string aantal { get; set; }
            public string kg { get; set; }
            public string m3 { get; set; }
        }
    }
}
