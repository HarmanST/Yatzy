using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    public class YatzyPoengberegner
    {
        public int BeregnPoeng(string kast, Kategori kategori)
        {
            // Konverter kastet til en liste
            var terninger = kast.Split(',').Select(int.Parse).ToList();

            switch (kategori)
            {
                case Kategori.Enere:
                    // Filtrer terninger som viser 1 og summerer disse
                    return terninger.Where(t => t == 1).Sum();

                case Kategori.Toere:
                    // Filtrer terninger som viser 2 og summerer disse
                    return terninger.Where(t => t == 2).Sum();

                case Kategori.Treere:
                    // Filtrer terninger som viser 3 og summerer disse
                    return terninger.Where(t => t == 3).Sum();

                case Kategori.Firere:
                    // Filtrer terninger som viser 4 og summerer disse
                    return terninger.Where(t => t == 4).Sum();

                case Kategori.Femmere:
                    // Filtrer terninger som viser 5 og summerer disse
                    return terninger.Where(t => t == 5).Sum();

                case Kategori.Seksere:
                    // Filtrer terninger som viser 6 og summerer disse
                    return terninger.Where(t => t == 6).Sum();

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
                                       //.Take(2) //Trenger ikke denne
                                       .ToList();

                    if (par.Count == 2) { return par.Sum() * 2; }
                    else return 0;

                case Kategori.TreLike:
                    return terninger.GroupBy(t => t)
                                    .Where(gruppe => gruppe.Count() >= 3)
                                    .Select(gruppe => gruppe.Key * 3)
                                    .FirstOrDefault();

                case Kategori.FireLike:
                    return terninger.GroupBy(t => t)
                                    .Where(gruppe => gruppe.Count() >= 4)
                                    .Select(gruppe => gruppe.Key * 4)
                                    .FirstOrDefault();

                case Kategori.LitenStraight:
                    var litenStraight = new List<int> { 1, 2, 3, 4, 5 };

                    if (terninger.OrderBy(t => t).SequenceEqual(litenStraight)) {
                        return 15;
                    }
                    else return 0;

                case Kategori.StorStraight:
                    var storStraight = new List<int> { 2, 3, 4, 5, 6 };

                    if (terninger.OrderBy(t => t).SequenceEqual(storStraight))
                    {
                        return 20;
                    }
                    else return 0;


                case Kategori.FulltHus:
                    var grupper = terninger.GroupBy(t => t); 
                    bool harToLike = false;
                    bool harTreLike = false;

                    foreach (var gruppe in grupper)
                    {
                        if (gruppe.Count() == 2) { harToLike = true; }
                        else if (gruppe.Count() == 3) { harTreLike = true; }
                    }

                    if (harToLike && harTreLike) { return terninger.Sum(); }
                    else { return 0; }

                case Kategori.Sjanse:
                    return terninger.Sum();

                case Kategori.Yatzy:
                    if (terninger.Distinct().Count() == 1) 
                    {
                        return 50;
                    }

                    else return 0;

                default:
                    throw new NotImplementedException($"Kategori {kategori} finnes ikke");
            }

        }

        public Resultat Max(string kast)
        {
            var terninger = kast.Split(',').Select(int.Parse).ToList();

            Kategori besteKategori = Kategori.Sjanse; // Valgt Sjanse som Default, men kan være hva som helst
            int høyestePoeng = 0;

            foreach (Kategori kategori in Enum.GetValues(typeof(Kategori)))
            {
                //Hopper over "Sjanse" siden den alltid gir like mye som alle kategoreier utenom Yatzy.
                //Ønsker ikke at den skal bli forslått her.
                if (kategori == Kategori.Sjanse) continue;

                // Beregn poeng for denne kategorien
                int poeng = BeregnPoeng(kast, kategori);

                // Oppdater beste kategori og poengsum
                if (poeng > høyestePoeng)
                {
                    høyestePoeng = poeng;
                    besteKategori = kategori;
                }
            }

            int sjansePoeng = BeregnPoeng(kast, Kategori.Sjanse);
            if (sjansePoeng > høyestePoeng)
            {
                besteKategori = Kategori.Sjanse;
                høyestePoeng = sjansePoeng;
            }

            // Returner resultatet som en ny struktur
            return new Resultat(besteKategori, høyestePoeng);
        }
    }
}
