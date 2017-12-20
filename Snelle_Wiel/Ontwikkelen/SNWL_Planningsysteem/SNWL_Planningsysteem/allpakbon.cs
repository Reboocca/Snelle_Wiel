using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNWL_Planningsysteem
{
    public class allpakbon
    {
        public PakbonBasicInfo pkbinfo { get; set; }
        public opdrachtgever opdrgv { get; set; }
        public zender znd { get; set; }
        public ophaaladres ophladr { get; set; }
        public afleveradres afldres { get; set; }
        public List<artikel> art { get; set; }
        public Laadgegevens ldg { get; set; }

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
