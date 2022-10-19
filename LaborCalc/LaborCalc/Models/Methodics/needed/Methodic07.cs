using JetBrains.Annotations;

namespace LaborCalc.Models;

public partial class Methodic07 : Methodic
{
    public override double MethodicId => 7;
    public override string MethodicName => "Руководство проектом";

    protected override double CalcLabor() // TODO разобраться
    {
        return 0;

        //var methodics = new ObservableCollection<Methodic>(MethodicsManager.DoneSteps);
        //var methodics7 = new List<Methodic>(methodics.Where(s => s.MethodicId == 7));
        //if (methodics7 != null)
        //    foreach (var s in methodics7)
        //        methodics.Remove(s);
        //return Math.Round(methodics.Sum(st => st.Labor) * ((double)Percent / 100), 2);
    }

    public override string CreateHtmlReport()
    {
        string html = "";

//        string html = $@"
//<p>Затраты времени на руководство проектом зависят от сложности проекта и составляют от 5% до 10% от суммарной трудоемкости всех этапов проекта.</p>
//<p>Введённое значение: {Percent} %</p>
//<p>Суммарная трудоёмкость всех этапов без учета руководства: {(MethodicsManager.FullLabor - Labor).Out()}ч</p>
//";

        

        return html;
    }

    public Methodic07()
    {

    }


    #region DATA

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] int percent = 5; // от 5% до 10%

    #endregion DATA
}
