using JetBrains.Annotations;

namespace LaborCalc.Models;

public partial class Step07 : Step
{
    public override double MethodicId => 7;
    public override string MethodicName => "Руководство проектом";

    public override double CalcLabor() // TODO разобраться
    {
        return 0;

        //var steps = new ObservableCollection<Step>(StepsManager.DoneSteps);
        //var steps7 = new List<Step>(steps.Where(s => s.MethodicId == 7));
        //if (steps7 != null)
        //    foreach (var s in steps7)
        //        steps.Remove(s);
        //return Math.Round(steps.Sum(st => st.Labor) * ((double)Percent / 100), 2);
    }

    public override string CreateHtmlReport()
    {
        string html = "";

//        string html = $@"
//<p>Затраты времени на руководство проектом зависят от сложности проекта и составляют от 5% до 10% от суммарной трудоемкости всех этапов проекта.</p>
//<p>Введённое значение: {Percent} %</p>
//<p>Суммарная трудоёмкость всех этапов без учета руководства: {(StepsManager.FullLabor - Labor).Out()}ч</p>
//";

        

        return html;
    }

    public Step07()
    {

    }


    #region DATA

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] int percent = 5; // от 5% до 10%

    #endregion DATA
}
