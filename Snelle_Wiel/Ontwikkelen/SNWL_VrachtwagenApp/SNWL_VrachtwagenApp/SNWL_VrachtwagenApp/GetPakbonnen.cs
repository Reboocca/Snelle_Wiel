using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SNWL_VrachtwagenApp
{
    static class GetPakbonnen
    {
        const string Webadres = "https://hobbithole.000webhostapp.com/snwl/JSON_pakbon_vandaag.php?";

        //Haal Sproeier gegevens op en geef een lijst terug
        static public async Task<List<Pakbon>> getPakbonlist(string id, string date)
        {
            List<Pakbon> PakbonLijst = new List<Pakbon>();
            string Adress = Webadres + "id=" + id + "&date=" + date;

            HttpClient test = new HttpClient();
            HttpResponseMessage respons = await test.GetAsync(Adress);
            string stsd = "ajsd";
            if (respons.IsSuccessStatusCode)
            {
                string responsecontent = await respons.Content.ReadAsStringAsync();
                Rootobject p = JsonConvert.DeserializeObject<Rootobject>(responsecontent);
                
                foreach (Pakbonnen s in p.pakbonnen)
                {
                    string[] ophaal = s.ophaaladres.Split(':');
                    string[] afzet = s.afzetadres.Split(':');

                    Pakbon pakOp = new Pakbon(s.idpakbon, ophaal[0], ophaal[1], ophaal[3], ophaal[2], "Op", s.opmerking, s.status);
                    Pakbon pakAf = new Pakbon(s.idpakbon, afzet[0], afzet[1], afzet[3], afzet[2], "Af", s.opmerking, s.status);

                    PakbonLijst.Add(pakOp);
                    PakbonLijst.Add(pakAf);
                }

                return PakbonLijst;
            }

            return PakbonLijst;
        }
    }
}
