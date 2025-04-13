// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();

        // Ubah satuan suhu
        config.UbahSatuan();
        Console.WriteLine($"Satuan suhu diubah menjadi: {config.satuan_suhu}");

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hari = int.Parse(Console.ReadLine());

        bool suhuNormal = false;

        if (config.satuan_suhu.ToLower() == "celcius")
        {
            suhuNormal = suhu >= 36.5 && suhu <= 37.5;
        }
        else if (config.satuan_suhu.ToLower() == "fahrenheit")
        {
            suhuNormal = suhu >= 97.7 && suhu <= 99.5;
        }

        if (suhuNormal && hari < config.batas_hari_deman)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        Console.WriteLine("\nTekan enter untuk keluar...");
        Console.ReadLine();
    }
}
