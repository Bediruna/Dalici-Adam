namespace DaliciAdam;

public static class GenelFonksiyonlar
{
    public static void Bekle(int milliSaniye)
    {
        Thread.Sleep(milliSaniye);
    }
    public static void Yaz(string kelam="")
    {
        Console.WriteLine(kelam);
    }
    public static void YazBekle(string kelam)
    {
        Yaz(kelam);
        Bekle(Sabitler.YazimBeklemeZamani * kelam.Length);
    }
    public static void YazBekle(string kelam, int milliSaniye)
    {
        Yaz(kelam);
        Bekle(milliSaniye);
    }
    public static void KullanicidanOnayIste(string onayIstemMesaji = "(Devam etmek icin her hangi bir tusa bas)")
    {
        Yaz(onayIstemMesaji);
        Console.ReadKey();
        Console.Clear();
    }

    /// <summary>
    /// Sets the console cursor position safely within the buffer boundaries.
    /// If the desired position is outside the buffer, it clamps it to the nearest valid position.
    /// </summary>
    /// <param name="desiredLeft">The desired horizontal position (column).</param>
    /// <param name="desiredTop">The desired vertical position (row).</param>
    /// <returns>A tuple (int Left, int Top) representing the actual coordinates where the cursor was set.</returns>
    /// <exception cref="System.IO.IOException">Thrown if an I/O error occurred (e.g., console output redirected).</exception>
    public static (int Left, int Top) SetCursorPositionSafe(int desiredLeft, int desiredTop)
    {
        // Get buffer dimensions
        int bufferWidth = Console.BufferWidth;
        int bufferHeight = Console.BufferHeight;

        // Clamp the left position
        // Ensure it's not less than 0 and not greater than or equal to the buffer width.
        // Use Math.Max(0, bufferWidth - 1) to handle edge case where bufferWidth might be 0.
        int actualLeft = Math.Max(0, Math.Min(desiredLeft, Math.Max(0, bufferWidth - 1)));

        // Clamp the top position
        // Ensure it's not less than 0 and not greater than or equal to the buffer height.
        // Use Math.Max(0, bufferHeight - 1) to handle edge case where bufferHeight might be 0.
        int actualTop = Math.Max(0, Math.Min(desiredTop, Math.Max(0, bufferHeight - 1)));

        // Set the cursor position using the calculated safe coordinates
        // This might still throw IOException if the console handle is invalid
        Console.SetCursorPosition(actualLeft, actualTop);

        // Return the actual position used
        return (Left: actualLeft, Top: actualTop);
    }
}
