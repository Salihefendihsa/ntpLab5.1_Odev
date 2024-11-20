using System;
using System.Collections.Generic;

public class Ogrenci
{
    // Öğrencinin adını tutan özellik
    public string Ad { get; set; }

    // Öğrencinin yaşını tutan özellik
    public int Yas { get; set; }

    // Öğrenci bilgilerini ekrana yazdıran metod
    public void OgrenciBilgisi()
    {
        Console.WriteLine($"Ad: {Ad}, Yaş: {Yas}");
    }
}

public class Okul
{
    // Okulun adını tutan özellik
    public string Ad { get; set; }

    // Okuldaki öğrencileri tutan liste
    public List<Ogrenci> Ogrenciler { get; set; } = new List<Ogrenci>();

    // Öğrenciyi okula eklemek için kullanılan metod
    public void OgrenciEkle(Ogrenci ogrenci)
    {
        Ogrenciler.Add(ogrenci);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Kullanıcıdan okulun adını alıyoruz
        Console.WriteLine("Okul adını giriniz:");
        string okulAdi = Console.ReadLine();

        // Okul nesnesini oluşturuyoruz
        Okul okul = new Okul { Ad = okulAdi };

        // Kullanıcıdan kaç öğrenci ekleyeceğini soruyoruz
        Console.WriteLine("Kaç öğrenci eklemek istiyorsunuz?");
        int ogrenciSayisi = int.Parse(Console.ReadLine());

        // Kullanıcıdan öğrenci bilgilerini alıp okula ekliyoruz
        for (int i = 0; i < ogrenciSayisi; i++)
        {
            Console.WriteLine($"\n{i + 1}. öğrencinin adını giriniz:");
            string ogrenciAd = Console.ReadLine();

            // Öğrencinin yaşını alıyoruz
            Console.WriteLine($"{ogrenciAd} öğrencisinin yaşını giriniz:");
            int ogrenciYas = int.Parse(Console.ReadLine());

            // Yeni bir öğrenci nesnesi oluşturup okula ekliyoruz
            okul.OgrenciEkle(new Ogrenci { Ad = ogrenciAd, Yas = ogrenciYas });
        }

        // Okuldaki tüm öğrencilerin bilgilerini yazdırıyoruz
        Console.WriteLine("\nOkuldaki öğrenciler:");
        foreach (var ogrenci in okul.Ogrenciler)
        {
            ogrenci.OgrenciBilgisi();
        }
    }
}
