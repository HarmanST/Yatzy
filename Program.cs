using System;
using Yatzy;


class Program
{
    static void Main(string[] args)
    {
        //Kode for å teste en kategori
        Console.WriteLine("Tester en kategori: ");
        YatzyPoengberegner runde1 = new YatzyPoengberegner();

        int poengForYatzy = runde1.BeregnPoeng("1, 1, 2, 1, 3", Kategori.Enere);

        Console.WriteLine(poengForYatzy);


        string kast = "1, 1, 2, 1, 3";
        var terninger = kast.Split(',').Select(int.Parse).ToList();


        int poeng = terninger.GroupBy(t => t)
                          .Where(gruppe => gruppe.Count() >= 2)
                          .Select(gruppe => gruppe.Key * 2)
                          .OrderByDescending(poeng => poeng)
                          .FirstOrDefault();


        Console.WriteLine($"Peong: {poeng}");

    }
}