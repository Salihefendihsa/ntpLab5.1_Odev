using System;
using System.Collections.Generic;

// Ev sınıfı: Bir evi temsil eder.
public class Ev
{
    public string Ad { get; set; }  // Evin adı
    public List<Oda> Odalar { get; set; } = new List<Oda>();  // Evin odaları listesi

    // Oda eklemek için metod
    public void OdaEkle(Oda oda)
    {
        Odalar.Add(oda);
    }

    public void OdalariListele()
    {
        Console.WriteLine($"{Ad} adlı evin odaları:");
        foreach (var oda in Odalar)
        {
            Console.WriteLine($"- {oda.Tip} (Boyut: {oda.Boyut} metrekare)");
        }
    }
}

// Oda sınıfı: Bir odayı temsil eder.
public class Oda
{
    public string Boyut { get; set; }  // Odanın boyutu
    public string Tip { get; set; }  // Odanın tipi (ör. Mutfak, Yatak Odası)
}

// Test Programı
public class Program
{
    public static void Main()
    {
        Ev ev = new Ev { Ad = "Villa Konak" };

        Oda oda1 = new Oda { Boyut = "20", Tip = "Yatak Odası" };
        Oda oda2 = new Oda { Boyut = "15", Tip = "Mutfak" };

        ev.OdaEkle(oda1);
        ev.OdaEkle(oda2);

        ev.OdalariListele();

        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadLine();
    }
}
