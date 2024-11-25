using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İslemSinifi
{
    class Program
    {
        static void Main(string[] args)
        {
            Islem m = new Islem();

            // İki sayının toplamı
            Console.WriteLine("İki sayının toplamı: " + m.Topla(5, 10));

            // Üç sayının toplamı
            Console.WriteLine("Üç sayının toplamı: " + m.Topla(5, 10, 15));

            // Dizi toplamı
            int[] sayiDizisi = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Dizi toplamı: " + m.Topla(sayiDizisi));

            Console.ReadLine();
        }
    }

    class Islem
    {
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Topla(int sayi1, int sayi2, int sayi3)
        {
            return sayi1 + sayi2 + sayi3;
        }

        public int Topla(int[] sayilar)
        {
            int toplam = 0;
            foreach (int sayi in sayilar)
            {
                toplam += sayi;
            }
            return toplam;
        }
    }
}
