using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otopark_Sistem
{
    class Program
    {
        static void Main(string[] args)
        {
            Otopark otopark = new Otopark(3, 10);

            otopark[1, 3] = "34AB123"; // 1. kat, 3. park yerine araç park et
            otopark[2, 5] = "06CD456"; 
            otopark[3, 1] = "35EF789"; 

            Console.WriteLine("Otopark Durumu:");
            Console.WriteLine("-----------------");

            Console.WriteLine($"1. Kat, 3. Park Yeri: {otopark[1, 3]}");
            Console.WriteLine($"1. Kat, 4. Park Yeri: {otopark[1, 4]}");
            Console.WriteLine($"2. Kat, 5. Park Yeri: {otopark[2, 5]}");
            Console.WriteLine($"3. Kat, 1. Park Yeri: {otopark[3, 1]}");

            try
            {
                Console.WriteLine(otopark[4, 1]); 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }

            try
            {
                Console.WriteLine(otopark[1, 11]); 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }

            // Tüm otoparkın durumunu göster
            Console.WriteLine("\nTüm Otopark Durumu:");
            Console.WriteLine("--------------------");
            for (int kat = 1; kat <= 3; kat++)
            {
                Console.WriteLine($"\nKat {kat}:");
                for (int parkYeri = 1; parkYeri <= 10; parkYeri++)
                {
                    Console.WriteLine($"Park Yeri {parkYeri}: {otopark[kat, parkYeri]}");
                }
            }

            Console.ReadLine();
        }
    }

    class Otopark
    {
        private string[,] parkYerleri;
        private int katSayisi;
        private int katBasinaParkYeri;

        public Otopark(int katSayisi, int katBasinaParkYeri)
        {
            this.katSayisi = katSayisi;
            this.katBasinaParkYeri = katBasinaParkYeri;
            parkYerleri = new string[katSayisi, katBasinaParkYeri];
        }

        public string this[int kat, int parkYeri]
        {
            get
            {
                if (KontrolEt(kat, parkYeri))
                {
                    string plaka = parkYerleri[kat - 1, parkYeri - 1];
                    return plaka ?? "Empty"; // Eğer null ise "Empty" döndür
                }
                throw new ArgumentException("Geçersiz kat veya park yeri!");
            }
            set
            {
                if (KontrolEt(kat, parkYeri))
                {
                    parkYerleri[kat - 1, parkYeri - 1] = value;
                }
                else
                {
                    throw new ArgumentException("Geçersiz kat veya park yeri!");
                }
            }
        }

        private bool KontrolEt(int kat, int parkYeri)
        {
            return kat >= 1 && kat <= katSayisi &&
                   parkYeri >= 1 && parkYeri <= katBasinaParkYeri;
        }
    }
}
