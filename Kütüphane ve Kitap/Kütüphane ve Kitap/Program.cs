using System;
using System.Collections.Generic;

// Kütüphane sınıfı: Bir kütüphaneyi temsil eder.
public class Kutuphane
{
    public string Ad { get; set; }  // Kütüphane adı
    public List<Kitap> Kitaplar { get; set; } = new List<Kitap>();  // Kütüphanenin kitapları listesi

    // Kitap eklemek için metod
    public void KitapEkle(Kitap kitap)
    {
        Kitaplar.Add(kitap);
    }

    public void KitaplariListele()
    {
        Console.WriteLine($"{Ad} adlı kütüphanedeki kitaplar:");
        foreach (var kitap in Kitaplar)
        {
            Console.WriteLine($"- {kitap.Baslik} (Yazar: {kitap.Yazar}, ISBN: {kitap.ISBN})");
        }
    }
}

// Kitap sınıfı: Bir kitabı temsil eder.
public class Kitap
{
    public string Baslik { get; set; }  // Kitap başlığı
    public string Yazar { get; set; }  // Kitabın yazarı
    public string ISBN { get; set; }  // Kitabın ISBN numarası
}

// Test Programı
public class Program
{
    public static void Main()
    {
        Kutuphane kutuphane = new Kutuphane { Ad = "Halk Kütüphanesi" };

        Kitap kitap1 = new Kitap { Baslik = "1984", Yazar = "George Orwell", ISBN = "9780451524935" };
        Kitap kitap2 = new Kitap { Baslik = "Hayvan Çiftliği", Yazar = "George Orwell", ISBN = "9780451526342" };

        kutuphane.KitapEkle(kitap1);
        kutuphane.KitapEkle(kitap2);

        kutuphane.KitaplariListele();

        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadLine();
    }
}
