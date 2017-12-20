using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNWL_VrachtwagenApp
{
    public class Pakbon
    {
        public string PakbonNr { get; set; }
        public string Straatnaam { get; set; }
        public string Huisnummer { get; set; }
        public string Plaats { get; set; }
        public string Postcode { get; set; }
        public string OpAf { get; set; }
        public string Opmerkingen { get; set; }
        public string Status { get; set; }

        public Pakbon(string pakbonnr, string straat, string huis, string plaats, string post, string opaf, string opmerking, string status)
        {
            PakbonNr = pakbonnr;
            Straatnaam = straat;
            Huisnummer = huis;
            Plaats = plaats;
            Postcode = post;
            OpAf = opaf;
            Opmerkingen = opmerking;
            Status = status;
        }
    }
}
