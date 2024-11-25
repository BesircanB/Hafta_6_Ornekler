using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satranc_Tahtasi
{
    class Program
    {
        static void Main(string[] args)
        {
            SatrancTahtasi tahta = new SatrancTahtasi();

            tahta["A1"] = "Beyaz Kale";
            tahta["B1"] = "Beyaz At";
            tahta["E1"] = "Beyaz Şah";
            tahta["D8"] = "Siyah Vezir";

            Console.WriteLine("A1'deki taş: " + tahta["A1"]);
            Console.WriteLine("B1'deki taş: " + tahta["B1"]);
            Console.WriteLine("E1'deki taş: " + tahta["E1"]);
            Console.WriteLine("D8'deki taş: " + tahta["D8"]);

            Console.WriteLine("C3'deki taş: " + tahta["C3"]);

            try
            {
                Console.WriteLine(tahta["Z9"]); 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            try
            {
                tahta["K5"] = "Beyaz Piyon"; 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            Console.ReadLine();
        }
    }

    class SatrancTahtasi
    {
        private string[,] tahta;

        public SatrancTahtasi()
        {
            tahta = new string[8, 8];
        }

        public string this[string konum]
        {
            get
            {
                try
                {
                    int[] koordinatlar = KonumuCevir(konum);
                    return tahta[koordinatlar[0], koordinatlar[1]] ?? "Boş";
                }
                catch
                {
                    throw new ArgumentException("Geçersiz konum!");
                }
            }
            set
            {
                try
                {
                    int[] koordinatlar = KonumuCevir(konum);
                    tahta[koordinatlar[0], koordinatlar[1]] = value;
                }
                catch
                {
                    throw new ArgumentException("Geçersiz konum!");
                }
            }
        }

        private int[] KonumuCevir(string konum)
        {
            if (konum.Length != 2)
                throw new ArgumentException("Geçersiz konum formatı!");

            char sutun = char.ToUpper(konum[0]);
            char satir = konum[1];

            if (sutun < 'A' || sutun > 'H' || satir < '1' || satir > '8')
                throw new ArgumentException("Geçersiz konum değerleri!");

            int sutunIndex = sutun - 'A';
            int satirIndex = 8 - (satir - '0');

            return new int[] { satirIndex, sutunIndex };
        }
    }
}
