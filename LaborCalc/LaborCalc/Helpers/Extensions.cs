namespace LaborCalc.Helpers;

public static class Extensions
{
    public static string Out(this double x)
    {
        return x.ToString("0.###");
    }
}
