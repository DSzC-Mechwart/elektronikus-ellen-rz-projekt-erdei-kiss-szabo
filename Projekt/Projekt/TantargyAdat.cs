using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class TantargyAdat
    {
        public TantargyAdat(string tNev, string evfolyam, string szakmaiVagyKözism, int oraszam)
        {
            TNev = tNev;
            Evfolyam = evfolyam;
            SzakmaiVagyKözism = szakmaiVagyKözism;
            Oraszam = oraszam;
        }

        public string TNev { get; set; }

        public string Evfolyam { get; set; }

        public string SzakmaiVagyKözism { get; set; }
        public int Oraszam { get; set; }
    }
}
