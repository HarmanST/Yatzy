using System;
using System.Security.Cryptography;
using Yatzy;


class Program
{
    public static List<int> KastTerninger(int antall)
    {
        Random random = new Random();
        List<int> terninger = new List<int>();
        for (int i = 0; i < antall; i++)
        {
            terninger.Add(random.Next(1, 7));
        }
        return terninger;
    }
    public static List<int> endreKast(List<int> skalEndre)
    {
        return null;
    }


    static void Main(string[] args)
    {
        //Kode for å teste en kategori
        //Console.WriteLine("Tester en kategori: ");
        //YatzyPoengberegner runde1 = new YatzyPoengberegner();

        //int poengForYatzy = runde1.BeregnPoeng("1, 1, 2, 1, 3", Kategori.Enere);

        //Console.WriteLine(poengForYatzy);


        //string kast = "2,2,3,3,3";
        //var terninger = kast.Split(',').Select(int.Parse).ToList();
        //----------------------------------------------------


        List<int> førsteKast = KastTerninger(6);

        //førsteKast.ForEach(verdi => Console.WriteLine($"Terning: {verdi}"));

        Console.WriteLine("Terningkast:");
        for (int i = 0; i < førsteKast.Count; i++)
        {
            Console.WriteLine($"Terning {i + 1}: {førsteKast[i]}");
        }







    }
}