namespace DaliciAdam;

class OyunYonetici
{
    static bool TanitimGoster { get; set; } = true;
    public static List<Madde> Dukkandakiler { get; set; } = [];
    public static int GecenGun { get; set; } = 1;

    static void Main(string[] args)
    {
        TanitimGoster = false;
        OyunuHazirla();
        if (TanitimGoster)
        {
            BolumYonetici.Bolum1Oyna();
        }
        else
        {
            OyunFonksiyonlar.SonDurumGoster();
            OyunFonksiyonlar.SeceneklerGoster();
        }
        Console.ReadKey();
    }
    protected static void OyunuHazirla()
    {
        OyunFonksiyonlar.IlkMaddeleriEkle();
        DukkanFonksiyonlar.DukkaniDoldur();
    }

}