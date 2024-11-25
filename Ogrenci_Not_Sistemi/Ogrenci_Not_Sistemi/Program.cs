using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci_Not_Sistemi
{
    class OgrenciNotSistemi
    {
        private Dictionary<string, int> dersNotlari;
        private string ogrenciAdi;

        public OgrenciNotSistemi(string ad)
        {
            ogrenciAdi = ad;
            dersNotlari = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase); // Büyük/küçük harf duyarsız
        }

        public int this[string dersAdi]
        {
            get
            {
                if (dersNotlari.ContainsKey(dersAdi))
                {
                    return dersNotlari[dersAdi];
                }
                else
                {
                    throw new Exception($"Hata: '{dersAdi}' dersi bulunamadı!");
                }
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Not değeri 0-100 arasında olmalıdır!");
                }

                dersNotlari[dersAdi] = value;
            }
        }

        public void DersEkle(string dersAdi, int not)
        {
            if (not < 0 || not > 100)
            {
                throw new Exception("Not değeri 0-100 arasında olmalıdır!");
            }

            dersNotlari[dersAdi] = not;
        }

        public void NotlariListele()
        {
            Console.WriteLine($"\n{ogrenciAdi} - Ders Notları:");
            Console.WriteLine("------------------------");
            foreach (var ders in dersNotlari)
            {
                string harfNotu = NotHarfKarsiligi(ders.Value);
                Console.WriteLine($"{ders.Key}: {ders.Value} ({harfNotu})");
            }

            if (dersNotlari.Count > 0)
            {
                double ortalama = NotOrtalamasi();
                Console.WriteLine($"Genel Ortalama: {ortalama:F2}");
            }
        }

        private double NotOrtalamasi()
        {
            if (dersNotlari.Count == 0) return 0;

            int toplam = 0;
            foreach (var not in dersNotlari.Values)
            {
                toplam += not;
            }
            return (double)toplam / dersNotlari.Count;
        }

        private string NotHarfKarsiligi(int not)
        {
            if (not >= 90) return "AA";
            else if (not >= 85) return "BA";
            else if (not >= 80) return "BB";
            else if (not >= 75) return "CB";
            else if (not >= 70) return "CC";
            else if (not >= 65) return "DC";
            else if (not >= 60) return "DD";
            else return "FF";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OgrenciNotSistemi ogrenci = new OgrenciNotSistemi("Ahmet Yılmaz");

                ogrenci.DersEkle("Matematik", 85);
                ogrenci.DersEkle("Fizik", 75);
                ogrenci.DersEkle("Kimya", 90);

                ogrenci["Biyoloji"] = 88;

                ogrenci.NotlariListele();

                Console.WriteLine($"\nMatematik dersi notu: {ogrenci["Matematik"]}");

                ogrenci["Fizik"] = 82;
                Console.WriteLine("\nFizik notu güncellendikten sonra:");
                ogrenci.NotlariListele();

                Console.WriteLine($"\nTarih dersi notu: {ogrenci["Tarih"]}");

                
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nHata: {e.Message}");

                Console.ReadLine();
            }
        }
    }
}
