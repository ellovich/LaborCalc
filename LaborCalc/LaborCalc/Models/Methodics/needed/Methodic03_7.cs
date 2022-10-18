namespace LaborCalc.Models;

public partial class Methodic03_7 : Methodic // TODO не выставляются коэффициенты в конструкторе
{
    public override double MethodicId => 3.7;
    public override string MethodicName => "Корректировка информационных массивов (ИМ) СПО по результатам кренования корабля/судна и тарировки (проливки) цистерн";

    public override double CalcLabor()
    {
        return _t5 + _t9 + _t10;
    }

    private string RowHtmlCreator(int i, string T_name, string formula, double val, params string[] vars)
    {
        return $@"
<tr>
    <td>
        t<sub>{i}</sub>
    </td>
    <td>
        {T_name}
    </td>
    <td>
        <tt>
        t<sub>{i}</sub> = {formula}
        </tt>
    </td>
    <td>
        <tt>
            {string.Join("<br>", vars)}
        </tt>
    </td>
    <td>
        {val.Out()}
    </td>
</tr>
";
    }

    public override string CreateHtmlReport()
    {
        #region rows
        string rowT1 = RowHtmlCreator(1, T1, "q<sub>пш</sub> ⋅ n<sub>пш</sub> ⋅ k<sub>1</sub> ⋅ k<sub>нов</sub>", _t1, new string[] {
            $"q<sub>пш</sub> = {_q_пш.Out()}",
            $"n<sub>пш</sub> = {N_пш}",
            $"k<sub>1</sub> = {K1.Coef.Out()}",
            $"k<sub>нов</sub> = {K_нов_1.Coef.Out()}" });
        string rowT5 = RowHtmlCreator(5, T5, "(t<sub>1</sub> ⋅ k<sub>5</sub> ⋅ k<sub>нов</sub>) / k<sub>1</sub>", _t5, new string[] {
            $"t<sub>1</sub> = {_t1.Out()}",
            $"k<sub>5</sub> = {_k5.Out()}",
            $"k<sub>нов</sub> = {K_нов_5.Coef.Out()}",
            $"k<sub>1</sub> = {K1.Coef.Out()}" });
        string rowT8 = RowHtmlCreator(8, T8, "q<sub>ВО</sub> ⋅ n<sub>ВО</sub> ⋅ k<sub>8</sub> ⋅ k<sub>нов</sub>", _t8, new string[] {
            $"q<sub>ВО</sub> = {_q_ВО.Out()}",
            $"n<sub>ВО</sub> = {N_ВО}",
            $"k<sub>8</sub> = {K8.Coef.Out()}",
            $"k<sub>нов</sub> = {K_нов_8.Coef.Out()}" });
        string rowT9 = RowHtmlCreator(9, T9, "t<sub>8</sub> ⋅ k<sub>9</sub> ⋅ k<sub>нов</sub>", _t9, new string[] {
            $"t<sub>8</sub> = {_t8.Out()}",
            $"k<sub>9</sub> = {_k9.Out()}",
            $"k<sub>нов</sub> = {K_нов_9.Coef.Out()}" });
        string rowT10 = RowHtmlCreator(10, T10, "t<sub>8</sub> ⋅ k<sub>10</sub> ⋅ k<sub>нов</sub>", _t10, new string[] {
            $"t<sub>8</sub> = {_t8.Out()}",
            $"k<sub>10</sub> = {K10.Coef.Out()}",
            $"k<sub>нов</sub> = {K_нов_10.Coef.Out()}" });
        #endregion

        string html = $@"
<p>
    Трудоёмкость корректировки информационных массивов (ИМ) СПО по результатам кренования корабля/судна и тарирорвки (проливки) цистерн определяется по формуле:<br>
    T<sub>кк</sub> = t<sub>5</sub> + t<sub>9</sub> + t<sub>10</sub>
</p>

<table>
    <caption>Используемые в расчётах величины t<sub>i</sub></caption>
    <tr>
        <th style=""width:5%"">t<sub>i</sub></th>
        <th>Наименование работы</th>
        <th style=""width:25%"">Формула</th>
        <th style=""width:10%"">Значения</th>
        <th style=""width:15%"">Трудоёмкость</th>
    </tr>
    {(IsT1 ? rowT1 : " ")}
    {(IsT5 ? rowT5 : " ")}
    {(IsT8 ? rowT8 : " ")}
    {(IsT9 ? rowT9 : " ")}
    {(IsT10 ? rowT10 : " ")}
</table>
";

        return html;
    }

    public Methodic03_7()
    {
        K_нов_1 = s_Corrections3_6      [0];//    .First(x => double.Equals(x.Coef, 1));
        K_нов_5 = s_Corrections3_6      [5];//    .First(x => double.Equals(x.Coef, 0.15));
        K_нов_8 = s_Corrections3_6      [0];//    .First(x => double.Equals(x.Coef, 1));
        K_нов_9 = s_Corrections3_6      [5];//    .First(x => double.Equals(x.Coef, 0.15));
        K_нов_10 = s_Corrections3_6     [5];//    .First(x => double.Equals(x.Coef, 0.15));
    }


    #region DATA

    #region ti

    #region t1
    public static string T1 = "Ввод геометрии теоретической поверхности корпуса";
    [NotifyParentProperty(true)] private double _t1 => !IsT1 ? 0 : _q_пш * N_пш * K1.Coef * K_нов_1.Coef;
    private const double _q_пш = 1.6;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t1), nameof(_t5))] public int n_пш;  // количество практических шпангоутов

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t1), nameof(_t5))] Correction k1 = s_Corrections3_4_1[0];

    public static List<Correction> s_Corrections3_4_1 = new()
    {
        new Correction("Традиционные обводы корпуса", 1),
        new Correction("Сложные обводы носовой и кормовой оконечности", 1.2)
    }; // k_1 Cложность геометрии обводов корпуса

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t1), nameof(_t5))] Correction k_нов_1 = s_Corrections3_6[0];

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t1), nameof(_t5))] bool isT1 = true;
    #endregion t1

    #region t5
    public static string T5 = "Ввод постоянных данных по кораблю";
    private double _t5 => !IsT5 ? 0 : _t1 * _k5 * K_нов_5.Coef / K1.Coef;
    private const double _k5 = 2.2;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t5))] Correction k_нов_5 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t5))] bool isT5 = true;
    #endregion t5

    #region t8
    public static string T8 = "Ввод геометрии водонепроницаемых отсеков ";
    private double _t8 => !IsT8 ? 0 : _q_ВО * N_ВО * K8.Coef * K_нов_8.Coef;
    private const double _q_ВО = 10;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t8), nameof(_t9), nameof(_t10))]
    public int n_ВО; // количество ВО (водонипрониц. отсеков) судна, включая газоплотные отделения надстроки

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t8), nameof(_t9), nameof(_t10))]
    Correction k8 = s_Corrections3_4_5[0];

    public static List<Correction> s_Corrections3_4_5 = new()
    {
        new Correction("Традиционная архитектура", 1),
        new Correction("Наличие второго борта и др. особенности", 1.2)
    }; // k_8 Cложность геометрии ВО

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t8), nameof(_t9), nameof(_t10))]
    Correction k_нов_8 = s_Corrections3_6[0];

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t8), nameof(_t9), nameof(_t10))]
    bool isT8 = true;
    #endregion t8

    #region t9
    public static string T9 = "Ввод постоянных данных водонепроницаемых отсеков";
    private double _t9 => !IsT9 ? 0 : _t8 * _k9 * K_нов_9.Coef;
    private const double _k9 = 2.7;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t9))] Correction k_нов_9 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t9))] bool isT9 = true;
    #endregion t9

    #region t10
    public static string T10 = "Ввод данных по датчикам затопления отсеков (заполнения цистерн)";
    private double _t10 => !IsT10 ? 0 : _t8 * K10.Coef * K_нов_10.Coef;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t10))] Correction k10 = s_Corrections3_4_6[0];
    public static List<Correction> s_Corrections3_4_6 = new()
    {
        new Correction("Датчики отсутствуют", 0),
        new Correction("Необходим ввод датчиков", 0.1)
    }; // k_10 Наличие / отсутствие датчиков
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t10))] Correction k_нов_10 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t10))] bool isT10 = true;
    #endregion t10

    #endregion ti


    #region CORRECTION

    public static List<Correction> s_Corrections3_6 = new()
    {
        new Correction("Полная разработка", 1),
        new Correction("Очень высокий", 0.85),
        new Correction("Высокий", 0.70),
        new Correction("Средний", 0.5),
        new Correction("Низкий", 0.3),
        new Correction("Очень низкий", 0.15),
        new Correction("Не требуется", 0)
    }; // k_нов Коэффициент новизны разработки

    private Correction _methodicCorrection = s_Corrections3_6[0]; // общий коэффициент новизны работы
    public Correction MethodicCorrection // Reactive
    {
        get => _methodicCorrection;
        set
        {
            K_нов_1 = K_нов_5 = K_нов_8 = K_нов_9 = K_нов_10 = value;
            this.SetProperty(ref _methodicCorrection, value);
        }
    }

    #endregion CORRECTION

    #endregion DATA
}
