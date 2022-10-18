namespace LaborCalc.Models;

public partial class Methodic10 : Methodic
{
    public override double MethodicId => 10;
    public override string MethodicName => "Экологическая безопасность";

    public Methodic10() { }

    public override double CalcLabor()
    {
        throw new NotImplementedException();
    }

    public override string CreateHtmlReport()
    {
        throw new NotImplementedException();
    }
}
