using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karmasik_Sayilar
{
    class Program
    {
        static void Main(string[] args)
        {
            // Karmaşık sayıları oluştur
            KarmasikSayi sayi1 = new KarmasikSayi(3, 4);    // 3 + 4i
            KarmasikSayi sayi2 = new KarmasikSayi(1, -2);   // 1 - 2i
            KarmasikSayi sayi3 = new KarmasikSayi(-2, 5);   // -2 + 5i

            // Sayıları yazdır
            Console.WriteLine("Sayı 1: " + sayi1);
            Console.WriteLine("Sayı 2: " + sayi2);
            Console.WriteLine("Sayı 3: " + sayi3);

            // Toplama işlemleri
            Console.WriteLine("\nToplama İşlemleri:");
            Console.WriteLine($"{sayi1} + {sayi2} = {sayi1.Topla(sayi2)}");
            Console.WriteLine($"{sayi2} + {sayi3} = {sayi2.Topla(sayi3)}");
            Console.WriteLine($"{sayi1} + {sayi3} = {sayi1.Topla(sayi3)}");

            // Çıkarma işlemleri
            Console.WriteLine("\nÇıkarma İşlemleri:");
            Console.WriteLine($"{sayi1} - {sayi2} = {sayi1.Cikar(sayi2)}");
            Console.WriteLine($"{sayi2} - {sayi3} = {sayi2.Cikar(sayi3)}");
            Console.WriteLine($"{sayi1} - {sayi3} = {sayi1.Cikar(sayi3)}");

            // Özel durumlar
            Console.WriteLine("\nÖzel Durumlar:");
            KarmasikSayi sifir = new KarmasikSayi(0, 0);    // 0 + 0i
            KarmasikSayi realSayi = new KarmasikSayi(5, 0); // 5 + 0i
            KarmasikSayi imagSayi = new KarmasikSayi(0, 3); // 0 + 3i

            Console.WriteLine($"Sıfır: {sifir}");
            Console.WriteLine($"Sadece Reel Kısım: {realSayi}");
            Console.WriteLine($"Sadece Sanal Kısım: {imagSayi}");

            Console.WriteLine($"\n{realSayi} + {imagSayi} = {realSayi.Topla(imagSayi)}");
            Console.WriteLine($"{realSayi} - {imagSayi} = {realSayi.Cikar(imagSayi)}");

            Console.ReadLine();
        }
    }

    struct KarmasikSayi
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public KarmasikSayi(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public KarmasikSayi Topla(KarmasikSayi other)
        {
            return new KarmasikSayi(
                Real + other.Real,
                Imaginary + other.Imaginary
            );
        }

        public KarmasikSayi Cikar(KarmasikSayi other)
        {
            return new KarmasikSayi(
                Real - other.Real,
                Imaginary - other.Imaginary
            );
        }

        public override string ToString()
        {
            if (Real == 0 && Imaginary == 0)
                return "0";

            if (Real == 0)
                return $"{Imaginary}i";

            if (Imaginary == 0)
                return $"{Real}";

            string imaginaryPart = Imaginary < 0
                ? $"- {Math.Abs(Imaginary)}i"
                : $"+ {Imaginary}i";

            return $"{Real} {imaginaryPart}";
        }
    }
}
