using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class TTargy
    {
        public TTargy(string nev, int evfolyam, string tipus, int hetiOraszam)
        {
            Nev = nev;
            Evfolyam = evfolyam;
            Tipus = tipus;
            HetiOraszam = hetiOraszam;
        }

        public string Nev { get; set; }
        public int Evfolyam { get; set; }
        public string Tipus { get; set; }
        public int HetiOraszam { get; set; }

    }
}
