namespace LaborCalc.Models;

public partial class Step11 : Step
{
    public override double MethodicId => 11;
    public override string MethodicName => "Обучение специалистов (пользователей) порядку использования СПО";

    public override double CalcLabor()
    {
        return (_T_упд + _T_умм + _T_зан + _T_экз) * Correction.Coef;
    }

    public override string CreateHtmlReport()
    {
        string html = $@"
<p>
   Введенные данные:<br>
   n<sub>зан</sub> = {N_зан} н/ч - количество часов занятий <br>
   n<sub>экз</sub> = {N_экз} н/ч - количество часов на проведение экзаменов / зачётов <br>
   k<sub>Нов </sub> = {Correction.Coef} - cтепень корректировки ({Correction.Name.ToLower()}) <br>
</p>
<p>
   Общая трудоёмкость обучения специалистов (командного состава судна) порядку использования СПО определяется по формуле 44: <br>
   T<sub>обуч</sub> = Т<sub>упд</sub> + Т<sub>умм</sub> + Т<sub>зан</sub> + Т<sub>экз</sub> <br>
   где<br>
   Т<sub>упд</sub> = {_T_упд.Out()} н/ч - трудоёмкости создания учебно-плановой документации <br>
   Т<sub>умм</sub> = {_T_умм.Out()} н/ч - трудоёмкости разработки учебно-методических материалов для проведения занятий <br>
   Т<sub>зан</sub> = {_T_зан.Out()} н/ч - трудоёмкости подготовки и проведения занятий <br>
   Т<sub>экз</sub> = {_T_экз.Out()} н/ч - трудоёмкости подготовки и проведения экзамена (зачета) <br>
</p>
";

        return html;
    }

    public Step11()
    {
        //this.WhenAnyValue(
        //    x => x.N_зан,
        //    x => x.N_экз,
        //    x => x.Correction).Subscribe((_) => CalcLabor());
    }


    #region DATA

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] int n_зан; // количество часов занятий
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] int n_экз; // количество часов экзаменов
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] Correction correction;

    private double _T_упд => 0.1 * N_зан * (_q_уп + _q_тп); // (ф.45, п.11.2, c.75) // трудоемкости создания учебно-плановой документации
    private double _T_умм => 0.1 * N_зан * _q_умм;          // (ф.46, п.11.3, c.75) // трудоемкости разработки учебно-методических материалов для проведения занятий
    private double _T_зан => N_зан * (0.5 * _q_пз + 1);     // (ф.47, п.11.4, c.75) // трудоемкости подготовки и проведения занятий
    private double _T_экз => N_экз * (_q_пэ + _q_экз);      // (ф.48, п.11.5, c.76) // трудоемкости подготовки и проведения экзамена (зачёта)

    // т.11-1 (c.74)
    private readonly double _q_уп = 1.6; // разработка учебной программы
    private readonly double _q_тп = 0.8; // разработка тематического плана
    private readonly double _q_умм = 32; // разработка учебно-методических материалов
    private readonly double _q_пз = 2;   // подготовка к проведению двухчасового занятия
    private readonly double _q_пэ = 4;   // подготовка к проведению экзамена/зачёта
    private readonly double _q_экз = 4;  // проведение экзамена/зачёта

    public static readonly List<Correction> s_Corrections11_2 = new()
    {
        new Correction("Полная разработка", 1),
        new Correction("Очень низкая", 0.15),
        new Correction("Низкая", 0.3),
        new Correction("Средняя", 0.5),
        new Correction("Высокая", 0.7),
        new Correction("Очень высокая", 0.85),
    };

    #endregion DATA
}
