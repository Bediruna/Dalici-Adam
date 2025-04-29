namespace DaliciAdam;

public class OyunFonksiyonlar
{
    public static void IlkMaddeleriEkle()
    {
        DaliciAdam.Envantar.Add(new Madde()
        {
            Isim = "Fener",
            Tarif = "Karanlikda onunu gorebilmen icin kullanabildigin fener.",
            Agirlik = 5,
            Fiyat = 50,
            Miktar = 1

        });
        DaliciAdam.Envantar.Add(new Madde()
        {
            Isim = "Zipkin",
            Tarif = "Ziplamak icin kulandigin zipkin.",
            Agirlik = 3,
            Fiyat = 50,
            Miktar = 1
        });
        DaliciAdam.Envantar.Add(new Madde()
        {
            Isim = "Oksijen Tupu",
            Tarif = "Suyun altinda nefes alabilmeni sagliyan cihaz.",
            Agirlik = 3,
            Fiyat = 50,
            Miktar = 1
        });
    }

    public static void SonDurumGoster()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        GenelFonksiyonlar.Yaz("=============Durum================");
        GenelFonksiyonlar.Yaz("|| Can:\t\t" + DaliciAdam.Can + "\t\t||");
        GenelFonksiyonlar.Yaz("|| Enerji:\t" + DaliciAdam.Enerji + "\t\t||");
        GenelFonksiyonlar.Yaz("|| Para:\t$" + DaliciAdam.Para + "\t\t||");
        GenelFonksiyonlar.Yaz("|| Enlem:\t" + string.Format("{0:0.000000}", DaliciAdam.Enlem) + "\t||");
        GenelFonksiyonlar.Yaz("|| Boylam:\t" + string.Format("{0:0.000000}", DaliciAdam.Boylam) + "\t||");
        GenelFonksiyonlar.Yaz("|| Gun:\t\t" + OyunYonetici.GecenGun + "\t\t||");
        GenelFonksiyonlar.Yaz("==================================");
        Console.ForegroundColor = ConsoleColor.White;
        GenelFonksiyonlar.Yaz();
    }

    public static void SeceneklerGoster()
    {
        GenelFonksiyonlar.Yaz("Şimdi ne yapmak istersin?\n");
        GenelFonksiyonlar.Yaz("1. Yuz");
        GenelFonksiyonlar.Yaz("2. Dinlen");
        GenelFonksiyonlar.Yaz("3. Envanter");
        GenelFonksiyonlar.Yaz("4. Dukkan");
        GenelFonksiyonlar.Yaz("5. Haritaya bak");

        string _val = "";
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("");
                AnaSecenek(_val);
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
    public static void AnaSecenek(string secilenDeger)
    {
        switch (secilenDeger)
        {
            case "1":
                if (DaliciAdam.Enerji > 0)
                {
                    Yuz();
                }
                Console.Clear();
                GenelFonksiyonlar.Yaz("Yeteri kadar enerjin yok suan! Dinlenmen gerekiyor.\n");
                SonDurumGoster();
                SeceneklerGoster();

                break;
            case "2":
                if (DaliciAdam.Enerji < 100)
                {
                    Dinlen();
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                GenelFonksiyonlar.Yaz("Enerjin zaten dolu suan. Dinlenmen gerekmiyor.\n");
                SonDurumGoster();
                SeceneklerGoster();

                break;
            case "3":
                EnvantarGoster();
                break;
            case "4":
                DukkanFonksiyonlar.DukkanaBak();
                break;
            case "5":
                HaritayaBak();
                break;
            default:
                Console.Clear();
                GenelFonksiyonlar.Yaz("Lutfen listedeki sayilardan birini sec\n");
                SonDurumGoster();
                SeceneklerGoster();
                break;
        }
    }

    public static void Yuz()
    {
        OyunYonetici.GecenGun++;
        Random rand = new();
        int uzaklik = rand.Next(500, 4000);
        int enerjiSarfi = rand.Next(10, 60);
        //best case, you can swim to Portugal in 2 years...
        //1 point of latitude/longitude is 111,000 meters(at the equator)
        //1 degree = 60 minutes of arc
        //1 second of arc is ~30 meters
        decimal secondsOfArc = decimal.Divide(uzaklik, 108000);
        DaliciAdam.Enlem += secondsOfArc;
        DaliciAdam.Boylam += secondsOfArc;
        DaliciAdam.Enerji -= enerjiSarfi;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        GenelFonksiyonlar.YazBekle(uzaklik + " metre yuzdun!\n");
        GenelFonksiyonlar.YazBekle(enerjiSarfi + " enerji sarf ettin.\n");

        if (uzaklik % 9 == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            GenelFonksiyonlar.YazBekle("Eyvah! Yuzerken kopek baligi saldirdi!");
            int hasar = rand.Next(10, 60);
            DaliciAdam.Can -= hasar;
            if (DaliciAdam.Can <= 0)
            {
                Ol();
                return;
            }
            GenelFonksiyonlar.YazBekle(hasar + " can kayb ettin.\n");
        }

        SonDurumGoster();
        SeceneklerGoster();
    }
    public static void Dinlen()
    {
        OyunYonetici.GecenGun++;
        Random rand = new();
        int uzaklik = rand.Next(50, 400);
        int enerjiKazanci = rand.Next(10, 60);
        decimal secondsOfArc = decimal.Divide(uzaklik, 108000);
        DaliciAdam.Enlem += secondsOfArc;
        DaliciAdam.Boylam += secondsOfArc;
        DaliciAdam.Enerji += enerjiKazanci;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        GenelFonksiyonlar.YazBekle(uzaklik + " metre suruklendin.\n");
        GenelFonksiyonlar.YazBekle(enerjiKazanci + " enerji kazandin!\n");

        if (uzaklik % 9 == 0)
        {
            GenelFonksiyonlar.YazBekle("Eyvah! Uyurken kopek baligi saldirdi!");
            int hasar = rand.Next(10, 60);
            DaliciAdam.Can -= hasar;
            if (DaliciAdam.Can <= 0)
            {
                Ol();
                return;
            }
            GenelFonksiyonlar.YazBekle(hasar + " can kayb ettin.\n");
        }

        SonDurumGoster();
        SeceneklerGoster();
    }
    public static void EnvantarGoster()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        GenelFonksiyonlar.Yaz("Envantarindakiler:");
        if (DaliciAdam.Envantar.Count != 0)
        {
            foreach (var madde in DaliciAdam.Envantar)
            {
                GenelFonksiyonlar.Yaz("- " + madde.Isim);
            }
        }
        else
        {
            GenelFonksiyonlar.Yaz("Envantarinda bisey yok.");
        }
        GenelFonksiyonlar.Yaz();
        SonDurumGoster();
        SeceneklerGoster();
    }

    public static void HaritayaBak()
    {
        Console.Clear();
        GenelFonksiyonlar.Yaz(Cizimler.DunyaHaritasi);

        Console.SetCursorPosition(40, 10);
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("!");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        GenelFonksiyonlar.SetCursorPositionSafe(0, 33);

        SeceneklerGoster();

        while (true)
        {
            Console.SetCursorPosition(40, 10);
            GenelFonksiyonlar.Bekle(200);
        }
    }

    public static void Ol()
    {
        Console.Clear();
        GenelFonksiyonlar.Yaz("Eyvah! Oldun!");
    }
}
