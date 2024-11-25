using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gps_System
{
    class Program
    {
        static void Main(string[] args)
        {
            GPSKonum istanbul = new GPSKonum(41.0082, 28.9784); // İstanbul
            GPSKonum ankara = new GPSKonum(39.9334, 32.8597);   // Ankara
            GPSKonum izmir = new GPSKonum(38.4237, 27.1428);    // İzmir
            GPSKonum antalya = new GPSKonum(36.8841, 30.7056);  // Antalya

            Console.WriteLine("Şehirler Arası Mesafeler:");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"İstanbul - Ankara: {istanbul.MesafeHesapla(ankara):F2} km");
            Console.WriteLine($"İstanbul - İzmir: {istanbul.MesafeHesapla(izmir):F2} km");
            Console.WriteLine($"İstanbul - Antalya: {istanbul.MesafeHesapla(antalya):F2} km");
            Console.WriteLine($"Ankara - İzmir: {ankara.MesafeHesapla(izmir):F2} km");
            Console.WriteLine($"Ankara - Antalya: {ankara.MesafeHesapla(antalya):F2} km");
            Console.WriteLine($"İzmir - Antalya: {izmir.MesafeHesapla(antalya):F2} km");

            Console.WriteLine("\nAynı Nokta Testi:");
            Console.WriteLine($"İstanbul - İstanbul: {istanbul.MesafeHesapla(istanbul):F2} km");

            GPSKonum taksim = new GPSKonum(41.0370, 28.9850);    // Taksim
            GPSKonum sultanahmet = new GPSKonum(41.0054, 28.9768); // Sultanahmet

            Console.WriteLine("\nYakın Mesafe Testi (İstanbul içi):");
            Console.WriteLine($"Taksim - Sultanahmet: {taksim.MesafeHesapla(sultanahmet):F2} km");

            Console.ReadLine();
        }
    }

    struct GPSKonum
    {
        public double Latitude { get; private set; }  // Enlem
        public double Longitude { get; private set; } // Boylam

        public GPSKonum(double latitude, double longitude)
        {
            if (latitude < -90 || latitude > 90)
                throw new ArgumentException("Enlem -90 ile +90 derece arasında olmalıdır.");

            if (longitude < -180 || longitude > 180)
                throw new ArgumentException("Boylam -180 ile +180 derece arasında olmalıdır.");

            Latitude = latitude;
            Longitude = longitude;
        }

        public double MesafeHesapla(GPSKonum digerKonum)
        {
            const double DUNYA_YARICAP = 6371;

            double lat1 = DerecedenRadyana(this.Latitude);
            double lon1 = DerecedenRadyana(this.Longitude);
            double lat2 = DerecedenRadyana(digerKonum.Latitude);
            double lon2 = DerecedenRadyana(digerKonum.Longitude);

            double deltaLat = lat2 - lat1;
            double deltaLon = lon2 - lon1;

            // Haversine formülü
            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                      Math.Cos(lat1) * Math.Cos(lat2) *
                      Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Mesafe hesaplama
            return DUNYA_YARICAP * c;
        }

        private double DerecedenRadyana(double derece)
        {
            return derece * Math.PI / 180;
        }

        public override string ToString()
        {
            string latDirection = Latitude >= 0 ? "K" : "G";
            string lonDirection = Longitude >= 0 ? "D" : "B";

            return $"{Math.Abs(Latitude):F4}°{latDirection}, {Math.Abs(Longitude):F4}°{lonDirection}";
        }
    }
}
