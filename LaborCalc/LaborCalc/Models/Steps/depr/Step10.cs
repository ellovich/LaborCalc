namespace LaborCalc.Models;

public partial class Step10 : Step
{
    public override double MethodicId => 10;
    public override string MethodicName => "Экологическая безопасность";

    public Step10() { }

    public override double CalcLabor()
    {
        throw new NotImplementedException();
    }

    public override Report CreateReport()
    {
        throw new NotImplementedException();
    }
}
