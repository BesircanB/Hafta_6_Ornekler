using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trafik_Isik
{
    class Program
    {
        static void Main(string[] args)
        {
            TrafikIsigi trafikIsigi = new TrafikIsigi();

            // Tüm durumları test et
            foreach (TrafikIsigiDurum durum in Enum.GetValues(typeof(TrafikIsigiDurum)))
            {
                Console.WriteLine($"\nIşık Durumu: {durum}");
                Console.WriteLine($"Yapılması Gereken: {trafikIsigi.DurumKontrolu(durum)}");
                Console.WriteLine($"Süre: {trafikIsigi.BeklemeSuresi(durum)} saniye");
                Console.WriteLine($"Sonraki Durum: {trafikIsigi.SonrakiDurum(durum)}");
            }

            // Simülasyon örneği
            Console.WriteLine("\n\nTrafik Işığı Simülasyonu:");
            Console.WriteLine("-------------------------");

            TrafikIsigiDurum simdikiDurum = TrafikIsigiDurum.Red;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"\nZaman: {i * 30} saniye");
                Console.WriteLine($"Işık: {simdikiDurum}");
                Console.WriteLine($"Eylem: {trafikIsigi.DurumKontrolu(simdikiDurum)}");
                simdikiDurum = trafikIsigi.SonrakiDurum(simdikiDurum);
            }

            Console.ReadLine();
        }
    }

    enum TrafikIsigiDurum
    {
        Red,    // Kırmızı
        Yellow, // Sarı
        Green   // Yeşil
    }

    class TrafikIsigi
    {
        public string DurumKontrolu(TrafikIsigiDurum durum)
        {
            switch (durum)
            {
                case TrafikIsigiDurum.Red:
                    return "Dur! Kırmızı ışık yanıyor.";

                case TrafikIsigiDurum.Yellow:
                    return "Dikkat! Durmak için hazırlan veya geçiş için hazırlan.";

                case TrafikIsigiDurum.Green:
                    return "Geç! Yol açık.";

                default:
                    return "Bilinmeyen durum!";
            }
        }

        public int BeklemeSuresi(TrafikIsigiDurum durum)
        {
            switch (durum)
            {
                case TrafikIsigiDurum.Red:
                    return 60; // 60 saniye bekle

                case TrafikIsigiDurum.Yellow:
                    return 5;  // 5 saniye bekle

                case TrafikIsigiDurum.Green:
                    return 45; // 45 saniye bekle

                default:
                    return 0;
            }
        }

        public TrafikIsigiDurum SonrakiDurum(TrafikIsigiDurum mevcutDurum)
        {
            switch (mevcutDurum)
            {
                case TrafikIsigiDurum.Red:
                    return TrafikIsigiDurum.Green;

                case TrafikIsigiDurum.Yellow:
                    return TrafikIsigiDurum.Red;

                case TrafikIsigiDurum.Green:
                    return TrafikIsigiDurum.Yellow;

                default:
                    return TrafikIsigiDurum.Red;
            }
        }
    }
}
