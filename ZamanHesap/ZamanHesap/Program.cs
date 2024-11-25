using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamanHesap
{
    class TarihHesaplayici
    {
        // Gün cinsinden fark hesaplayan method
        public int ZamanFarkiHesapla(DateTime tarih1, DateTime tarih2)
        {
            TimeSpan fark = tarih2 - tarih1;
            return Math.Abs((int)fark.TotalDays);
        }

        // Saat cinsinden fark hesaplayan method
        public double ZamanFarkiHesapla(DateTime tarih1, DateTime tarih2, bool saatOlarakMi)
        {
            TimeSpan fark = tarih2 - tarih1;
            return Math.Abs(fark.TotalHours);
        }

        // Yıl, ay ve gün olarak fark hesaplayan method için yeni bir class
        public class TarihFarki
        {
            public int Yil { get; set; }
            public int Ay { get; set; }
            public int Gun { get; set; }
        }

        // Yıl, ay ve gün olarak fark hesaplayan method
        public TarihFarki ZamanFarkiHesaplaAyrinti(DateTime tarih1, DateTime tarih2)
        {
            // Tarihleri sıralayalım
            var baslangic = tarih1 < tarih2 ? tarih1 : tarih2;
            var bitis = tarih1 < tarih2 ? tarih2 : tarih1;

            int yil = bitis.Year - baslangic.Year;
            int ay = bitis.Month - baslangic.Month;
            int gun = bitis.Day - baslangic.Day;

            // Ay negatifse düzeltme
            if (ay < 0)
            {
                yil--;
                ay += 12;
            }

            // Gün negatifse düzeltme
            if (gun < 0)
            {
                ay--;
                gun += DateTime.DaysInMonth(baslangic.Year, baslangic.Month);
                if (ay < 0)
                {
                    yil--;
                    ay += 12;
                }
            }

            return new TarihFarki { Yil = yil, Ay = ay, Gun = gun };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TarihHesaplayici hesaplayici = new TarihHesaplayici();

            DateTime tarih1 = new DateTime(2022, 1, 1);
            DateTime tarih2 = new DateTime(2024, 3, 15);

            // Gün farkı hesaplama
            int gunFarki = hesaplayici.ZamanFarkiHesapla(tarih1, tarih2);
            Console.WriteLine($"Gün farkı: {gunFarki} gün");

            // Saat farkı hesaplama
            double saatFarki = hesaplayici.ZamanFarkiHesapla(tarih1, tarih2, true);
            Console.WriteLine($"Saat farkı: {saatFarki:F2} saat");

            // Detaylı fark hesaplama
            var detayliFark = hesaplayici.ZamanFarkiHesaplaAyrinti(tarih1, tarih2);
            Console.WriteLine($"Detaylı fark: {detayliFark.Yil} yıl, {detayliFark.Ay} ay, {detayliFark.Gun} gün");

            // Örnek çıktı için farklı tarihler
            DateTime tarih3 = new DateTime(2024, 1, 1);
            DateTime tarih4 = new DateTime(2024, 3, 15);
            var kisaDonemFark = hesaplayici.ZamanFarkiHesaplaAyrinti(tarih3, tarih4);
            Console.WriteLine($"Kısa dönem fark: {kisaDonemFark.Yil} yıl, {kisaDonemFark.Ay} ay, {kisaDonemFark.Gun} gün");

            Console.ReadLine();
        }
    }

}
