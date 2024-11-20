using System;

public class Islemci
{
    // İşlemcinin çekirdek sayısını tutan özellik
    public int Cekirdekler { get; set; }

    // İşlemcinin frekansını tutan özellik (MHz cinsinden)
    public int Frekans { get; set; }

    // İşlemcinin bilgilerini ekrana yazdıran metod
    public void IslemciBilgisi()
    {
        Console.WriteLine($"Çekirdek Sayısı: {Cekirdekler}, Frekans: {Frekans} MHz");
    }
}

public class Bilgisayar
{
    // Bilgisayarın modelini tutan özellik
    public string Model { get; set; }

    // Bilgisayarın işlemcisini tutan özellik (Islemci tipinde)
    public Islemci Islemci { get; set; }

    // İşlemciyi oluşturmak için kullanılan metod
    public void IslemciOlustur(int cekirdek, int frekans)
    {
        Islemci = new Islemci { Cekirdekler = cekirdek, Frekans = frekans };
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Kullanıcıdan bilgisayarın modelini alıyoruz
        Console.WriteLine("Bilgisayar modelini giriniz:");
        string model = Console.ReadLine();

        // Kullanıcıdan işlemcinin çekirdek sayısını alıyoruz
        Console.WriteLine("İşlemci çekirdek sayısını giriniz:");
        int cekirdek = int.Parse(Console.ReadLine());

        // Kullanıcıdan işlemcinin frekansını alıyoruz
        Console.WriteLine("İşlemci frekansını (MHz) giriniz:");
        int frekans = int.Parse(Console.ReadLine());

        // Bilgisayar ve işlemci nesnelerini oluşturuyoruz
        Bilgisayar bilgisayar = new Bilgisayar { Model = model };
        bilgisayar.IslemciOlustur(cekirdek, frekans);

        // İşlemcinin bilgilerini ekrana yazdırıyoruz
        bilgisayar.Islemci.IslemciBilgisi();
    }
}
