namespace LaborCalc.Models;

public partial class Methodic15 : Methodic
{
    public override double MethodicId => 15;
    public override string MethodicName => "Сертификация программного обеспечения";

    public Methodic15() { }

    public override string CreateHtmlReport()
    {
/*
15.1 Трудоемкость работ по сертификации программного обеспечения принимается
равной трудоемкости внедрения соответствующего программного обеспечения и рассчитывается
согласно разделу 1 настоящей Методики.
15.2 Трудоёмкость корректировки программного обеспечения по замечаниям возникшим в
процессе сертификации принимается равной 10 % трудоёмкости работ по сертификации.
*/
        throw new NotImplementedException();
    }

    protected override double CalcLabor()
    {
        throw new NotImplementedException();
    }
}
