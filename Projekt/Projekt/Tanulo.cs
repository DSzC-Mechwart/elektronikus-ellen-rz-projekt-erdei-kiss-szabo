using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Tanulo
    {
        public Tanulo(string nev, int evfolyam)
        {
            this.nev = nev;
            this.evfolyam = evfolyam;
        }

        public string nev { get; set; }
        public int evfolyam { get; set; }
    }
}
