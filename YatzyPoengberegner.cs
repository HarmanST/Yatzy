using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    internal class YatzyPoengberegner
    {
        public int BeregnPoeng(string kast, Kategori kategori)
        {

            var terninger = kast.Split(',').Select(int.Parse).ToList();

            switch (kategori)
            {
                case Kategori.Enere:
                    return terninger.Where(t => t == 1).Sum();

                case Kategori.Toere:
                    return terninger.Where(t => t == 2).Sum();

                case Kategori.Treere:
                    return terninger.Where(t => t == 3).Sum();

                case Kategori.Firere:
                    return terninger.Where(t => t == 4).Sum();

                case Kategori.Par:
                    return terninger.GroupBy(t => t)
                                    .Where(gruppe => gruppe.Count() >= 2)
                                    .Select(gruppe => gruppe.Key * 2)
                                    .OrderByDescending(poeng => poeng)
                                    .FirstOrDefault();

                case Kategori.ToPar:
                    var par = terninger.GroupBy(t => t)
                                       .Where(gruppe => gruppe.Count() >= 2)
                                       .Select(gruppe => gruppe.Key)
                                       .OrderByDescending(t => t)
                                       .Take(2)
                                       .ToList();
                    return par.Count == 2 ? par.Sum() * 2 : 0;

                case Kategori.TreLike:
                    return 0;

                case Kategori.FireLike:
                    return 0;

                case Kategori.LitenStraight:
                    return 0;

                case Kategori.StorStraight:
                    return 0;

                case Kategori.FulltHus:
                    return 0;

                case Kategori.Sjanse:
                    return 0;

                case Kategori.Yatzy:
                    return 0;

                default:
                    throw new NotImplementedException($"Kategori {kategori} er ikke implementert ennå.");
            }

        }
    }
}
