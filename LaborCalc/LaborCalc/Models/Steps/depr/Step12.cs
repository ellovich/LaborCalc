namespace LaborCalc.Models;

public partial class Step12 : Step
{
    public override double MethodicId => 12;
    public override string MethodicName => "Проведение испытаний";

    public override double CalcLabor()
    {
        return (K * T) + AddedTables.Sum(t => t.FullLabor);
    }

    public override string CreateHtmlReport()
    {
        string html = $@"
<p>
    Нормы времени на проведение испытаний рассчитываются по формуле 57: <br>
    T<sub>об</sub> = k * t + T<sub>д</sub>
    <br>
    k = {K} н/ч - количество сотрудников, принимающих участие в проведении испытаний </br>
    t = {T} н/ч - длительность испытаний </br>
    Т<sub>д</sub> = { AddedTables.Sum(t => t.FullLabor) } - трудоёмкость подготовки документации:
</p>
    {string.Join("\n", AddedTables.Select(t => t.ToHtml()))}
";

        return html;
    }

    public Step12()
    {

    }


    #region DATA

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] public int k;      // количество сотрудников, принимающих участие в проведении испытаний
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] public double t;   // длительность испытаний (ч)

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] public ObservableRangeCollection<Table> addedTables = new ObservableRangeCollection<Table>();
    //public static List<Table> ReadySteps { get; set; } = Step02.ReadyStepsTables;
    //public static List<Table> SingleSteps { get; set; } = Step02.SingleStepsTables;

    public static readonly List<Correction> s_Corrections_2_9 = Step02.s_Corrections2_9;

    #endregion
}
