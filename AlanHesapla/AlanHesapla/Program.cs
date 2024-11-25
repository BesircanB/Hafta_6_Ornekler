using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanHesapla
{
    class Program
    {
        static void Main(string[] args)
        {
            AlanHesap hesap = new AlanHesap();

            // Kare alanı hesaplama
            double kareKenar = 5;
            Console.WriteLine($"Kenarı {kareKenar} olan karenin alanı: {hesap.AlanHesapla(kareKenar):F2}");

            // Dikdörtgen alanı hesaplama
            double uzunluk = 6, genislik = 4;
            Console.WriteLine($"Uzunluğu {uzunluk} ve genişliği {genislik} olan dikdörtgenin alanı: {hesap.AlanHesapla(uzunluk, genislik):F2}");

            // Daire alanı hesaplama
            double yaricap = 3;
            Console.WriteLine($"Yarıçapı {yaricap} olan dairenin alanı: {hesap.AlanHesapla(yaricap, true):F2}");
            Console.ReadLine();

        }
    }

    class AlanHesap
    {
        // Kare alanı hesaplayan method
        public double AlanHesapla(double kenar)
        {
            return kenar * kenar;
        }

        // Dikdörtgen alanı hesaplayan method
        public double AlanHesapla(double uzunluk, double genislik)
        {
            return uzunluk * genislik;
        }

        // Daire alanı hesaplayan method
        public double AlanHesapla(double yaricap, bool isDaire = true)
        {
            return Math.PI * yaricap * yaricap;
        }
    }
}
