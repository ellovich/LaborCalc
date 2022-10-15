﻿namespace LaborCalc.Models;

public partial class Step03_8 : Step // TODO нужна ли корректировка
{
    public override double MethodicId => 3.8;
    public override string MethodicName => "Проведение сравнительных расчётов посадки и остойчивости";

    public override double CalcLabor()
    {
        return N_ср * _q_ср;
    }

    public override Report CreateReport()
    {
        string html = $@"
<p>
    Трудоёмкость проведения сравнительных расчётов посадки и остойчивости определяется по формуле:</br>
    T<sub>ср</sub> = n<sub>ср</sub> ⋅ q<sub>ср</sub> <br>
    где<br>
    n<sub>ср</sub> = {N_ср} ед. - количество производимых расчётов <br>
    q<sub>ср</sub> = {_q_ср.Out()} - укрупненная норма времени одного расчёта <br>
</p>
";
        return new Report(this, html);
    }

    public Step03_8()
    {

    }


    #region DATA

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] int n_ср;

    private double _q_ср = 0.5;

    #endregion DATA
}