using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNWL_VrachtwagenApp
{
        public class Rootobject
        {
            public Pakbonnen[] pakbonnen { get; set; }
        }

        public class Pakbonnen
        {
            public string idplanning { get; set; }
            public string idpakbon { get; set; }
            public string idchauffeur { get; set; }
            public string ophaaladres { get; set; }
            public string afzetadres { get; set; }
            public string ophaaltijdvan { get; set; }
            public string afzettijdtot { get; set; }
            public string datum { get; set; }
            public string opmerking { get; set; }
            public string status { get; set; }
    }
}
