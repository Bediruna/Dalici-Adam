namespace DaliciAdam;

public class BolumYonetici
{
    public static void Bolum1Oyna()
    {
        GenelFonksiyonlar.YazBekle("Merhaba dalici adam!");
        GenelFonksiyonlar.YazBekle("Benim adim Karides Sam!");
        GenelFonksiyonlar.YazBekle("Bak, ben burdayim ========> .");
        GenelFonksiyonlar.YazBekle("Biraz yaklas");
        GenelFonksiyonlar.KullanicidanOnayIste("(Yaklasmak icin her hangi bir tusa bas)");

        GenelFonksiyonlar.YazBekle(Cizimler.KaridesCizimDetayli, 300);
        GenelFonksiyonlar.YazBekle("Op, biraz cok geldin!");
        GenelFonksiyonlar.KullanicidanOnayIste("(Uzaklasmak icin her hangi bir tusa bas)");

        GenelFonksiyonlar.YazBekle(Cizimler.KaridesCizimHarekeliSol, 300);
        GenelFonksiyonlar.YazBekle("Heh. Daha iyi. Her neyse...");
        GenelFonksiyonlar.Yaz("Senin adin ne?");
        DaliciAdam.Isim = Console.ReadLine();

        GenelFonksiyonlar.YazBekle(DaliciAdam.Isim + ", tanisdigmiza memnun oldum!");
        GenelFonksiyonlar.YazBekle("Sana durumlari gostereyem!");
        GenelFonksiyonlar.KullanicidanOnayIste();
        Bolum2Oyna();
    }
    protected static void Bolum2Oyna()
    {
        GenelFonksiyonlar.Yaz($"Can:\t{DaliciAdam.Can} {Cizimler.OkCizim}");
        GenelFonksiyonlar.YazBekle("Can en ustde ", 2000);
        Console.Clear();

        GenelFonksiyonlar.Yaz($"Can:\t{DaliciAdam.Can}");
        GenelFonksiyonlar.Yaz($"Enerji:\t{DaliciAdam.Enerji} {Cizimler.OkCizim}");
        GenelFonksiyonlar.YazBekle("Enerji canin altinda", 2000);
        Console.Clear();

        GenelFonksiyonlar.Yaz($"Can:\t{DaliciAdam.Can}");
        GenelFonksiyonlar.Yaz($"Enerji:\t{DaliciAdam.Enerji}");
        GenelFonksiyonlar.Yaz($"Enlem:\t{DaliciAdam.Enlem}  {Cizimler.OkCizim}");
        GenelFonksiyonlar.Yaz($"Boylam:\t{DaliciAdam.Boylam} {Cizimler.OkCizim}");
        GenelFonksiyonlar.YazBekle("Sonra koordinatlar", 2000);
        Console.Clear();

        GenelFonksiyonlar.Yaz($"Can:\t{DaliciAdam.Can}");
        GenelFonksiyonlar.Yaz($"Enerji:\t{DaliciAdam.Enerji}");
        GenelFonksiyonlar.Yaz($"Enlem:\t{DaliciAdam.Enlem}");
        GenelFonksiyonlar.Yaz($"Boylam:\t{DaliciAdam.Boylam}");
        GenelFonksiyonlar.Yaz($"Gun:\t{OyunYonetici.GecenGun}  {Cizimler.OkCizim}");
        GenelFonksiyonlar.YazBekle("En son, gecen gunleri gorebilirsin", 2000);
        GenelFonksiyonlar.KullanicidanOnayIste();

        GenelFonksiyonlar.YazBekle($"{DaliciAdam.Isim}, Bugun senin ilk dalışın");
        GenelFonksiyonlar.YazBekle("Atlas okyunusun ortasindayiz\n");
        OyunFonksiyonlar.SonDurumGoster();
        OyunFonksiyonlar.SeceneklerGoster();
    }
}
