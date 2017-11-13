using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bureau_IIS_Kassa
{
    class User
    {
        public string userid { get; set; }
        public string naam { get; set; }

        public User(string id, string Naam)
        {
            userid = id;
            naam = Naam;
        }

    }
}
