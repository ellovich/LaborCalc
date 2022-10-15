namespace LaborCalc.Models;

public struct Correction
{
    public string Name { get; }
    public double Coef { get; }

    [JsonConstructor]
    public Correction(string name, double coef)
    {
        Name = name;
        Coef = coef;
    }

    public override string ToString()
    {
        return $"{Name} (коэф. = {Coef.Out()})";
    }
}

public readonly struct Coefs
{
    public string Name { get; }
    public Correction[] Corrections { get; }

    [JsonConstructor]
    public Coefs(string name, params Correction[] corrections)
    {
        Name = name;
        Corrections = corrections;
    }

    public override string ToString()
    {
        string str = $"{Name}:\n";
        foreach (var c in Corrections)
            str += c + "\n";

        return str;
    }
} 
