using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hava_Tahmin
{
    class Program
    {
        static void Main(string[] args)
        {
            HavaDurumuTahmini tahmin = new HavaDurumuTahmini();

            // Tüm durumlar için tahmin ve önerileri göster
            foreach (HavaDurumu durum in Enum.GetValues(typeof(HavaDurumu)))
            {
                Console.WriteLine($"\nHava Durumu: {durum}");
                Console.WriteLine($"Sıcaklık Aralığı: {tahmin.SicaklikAraligi(durum)}");
                Console.WriteLine("Öneriler:");
                foreach (string oneri in tahmin.Tavsiyeler(durum))
                {
                    Console.WriteLine($"- {oneri}");
                }
                Console.WriteLine($"Aktivite Önerisi: {tahmin.AktiviteOnerisi(durum)}");
            }

            // Haftalık hava durumu simülasyonu
            Console.WriteLine("\n\nHaftalık Hava Durumu Tahmini:");
            Console.WriteLine("-----------------------------");

            string[] gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };
            Random rnd = new Random();

            foreach (string gun in gunler)
            {
                HavaDurumu gunlukDurum = (HavaDurumu)rnd.Next(Enum.GetValues(typeof(HavaDurumu)).Length);
                Console.WriteLine($"\n{gun}:");
                Console.WriteLine($"Hava: {gunlukDurum}");
                Console.WriteLine($"Sıcaklık: {tahmin.SicaklikAraligi(gunlukDurum)}");
                Console.WriteLine($"Önerilen Aktivite: {tahmin.AktiviteOnerisi(gunlukDurum)}");
            }

            Console.ReadLine();
        }
    }

    enum HavaDurumu
    {
        Sunny,   // Güneşli
        Rainy,   // Yağmurlu
        Cloudy,  // Bulutlu
        Stormy   // Fırtınalı
    }

    class HavaDurumuTahmini
    {
        public string[] Tavsiyeler(HavaDurumu durum)
        {
            switch (durum)
            {
                case HavaDurumu.Sunny:
                    return new string[]
                    {
                    "Güneş kremi kullanın",
                    "Bol su için",
                    "Güneş gözlüğü takın",
                    "Açık renkli kıyafetler tercih edin",
                    "Şapka kullanın"
                    };

                case HavaDurumu.Rainy:
                    return new string[]
                    {
                    "Şemsiye alın",
                    "Su geçirmez ayakkabı giyin",
                    "Yağmurluk veya su geçirmez mont giyin",
                    "Yedek kıyafet bulundurun",
                    "Kaymaz tabanlı ayakkabı tercih edin"
                    };

                case HavaDurumu.Cloudy:
                    return new string[]
                    {
                    "Yanınıza ince bir hırka alın",
                    "Yağmur ihtimaline karşı şemsiye bulundurun",
                    "Katmanlı giyinin",
                    "Hava değişimine hazırlıklı olun"
                    };

                case HavaDurumu.Stormy:
                    return new string[]
                    {
                    "Mümkünse dışarı çıkmayın",
                    "Acil durum çantası hazırlayın",
                    "Şemsiye kullanmayın (rüzgar nedeniyle tehlikeli olabilir)",
                    "Loose eşyaları sabitleyin",
                    "Elektrik kesintisine hazırlıklı olun"
                    };

                default:
                    return new string[] { "Hava durumu bilgisi mevcut değil" };
            }
        }

        public string SicaklikAraligi(HavaDurumu durum)
        {
            switch (durum)
            {
                case HavaDurumu.Sunny:
                    return "25°C - 35°C";
                case HavaDurumu.Rainy:
                    return "15°C - 25°C";
                case HavaDurumu.Cloudy:
                    return "18°C - 28°C";
                case HavaDurumu.Stormy:
                    return "10°C - 20°C";
                default:
                    return "Sıcaklık bilgisi mevcut değil";
            }
        }

        public string AktiviteOnerisi(HavaDurumu durum)
        {
            switch (durum)
            {
                case HavaDurumu.Sunny:
                    return "Plaj, piknik, açık hava aktiviteleri ideal";

                case HavaDurumu.Rainy:
                    return "Müze ziyareti, sinema veya ev aktiviteleri önerilir";

                case HavaDurumu.Cloudy:
                    return "Yürüyüş, fotoğraf çekimi veya park ziyareti yapılabilir";

                case HavaDurumu.Stormy:
                    return "Evde kalın, kitap okuyun veya film izleyin";

                default:
                    return "Aktivite önerisi mevcut değil";
            }
        }
    }
} 
