using System;

public class Motor
{
    // Motorun gücünü tutan özellik (HP cinsinden)
    public int Guc { get; set; }

    // Motorun tipini tutan özellik (Benzin, Dizel vb.)
    public string Tip { get; set; }

    // Motor bilgilerini ekrana yazdıran metod
    public void MotorBilgisi()
    {
        Console.WriteLine($"Motor Gücü: {Guc} HP, Motor Tipi: {Tip}");
    }
}

public class Otomobil
{
    // Otomobilin markasını tutan özellik
    public string Marka { get; set; }

    // Otomobilin motorunu tutan özellik (Motor tipinde)
    public Motor Motor { get; set; }

    // Motoru oluşturmak için kullanılan metod
    public void MotorOlustur(int guc, string tip)
    {
        Motor = new Motor { Guc = guc, Tip = tip };
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Kullanıcıdan otomobilin markasını alıyoruz
        Console.WriteLine("Otomobil markasını giriniz:");
        string marka = Console.ReadLine();

        // Kullanıcıdan motorun gücünü alıyoruz
        Console.WriteLine("Motor gücünü (HP) giriniz:");
        int guc = int.Parse(Console.ReadLine());

        // Kullanıcıdan motorun tipini alıyoruz
        Console.WriteLine("Motor tipini giriniz (ör. Benzin/Dizel):");
        string tip = Console.ReadLine();

        // Otomobil ve motor nesnelerini oluşturuyoruz
        Otomobil otomobil = new Otomobil { Marka = marka };
        otomobil.MotorOlustur(guc, tip);

        // Motor bilgilerini ekrana yazdırıyoruz
        otomobil.Motor.MotorBilgisi();
    }
}
