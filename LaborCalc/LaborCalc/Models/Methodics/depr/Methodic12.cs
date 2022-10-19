namespace LaborCalc.Models;

public partial class Methodic12 : Methodic
{
    public override double MethodicId => 12;
    public override string MethodicName => "Проведение испытаний";

    protected override double CalcLabor()
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

    public Methodic12()
    {

    }


    #region DATA

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] public int k;      // количество сотрудников, принимающих участие в проведении испытаний
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] public double t;   // длительность испытаний (ч)

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] public ObservableRangeCollection<Table> addedTables = new ObservableRangeCollection<Table>();
    //public static List<Table> ReadyMethodics { get; set; } = Methodic02.ReadyMethodicsTables;
    //public static List<Table> SingleMethodics { get; set; } = Methodic02.SingleMethodicsTables;

    public static readonly List<Correction> s_Corrections_2_9 = Methodic02.s_Corrections2_9;

    #endregion
}
