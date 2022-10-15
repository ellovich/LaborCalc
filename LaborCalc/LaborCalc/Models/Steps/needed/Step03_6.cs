namespace LaborCalc.Models;

public partial class Step03_6 : Step // TODO нужна ли корректировка
{
    public override double MethodicId => 3.6;
    public override string MethodicName => "Разработка протокола сопряжения с внешними (по отношению к СПО СИП БЖ) системами";

    public override double CalcLabor()
    {
        return Protocols * _norm;
    }

    public override Report CreateReport()
    {
        string html = $@"
<p>
    Трудоемкость разработки протокола сопряжения с внешними (по отношению к СПО СИП БЖ)
    системами комплексами корабля/судна составляет 56 нормо-часов на один протокол.
</p>
<p>Количество протоколов: {Protocols} ед.</p>
";
        return new Report(this, html);
    }

    public Step03_6()
    {

    }


    #region DATA

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] int protocols;

    private double _norm = 56;

    #endregion DATA
}
