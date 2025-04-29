namespace DaliciAdam;

public static class DukkanFonksiyonlar
{
    public static void DukkanaBak()
    {
        Console.Clear();
        OyunFonksiyonlar.SonDurumGoster();
        Console.ForegroundColor = ConsoleColor.Yellow;
        GenelFonksiyonlar.Yaz("Dukkandakiler:");
        GenelFonksiyonlar.Yaz("0. Geri Don");
        if (OyunYonetici.Dukkandakiler.Count != 0)
        {
            for (int i = 0; i < OyunYonetici.Dukkandakiler.Count; i++)
            {
                Madde madde = OyunYonetici.Dukkandakiler[i];
                Console.Write($"{i + 1}. {madde.Isim}");
                if (madde.Isim.Length < 4)
                {
                    Console.Write("\t");
                }
                Console.Write("\t");

                Console.Write($"${madde.Fiyat}\n");
            }
        }
        else
        {
            GenelFonksiyonlar.Yaz("Dukkanda bisey yok.");
        }
        GenelFonksiyonlar.Yaz();

        string _val = "";
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("");
                SatinAl(_val);
            }
            if (key.Key != ConsoleKey.Backspace)
            {
                bool _x = double.TryParse(key.KeyChar.ToString(), out _);
                if (_x && _val.Length < 1)
                {
                    _val += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
            else
            {
                if (key.Key == ConsoleKey.Backspace && _val.Length > 0)
                {
                    _val = _val.Substring(0, (_val.Length - 1));
                    Console.Write("\b \b");
                }
            }
        }
        // Stops Receving Keys Once Enter is Pressed
        while (key.Key != ConsoleKey.Enter);
    }

    public static void DukkaniDoldur()
    {
        OyunYonetici.Dukkandakiler.Add(new Madde()
        {
            Isim = "Yem",
            Tarif = "Av cezb edebilmek icin kullanilan yem.",
            Agirlik = .2,
            Fiyat = 1,
            Miktar = 100

        });
        OyunYonetici.Dukkandakiler.Add(new Madde()
        {
            Isim = "Agri kesici",
            Tarif = "Canini 100 artiran ari kesici.",
            Agirlik = 1,
            Fiyat = 5,
            Miktar = 100
        });
        OyunYonetici.Dukkandakiler.Add(new Madde()
        {
            Isim = "Hizli Palet",
            Tarif = "Daha hizli ve uzaga yuzebilmeni sagliyan palet.",
            Agirlik = 3,
            Fiyat = 50,
            Miktar = 1
        });
        OyunYonetici.Dukkandakiler.Add(new Madde()
        {
            Isim = "Mıknatıs",
            Tarif = "Kopek baliklarini engelemek icin kullanilan miknatis.",
            Agirlik = 3,
            Fiyat = 150,
            Miktar = 1
        });
    }
    public static void SatinAl(string secilenDeger)
    {
        Console.Clear();

        var secilenDegerSayi = Int32.Parse(secilenDeger);
        if (secilenDegerSayi != 0)
        {
            var satinAlinanMadde = OyunYonetici.Dukkandakiler[secilenDegerSayi - 1];

            if (DaliciAdam.Para < satinAlinanMadde.Fiyat)
            {
                GenelFonksiyonlar.Yaz($"Suan {satinAlinanMadde.Isim} icin yeteri paran yok!");
            }
            else
            {

                GenelFonksiyonlar.Yaz(satinAlinanMadde.Isim + " satin aldin!");
                DaliciAdam.Envantar.Add(satinAlinanMadde);
                DaliciAdam.Para -= satinAlinanMadde.Fiyat;
            }
        }
        GenelFonksiyonlar.Yaz();
        OyunFonksiyonlar.SonDurumGoster();
        OyunFonksiyonlar.SeceneklerGoster();
    }
}