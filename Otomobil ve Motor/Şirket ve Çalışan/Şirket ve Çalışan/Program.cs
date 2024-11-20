using System;
using System.Collections.Generic;

// Şirket sınıfı: Bir şirketi temsil eder.
public class Sirket
{
    public string Ad { get; set; }  // Şirket adı
    public List<Calisan> Calisanlar { get; set; } = new List<Calisan>();  // Şirketin çalışanları listesi

    // Çalışan eklemek için metod
    public void CalisanEkle(Calisan calisan)
    {
        Calisanlar.Add(calisan);
    }

    public void CalisanlariListele()
    {
        Console.WriteLine($"{Ad} adlı şirketin çalışanları:");
        foreach (var calisan in Calisanlar)
        {
            Console.WriteLine($"- {calisan.Ad} (Pozisyon: {calisan.Pozisyon})");
        }
    }
}

// Çalışan sınıfı: Bir çalışanı temsil eder.
public class Calisan
{
    public string Ad { get; set; }  // Çalışanın adı
    public string Pozisyon { get; set; }  // Çalışanın pozisyonu
}

// Test Programı
public class Program
{
    public static void Main()
    {
        Sirket sirket = new Sirket { Ad = "Teknoloji A.Ş." };

        Calisan calisan1 = new Calisan { Ad = "Ali", Pozisyon = "Yazılım Geliştirici" };
        Calisan calisan2 = new Calisan { Ad = "Ayşe", Pozisyon = "Proje Yöneticisi" };

        sirket.CalisanEkle(calisan1);
        sirket.CalisanEkle(calisan2);

        sirket.CalisanlariListele();

        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadLine();
    }
}
