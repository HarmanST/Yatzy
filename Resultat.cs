using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    public class Resultat
    {
        public Kategori Kategori { get; set; }
        public int Poeng { get; set; }

        public Resultat(Kategori kategori, int poeng)
        {
            Kategori = kategori;
            Poeng = poeng;
        }
    }
}
