using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class szAdat
    {
        public szAdat(string nev, string szuletesiHely, DateOnly szuletesiIdo, string anyjaNeve, string lakcim, DateOnly beiratkozasIdeje, string szak, string osztaly, bool kollegista, string kollegium, string torzslapszam)
        {
            Nev = nev;
            SzuletesiHely = szuletesiHely;
            SzuletesiIdo = szuletesiIdo;
            AnyjaNeve = anyjaNeve;
            Lakcim = lakcim;
            BeiratkozasIdeje = beiratkozasIdeje;
            Szak = szak;
            Osztaly = osztaly;
            Kollegista = kollegista;
            Kollegium = kollegium;
            Torzslapszam = torzslapszam;
        }

        public string Nev { get; set; }
        public string SzuletesiHely { get; set; }
        public DateOnly SzuletesiIdo { get; set; }
        public string AnyjaNeve { get; set; }
        public string Lakcim {  get; set; }
        public DateOnly BeiratkozasIdeje {  get; set; }
        public string Szak {  get; set; }
        public string Osztaly {  get; set; }
        public bool Kollegista {  get; set; }
        public string Kollegium {  get; set; }
        public string Torzslapszam {  get; set; }
    }
}
