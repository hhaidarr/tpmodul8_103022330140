using System;
using System.IO;
using System.Text.Json;

public class CovidConfig
{
    public string satuan_suhu { get; set; }
    public int batas_hari_deman { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    private static readonly string configPath = "covid_config.json";

    public CovidConfig()
    {
        LoadConfig();
    }

    private void LoadConfig()
    {
        if (File.Exists(configPath))
        {
            string json = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<CovidConfig>(json);

            satuan_suhu = config.satuan_suhu;
            batas_hari_deman = config.batas_hari_deman;
            pesan_ditolak = config.pesan_ditolak;
            pesan_diterima = config.pesan_diterima;
        }
        else
        {
            SetDefaultConfig();
            SaveConfig();
        }
    }

    private void SetDefaultConfig()
    {
        satuan_suhu = "celcius";
        batas_hari_deman = 14;
        pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
    }

    public void SaveConfig()
    {
        string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(configPath, json);
    }

    public void UbahSatuan()
    {
        satuan_suhu = satuan_suhu.ToLower() == "celcius" ? "fahrenheit" : "celcius";
        SaveConfig();
    }
}
