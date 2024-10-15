using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Tantargyak
    {
        List<TantargyAdat> tantargyList;

        public Tantargyak(string filePath)
        {
            tantargyList = new();
            foreach (var item in File.ReadAllLines(filePath, Encoding.UTF8))
            {
                string[] parts = item.Split(";");
                string tNev = parts[0];
                string evfolyam = parts[1];
                string szakmaiVagyKözism = parts[2];
                int oraszam = Convert.ToInt32(parts[3]);
                TantargyAdat ujAdat = new(tNev, evfolyam, szakmaiVagyKözism, oraszam);
                tantargyList.Add(ujAdat);
            }
        }
    }
}
