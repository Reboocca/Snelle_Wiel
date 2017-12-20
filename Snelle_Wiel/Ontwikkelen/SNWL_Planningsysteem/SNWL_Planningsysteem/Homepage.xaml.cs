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
using System.Xml.Linq;

namespace SNWL_Planningsysteem
{
    /// <summary>
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : Window
    {
        dbs db = new dbs();

        List<TreeViewItem> lstPakbonnenTree = new List<TreeViewItem>();
        List<allpakbon> allepakbonnen = new List<allpakbon>();
        List<allpakbon.artikel> lstartik = new List<allpakbon.artikel>();

        double iAantalPakbonnen;
        DataTable dtbChauffeurs = new DataTable();
        List<Chauffeur> lstChauffeur = new List<Chauffeur>();
        string id;
        int icheckkchauffeur1 = 0;
        int icheckkchauffeur2 = 0;
        int icheckkchauffeur3 = 0;
        int iChauffeur = 0;
        public Homepage(string userid)
        {
            InitializeComponent();

            id = userid;

            LaadChauffeursInList();

            PakbonnenInvoegen();

            pakbonnentoevoegenmetcode();
        }

        public void pakbonnentoevoegenmetcode()
        {

        }

        public void LaadChauffeursInList()
        {
            dtbChauffeurs = db.LaadChauffeurs();

            foreach (DataRow row in dtbChauffeurs.Rows)
            {
                lstChauffeur.Add(new Chauffeur() { ID = row[0].ToString(), Firstname = row[1].ToString(), Insertion = row[2].ToString(), Lastname = row[3].ToString(), Streetname = row[4].ToString(), Housenumber = row[5].ToString(), City = row[6].ToString(), License = row[7].ToString() });
            }
        }

        public void PakbonnenInvoegen()
        {
            var doc = XDocument.Load(@"xml/Opdracht.xml");

            lstPakbonnenTree.Clear();
            TreeViewItem treeitem = null;
            treeitem = new TreeViewItem();
            TreeViewItem treeitemadd = null;
            treeitemadd = new TreeViewItem();
            allpakbon pkbn = new allpakbon();
            string date = string.Empty;
            int icount = 0;

            foreach (XElement x in doc.Descendants("bezorgorder"))
            {

                if (icount == 0)
                {
                    treeitem = null;
                    treeitem = new TreeViewItem();
                    treeitemadd = null;
                    treeitemadd = new TreeViewItem();

                    icount++;

                    date = Convert.ToDateTime(x.Element("datum").Value).ToString().Remove(x.Element("datum").Value.LastIndexOf("/") + 5).Replace("/", "-");
                }
                string aflevertijd = Convert.ToDateTime(x.Element("aflevertijdtot").Value.Replace("/", "-")).ToString().Substring(0, 10) + Convert.ToDateTime(x.Element("aflevertijdtot").Value.Replace("/", "-")).ToString().Substring(10);
                
                string ophaaltijd = Convert.ToDateTime(x.Element("ophaaltijdvanaf").Value.Replace("/", "-")).ToString().Substring(0, 10) + Convert.ToDateTime(x.Element("ophaaltijdvanaf").Value.Replace("/", "-")).ToString().Substring(10);
                
                pkbn.pkbinfo = new allpakbon.PakbonBasicInfo() { Datum = Convert.ToDateTime(x.Element("datum").Value).ToString().Remove(x.Element("datum").Value.LastIndexOf("/") + 5).Replace("/", "-"), Orderref = x.Element("orderref").Value, aflevertijdtot = aflevertijd, ophaaltijdvanaf = ophaaltijd };

                treeitemadd.Header = x.Element("orderref").Value;

                foreach (XElement a in doc.Descendants("opdrachtgever"))
                {
                    pkbn.opdrgv = new allpakbon.opdrachtgever() { nr = a.Element("nr").Value, naam = a.Element("naam").Value };
                }
                foreach (XElement b in doc.Descendants("zender"))
                {
                    pkbn.znd = new allpakbon.zender() { nr = b.Element("nr").Value, naam = b.Element("naam").Value };
                }
                foreach (XElement c in doc.Descendants("ophaaladres"))
                {
                    pkbn.ophladr = new allpakbon.ophaaladres() { nr = c.Element("nr").Value, naam = c.Element("naam").Value };
                }
                foreach (XElement d in doc.Descendants("afleveradres"))
                {
                    pkbn.afldres = new allpakbon.afleveradres() { nr = d.Element("nr").Value, naam = d.Element("naam").Value, huisnr = d.Element("huisnr").Value, straat = d.Element("straat").Value, plaats = d.Element("plaats").Value, postcode = d.Element("postcode").Value, telefoonnr = d.Element("telefoonnr").Value, };
                }

                foreach (XElement e in doc.Descendants("laadgegevens"))
                {
                    pkbn.ldg = new allpakbon.Laadgegevens() { kg = e.Element("kg").Value, m3 = e.Element("m3").Value, aantal = e.Element("aantal").Value };
                }

                foreach (XElement e in doc.Descendants("artikel"))
                {
                    allpakbon.artikel artkl = new allpakbon.artikel() { nr = e.Element("nr").Value, naam = e.Element("naam").Value, aantal = int.Parse(e.Element("aantal").Value) };
                    lstartik.Add(artkl);
                }

                pkbn.art = lstartik;

                allepakbonnen.Add(pkbn);
                lstPakbonnenTree.Add(treeitemadd);

                AddPakbonnen();
            }

            treeitemadd = null;
            treeitemadd = new TreeViewItem();
            treeitemadd.Header = "111007B000055";
            lstPakbonnenTree.Add(treeitemadd);
            treeitemadd = null;
            treeitemadd = new TreeViewItem();
            treeitemadd.Header = "111007B000056";
            lstPakbonnenTree.Add(treeitemadd);
            treeitemadd = null;
            treeitemadd = new TreeViewItem();
            treeitemadd.Header = "111007B000057";
            lstPakbonnenTree.Add(treeitemadd);
            treeitemadd = null;
            treeitemadd = new TreeViewItem();
            treeitemadd.Header = "111007B000058";
            lstPakbonnenTree.Add(treeitemadd);
            TreeviewAdd(treeitem, date);
        }

        public void AddPakbonnen()
        {
            allpakbon pkbn1 = new allpakbon();
            
            pkbn1.pkbinfo = new allpakbon.PakbonBasicInfo() { Datum = "19-12-2017", Orderref = "111007B000055", aflevertijdtot = "19-12-2017 18:00:00", ophaaltijdvanaf = "19-12-2017 14:00:00" };
            pkbn1.opdrgv = new allpakbon.opdrachtgever() { nr = "1", naam = ("Groene Vingers") };
            pkbn1.znd = new allpakbon.zender() { nr = "K3aB", naam = "Kassa 3a Best" };
            pkbn1.ophladr = new allpakbon.ophaaladres() { nr = "18", naam = " Achter de Berg: 10:5388 TS: Nistelrode" };
            pkbn1.afldres = new allpakbon.afleveradres() { nr = "21", naam = "Klant", huisnr = "10", straat = "Boterweg", plaats = "Erp", postcode = "5469 EH", telefoonnr = "0407836514" };
            pkbn1.ldg = new allpakbon.Laadgegevens() { kg = "89", m3 = "8.3", aantal = "39" };
            lstartik.Clear();
            allpakbon.artikel artkl = new allpakbon.artikel() { nr = "501", naam = "Tuin bank", aantal = 1 };
            lstartik.Add(artkl);
            allpakbon.artikel artkl1 = new allpakbon.artikel() { nr = "823", naam = "Rozen", aantal = 38 };
            lstartik.Add(artkl1);
            pkbn1.art = lstartik;
            allepakbonnen.Add(pkbn1);

            allpakbon pkbn2 = new allpakbon();
            pkbn2.pkbinfo = new allpakbon.PakbonBasicInfo() { Datum = "19-12-2017", Orderref = "111007B000056", aflevertijdtot = "19-12-2017 18:00:00", ophaaltijdvanaf = "19-12-2017 14:00:00" };
            pkbn2.opdrgv = new allpakbon.opdrachtgever() { nr = "1", naam = ("Groene Vingers") };
            pkbn2.znd = new allpakbon.zender() { nr = "K3aB", naam = "Kassa 3a Best" };
            pkbn2.ophladr = new allpakbon.ophaaladres() { nr = "18", naam = "Burgemeester Seelenlaan:20:5741 MB:Beek en Donk" };
            pkbn2.afldres = new allpakbon.afleveradres() { nr = "22", naam = "Klant", huisnr = "2", straat = "Ommelsveld", plaats = "Asten", postcode = "5721 VT", telefoonnr = "0407836514" };
            pkbn2.ldg = new allpakbon.Laadgegevens() { kg = "11", m3 = "0.9", aantal = "22" };
            lstartik.Clear();
            artkl = null;
            artkl = new allpakbon.artikel() { nr = "531", naam = "Tuinstel", aantal = 1 };
            lstartik.Add(artkl);
            artkl1 = new allpakbon.artikel() { nr = "824", naam = "Violen", aantal = 21 };
            lstartik.Add(artkl1);
            pkbn2.art = lstartik;
            allepakbonnen.Add(pkbn2);

            allpakbon pkbn3 = new allpakbon();
            pkbn3.pkbinfo = new allpakbon.PakbonBasicInfo() { Datum = "19-12-2017", Orderref = "111007B000057", aflevertijdtot = "19-12-2017 18:00:00", ophaaltijdvanaf = "19-12-2017 14:00:00" };
            pkbn3.opdrgv = new allpakbon.opdrachtgever() { nr = "1", naam = ("Groene Vingers") };
            pkbn3.znd = new allpakbon.zender() { nr = "K3aB", naam = "Kassa 3a Best" };
            pkbn3.ophladr = new allpakbon.ophaaladres() { nr = "18", naam = "Kruisschotseweg:6:5708 BC:Helmond" };
            pkbn3.afldres = new allpakbon.afleveradres() { nr = "22", naam = "Klant", huisnr = "36", straat = "Oeffels", plaats = "Heeze", postcode = "5591 LZ", telefoonnr = "0407834584" };
            pkbn3.ldg = new allpakbon.Laadgegevens() { kg = "16", m3 = "3", aantal = "6" };
            lstartik.Clear();
            artkl = null;
            artkl = new allpakbon.artikel() { nr = "785", naam = "Olijfboompje", aantal = 1 };
            lstartik.Add(artkl);
            artkl = null;
            artkl = new allpakbon.artikel() { nr = "824", naam = "Mix Winter Bloem", aantal = 5 };
            lstartik.Add(artkl);
            pkbn3.art = lstartik;
            allepakbonnen.Add(pkbn3);

            allpakbon pkbn4 = new allpakbon();
            pkbn4.pkbinfo = new allpakbon.PakbonBasicInfo() { Datum = "19-12-2017", Orderref = "111007B000058", aflevertijdtot = "19-12-2017 18:00:00", ophaaltijdvanaf = "19-12-2017 14:00:00" };
            pkbn4.opdrgv = new allpakbon.opdrachtgever() { nr = "1", naam = ("Groene Vingers") };
            pkbn4.znd = new allpakbon.zender() { nr = "K3aB", naam = "Kassa 3a Best" };
            pkbn4.ophladr = new allpakbon.ophaaladres() { nr = "18", naam = "Floreffestraat:17:Geen postcode opgegeven:Helmond" };
            pkbn4.afldres = new allpakbon.afleveradres() { nr = "28", naam = "Klant", huisnr = "191", straat = "Reinoutlaan", plaats = "Geldrop", postcode = "5665 AR", telefoonnr = "0402648752" };
            pkbn4.ldg = new allpakbon.Laadgegevens() { kg = "2", m3 = "0.2", aantal = "3" };
            lstartik.Clear();
            artkl1 = null;
            artkl1 = new allpakbon.artikel() { nr = "824", naam = "Paarse Zomer Bloem", aantal = 3 };
            lstartik.Add(artkl1);
            pkbn4.art = lstartik;
            allepakbonnen.Add(pkbn4);
        }

        public void TreeviewAdd(TreeViewItem treeitem, string datum)
        {
            treeitem.Header = datum;
            treeitem.ItemsSource = lstPakbonnenTree;
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
                foreach (allpakbon p in allepakbonnen) 
                {
                    db.AddPakbonToDB(p);
                }

                if (allepakbonnen.Count != 0)
                {
                    iAantalPakbonnen = allepakbonnen.Count / 3;
                    for (int i = 0; i < allepakbonnen.Count; i++)
                    {
                        string ophalen = allepakbonnen[i].pkbinfo.ophaaltijdvanaf.Remove(10, 9);
                        string datee = dpDatum.SelectedDate.ToString().Remove(10, 9);
                        if (i < iAantalPakbonnen && datee == ophalen)
                        {
                            AddPakbonToPlanning(i);
                        }
                        else if (i >= iAantalPakbonnen)
                        {
                            iAantalPakbonnen = allepakbonnen.Count / 3 * 2;
                            if (iChauffeur != 2)
                            {
                                iChauffeur++;
                            }
                            AddPakbonToPlanning(i);
                        }
                        else if(i >= iAantalPakbonnen)
                        {
                            iAantalPakbonnen = allepakbonnen.Count;
                            AddPakbonToPlanning(i);
                        }
                    }
                    foreach (allpakbon alpkbn in allepakbonnen)
                    {
                        
                    }
                }
            }
        }

        public void AddPakbonToPlanning( int i)
        {
            switch (iChauffeur)
            {
                case 0:
                    if (icheckkchauffeur1 == 0)
                    {
                        AddNameToPlanning();
                        icheckkchauffeur1++;
                    }
                    lvTabel1.Items.Add(allepakbonnen[i].pkbinfo.Orderref.ToString());
                    GridChauffeur1.Visibility = Visibility.Visible;
                    break;
                case 1:
                    if (icheckkchauffeur2 == 0)
                    {
                        AddNameToPlanning();
                        icheckkchauffeur2++;
                    }
                    lvTabel2.Items.Add(allepakbonnen[i].pkbinfo.Orderref.ToString());
                    GridChauffeur2.Visibility = Visibility.Visible;
                    break;
                case 2:
                    if (icheckkchauffeur3 == 0)
                    {
                        AddNameToPlanning();
                        icheckkchauffeur3++;
                    }
                    lvTabel3.Items.Add(allepakbonnen[i].pkbinfo.Orderref.ToString());
                    GridChauffeur3.Visibility = Visibility.Visible;
                    break;
            }

        }

        public void AddNameToPlanning()
        {
            if (lstChauffeur[iChauffeur].Insertion != "" && iChauffeur == 0)
            {
                lblFiller1.Content = lstChauffeur[iChauffeur].ID + ": " + lstChauffeur[iChauffeur].Firstname + " " + lstChauffeur[iChauffeur].Insertion + " " + lstChauffeur[iChauffeur].Lastname;
            }
            else if (lstChauffeur[iChauffeur].Insertion == "" && iChauffeur == 0)
            {
                lblFiller1.Content = lstChauffeur[iChauffeur].ID + ": " + lstChauffeur[0].Firstname + " " + lstChauffeur[iChauffeur].Lastname;
            }

            if (lstChauffeur[iChauffeur].Insertion != "" && iChauffeur == 1)
            {
                lblFiller2.Content = lstChauffeur[iChauffeur].ID + ": " + lstChauffeur[iChauffeur].Firstname + " " + lstChauffeur[iChauffeur].Insertion + " " + lstChauffeur[iChauffeur].Lastname;
            }
            else if (lstChauffeur[iChauffeur].Insertion == "" && iChauffeur == 1)
            {
                lblFiller2.Content = lstChauffeur[iChauffeur].ID + ": " + lstChauffeur[0].Firstname + " " + lstChauffeur[iChauffeur].Lastname;
            }

            if (lstChauffeur[iChauffeur].Insertion != "" && iChauffeur == 2)
            {
                lblFiller3.Content = lstChauffeur[iChauffeur].ID + ": " + lstChauffeur[iChauffeur].Firstname + " " + lstChauffeur[iChauffeur].Insertion + " " + lstChauffeur[iChauffeur].Lastname;
            }
            else if (lstChauffeur[iChauffeur].Insertion == "" && iChauffeur == 2)
            {
                lblFiller3.Content = lstChauffeur[iChauffeur].ID + ": " + lstChauffeur[0].Firstname + " " + lstChauffeur[iChauffeur].Lastname;
            }
        }

        public void LoadList()
        {

        }
    }
}
