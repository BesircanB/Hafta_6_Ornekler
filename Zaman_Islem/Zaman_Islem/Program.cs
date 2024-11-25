using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaman_Islem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Geçerli zaman değerleriyle test
            Zaman zaman1 = new Zaman(14, 30);
            Zaman zaman2 = new Zaman(16, 45);

            Console.WriteLine("Zaman 1: " + zaman1.ToString());
            Console.WriteLine("Zaman 2: " + zaman2.ToString());

            Console.WriteLine($"Zaman 1'in toplam dakikası: {zaman1.ToplamDakika()}");
            Console.WriteLine($"Zaman 2'nin toplam dakikası: {zaman2.ToplamDakika()}");

            int fark = Zaman.ZamanFarkiHesapla(zaman2, zaman1);
            Console.WriteLine($"İki zaman arasındaki fark: {fark} dakika");

            // Geçersiz değerlerle test
            Zaman gecersizZaman = new Zaman(25, 70);
            Console.WriteLine("\nGeçersiz değerlerle oluşturulan zaman: " + gecersizZaman.ToString());

            // Farklı zaman kombinasyonlarıyla test
            Zaman sabah = new Zaman(9, 0);
            Zaman aksam = new Zaman(17, 30);

            Console.WriteLine("\nMesai Örneği:");
            Console.WriteLine($"Mesai Başlangıç: {sabah}");
            Console.WriteLine($"Mesai Bitiş: {aksam}");
            Console.WriteLine($"Mesai Süresi: {Zaman.ZamanFarkiHesapla(aksam, sabah)} dakika");

            // Sınır değerlerle test
            Zaman yarimGece = new Zaman(0, 0);
            Zaman birDakikaSonra = new Zaman(0, 1);

            Console.WriteLine("\nSınır Değer Testi:");
            Console.WriteLine($"Yarım Gece: {yarimGece}");
            Console.WriteLine($"Bir Dakika Sonra: {birDakikaSonra}");
            Console.WriteLine($"Fark: {Zaman.ZamanFarkiHesapla(birDakikaSonra, yarimGece)} dakika");

            Console.ReadLine();
        }
    }

    struct Zaman
    {
        private int hour;
        private int minute;

        public int Hour
        {
            get { return hour; }
            set { hour = (value >= 0 && value < 24) ? value : 0; }
        }

        public int Minute
        {
            get { return minute; }
            set { minute = (value >= 0 && value < 60) ? value : 0; }
        }

        public Zaman(int hour, int minute)
        {
            this.hour = 0;
            this.minute = 0;
            Hour = hour;    // Doğrulama için property kullanılıyor
            Minute = minute; // Doğrulama için property kullanılıyor
        }

        public int ToplamDakika()
        {
            return Hour * 60 + Minute;
        }

        public static int ZamanFarkiHesapla(Zaman zaman1, Zaman zaman2)
        {
            return Math.Abs(zaman1.ToplamDakika() - zaman2.ToplamDakika());
        }

        public override string ToString()
        {
            return $"{Hour:D2}:{Minute:D2}";
        }
    }
}
