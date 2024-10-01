using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class szAdat
    {
        public szAdat(string nev, string szuletesiHely, DateTime szuletesiIdo, string anyjaNeve, string lakcim, DateTime beiratkozasIdeje, string szak, string osztaly, bool kollegistaCheck, string kollegium, string torzslapszam)
        {
            Nev = nev;
            SzuletesiHely = szuletesiHely;
            SzuletesiIdo = szuletesiIdo;
            AnyjaNeve = anyjaNeve;
            Lakcim = lakcim;
            BeiratkozasIdeje = beiratkozasIdeje;
            Szak = szak;
            Osztaly = osztaly;
            KollegistaCheck = kollegistaCheck;
            Kollegium = kollegium;
            Torzslapszam = torzslapszam;
        }

        public string Nev { get; set; }
        public string SzuletesiHely { get; set; }
        public DateTime SzuletesiIdo { get; set; }
        public string AnyjaNeve { get; set; }
        public string Lakcim {  get; set; }
        public DateTime BeiratkozasIdeje {  get; set; }
        public string Szak {  get; set; }
        public string Osztaly {  get; set; }
        public bool KollegistaCheck {  get; set; }
        public string Kollegium {  get; set; }
        public string Torzslapszam {  get; set; }
    }
}
