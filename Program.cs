using System;
using Yatzy;


class Program
{
    static void Main(string[] args)
    {
        YatzyPoengberegner runde1 = new YatzyPoengberegner();

        int poengForYatzy = runde1.BeregnPoeng("1, 1, 2, 1, 3", Kategori.Enere);

        Console.WriteLine(poengForYatzy);  
    }
}