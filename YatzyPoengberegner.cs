using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    internal class YatzyPoengberegner
    {

        public static int[] ExtractNumbers(string kast)
        {
            return kast.Split(',').Select(number => int.Parse(number.Trim())).ToArray();
        }
        public int BeregnPoeng(string kast, Kategori kategori)
        {
            int[] tall = ExtractNumbers(kast);
            int poeng = 0;

            if (kategori.navn == "enere")
            {
                for (int i = 0; i < tall.Length; i++)
                {
                    if (tall[i] == 1)
                    {
                        poeng++;
                    }
                }
                return poeng;
            }
            else if (kategori.navn == "toere")
            {
                for (int i = 0; i < tall.Length; i++)
                {
                    if (tall[i] == 2)
                    {
                        poeng+=2;
                    }
                }
                return poeng;
            }
            else if (kategori.navn == "toere")
            {
                for (int i = 0; i < tall.Length - 1; i++)
                {
                    if (tall[i] == 2)
                    {
                        poeng += 2;
                    }
                }
                return poeng;
            }
            else if (kategori.navn == "treere")
            {
                for (int i = 0; i < tall.Length; i++)
                {
                    if (tall[i] == 3)
                    {
                        poeng += 3;
                    }
                }
                return poeng;
            }
            else if (kategori.navn == "firere")
            {
                for (int i = 0; i < tall.Length; i++)
                {
                    if (tall[i] == 4)
                    {
                        poeng += 4;
                    }
                }
                return poeng;
            }
            else if (kategori.navn == "femmere")
            {
                for (int i = 0; i < tall.Length; i++)
                {
                    if (tall[i] == 5)
                    {
                        poeng += 5;
                    }
                }
                return poeng;
            }
            else if (kategori.navn == "seksere")
            {
                for (int i = 0; i < tall.Length; i++)
                {
                    if (tall[i] == 6)
                    {
                        poeng += 6;
                    }
                }
                return poeng;
            }
            else if (kategori.navn == "par")
            {
                
            }



            return 0;
        }
    }
}
