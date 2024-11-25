using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap_Yonetim
{
    class Kitaplik
    {
        private string[] kitaplar;
        private int kapasite;

        // Constructor - Kitaplığın kapasitesini belirler
        public Kitaplik(int boyut)
        {
            kapasite = boyut;
            kitaplar = new string[kapasite];
        }

        // İndeksleyici
        public string this[int indeks]
        {
            get
            {
                // Geçerli indeks kontrolü
                if (indeks >= 0 && indeks < kapasite)
                {
                    return kitaplar[indeks] ?? "Bu rafta kitap bulunmuyor.";
                }
                else
                {
                    return $"Hata: {indeks} numaralı raf mevcut değil. Raf numarası 0-{kapasite - 1} arasında olmalıdır.";
                }
            }
            set
            {
                // Geçerli indeks kontrolü
                if (indeks >= 0 && indeks < kapasite)
                {
                    kitaplar[indeks] = value;
                }
                else
                {
                    Console.WriteLine($"Hata: {indeks} numaralı raf mevcut değil. Raf numarası 0-{kapasite - 1} arasında olmalıdır.");
                }
            }
        }

        // Kitaplıktaki tüm kitapları listeleyen method
        public void KitaplariListele()
        {
            Console.WriteLine("\nKitaplıktaki Tüm Kitaplar:");
            for (int i = 0; i < kapasite; i++)
            {
                Console.WriteLine($"Raf {i}: {(kitaplar[i] ?? "Boş")}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 5 raflı bir kitaplık oluştur
            Kitaplik kitaplik = new Kitaplik(5);

            // Kitap ekleme
            kitaplik[0] = "Suç ve Ceza";
            kitaplik[1] = "1984";
            kitaplik[2] = "Sefiller";
            kitaplik[3] = "Don Kişot";

            // Kitapları listele
            kitaplik.KitaplariListele();

            // Belirli bir raftaki kitabı görüntüle
            Console.WriteLine($"\n2 numaralı raftaki kitap: {kitaplik[2]}");

            // Geçersiz indeks ile erişim
            Console.WriteLine($"\n6 numaralı raftaki kitap: {kitaplik[6]}");

            // Kitap güncelleme
            kitaplik[1] = "Hayvan Çiftliği";
            Console.WriteLine("\nGüncelleme sonrası:");
            kitaplik.KitaplariListele();

            // Boş bir rafı görüntüleme
            Console.WriteLine($"\n4 numaralı raftaki kitap: {kitaplik[4]}");

            Console.ReadLine();
        }
    }


}

