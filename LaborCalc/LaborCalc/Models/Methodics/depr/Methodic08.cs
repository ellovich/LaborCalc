namespace LaborCalc.Models;

public partial class Methodic08 : Methodic
{
    public override double MethodicId => 8;
    public override string MethodicName => "Разработка КОП и ТП"; // Разработка компьютерных обучающих и тренажерных программ

    protected override double CalcLabor()
    {
        throw new NotImplementedException();
    }

    public override string CreateHtmlReport()
    {
        throw new NotImplementedException();
    }
}
