namespace CW_2.SerialNumberGenerator;

public static class SerialNumberGenerator
{
    private static int _counter = 0;
    
    public static string GenerateSerialNumber(string containerType)
    {
        _counter++;
        return $"KON-{containerType}-{_counter}";
    }
}
