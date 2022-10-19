namespace LaborCalc.Models;

public partial class Methodic03_2 : Methodic // уведомлять ti
{
    public override double MethodicId => 3.2;
    public override string MethodicName => "Формирование (корректировка) информационных массивов (ИМ) специального программного обеспечения (СПО) СИП БЖ";

    protected override double CalcLabor()
    {
        return _T_Н + _T_БЖ;
    }

    private static string RowHtmlCreator(int i, string T_name, string formula, double val, params string[] vars)
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
        #region ROWS
        // t.3-2
        string rowT1 = RowHtmlCreator(1, T1, "q<sub>пш</sub> ⋅ n<sub>пш</sub> ⋅ k<sub>1</sub> ⋅ k<sub>нов</sub>", _t1, new string[] {
            $"q<sub>пш</sub> = {_q_пш.Out()}",
            $"n<sub>пш</sub> = {N_пш}",
            $"k<sub>1</sub> = {K1.Coef.Out()}",
            $"k<sub>нов</sub> = {K_нов_1.Coef.Out()}" });
        string rowT2 = RowHtmlCreator(2, T2, "(t<sub>1</sub> ⋅ k<sub>2</sub> ⋅ k<sub>нов</sub>) / k<sub>1</sub>", _t2, new string[] {
            $"t<sub>1</sub> = {_t1.Out()}",
            $"k<sub>2</sub> = {_k2.Out()} (n<sub>пал</sub> = {N_пал_Н})",
            $"k<sub>нов</sub> = {K_нов_2.Coef.Out()}",
            $"k<sub>1</sub> = {K1.Coef.Out()}" });
        string rowT3 = RowHtmlCreator(3, T3, "(t<sub>1</sub> ⋅ k<sub>3</sub> ⋅ k<sub>нов</sub>) / k<sub>1</sub>", _t3, new string[] {
            $"t<sub>1</sub> = {_t1.Out()}",
            $"k<sub>3</sub> = {K3.Coef.Out()}",
            $"k<sub>нов</sub> = {K_нов_3.Coef.Out()}",
            $"k<sub>1</sub> = {K1.Coef.Out()}" });
        string rowT4 = RowHtmlCreator(4, T4, "(t<sub>1</sub> ⋅ k<sub>4</sub> ⋅ k<sub>нов</sub>) / k<sub>1</sub>", _t4, new string[] {
            $"t<sub>1</sub> = {_t1.Out()}",
            $"k<sub>4</sub> = {_k4.Out()}",
            $"k<sub>нов</sub> = {K_нов_4.Coef.Out()}",
            $"k<sub>1</sub> = {K1.Coef.Out()}" });
        string rowT5 = RowHtmlCreator(5, T5, "(t<sub>1</sub> ⋅ k<sub>5</sub> ⋅ k<sub>нов</sub>) / k<sub>1</sub>", _t5, new string[] {
            $"t<sub>1</sub> = {_t1.Out()}",
            $"k<sub>5</sub> = {_k5.Out()}",
            $"k<sub>нов</sub> = {K_нов_5.Coef.Out()}",
            $"k<sub>1</sub> = {K1.Coef.Out()}" });
        string rowT6 = RowHtmlCreator(6, T6, "(t<sub>1</sub> ⋅ k<sub>6</sub> ⋅ k<sub>нов</sub>) / k<sub>1</sub>", _t6, new string[] {
            $"t<sub>1</sub> = {_t1.Out()}",
            $"k<sub>6</sub> = {_k6.Out()}",
            $"k<sub>нов</sub> = {K_нов_6.Coef.Out()}",
            $"k<sub>1</sub> = {K1.Coef.Out()}" });
        string rowT7 = RowHtmlCreator(7, T7, "(t<sub>1</sub> ⋅ k<sub>7</sub> ⋅ k<sub>нов</sub>) / k<sub>1</sub>", _t7, new string[] {
            $"t<sub>1</sub> = {_t1.Out()}",
            $"k<sub>7</sub> = {K7.Coef.Out()}",
            $"k<sub>нов</sub> = {K_нов_7.Coef.Out()}",
            $"k<sub>1</sub> = {K1.Coef.Out()}" });
        // t.3-3
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
        // t.3-5
        string rowT11 = RowHtmlCreator(11, T11, "q<sub>пом</sub> ⋅ n<sub>пом</sub> ⋅ k<sub>11</sub> ⋅ k<sub>нов</sub>", _t11, new string[] {
            $"q<sub>пом</sub> = {_q_пом.Out()}",
            $"n<sub>пом</sub> = {N_пом}",
            $"k<sub>11</sub> = {_k11.Out()}",
            $"k<sub>нов</sub> = {K_нов_11.Coef.Out()}" });
        string rowT12 = RowHtmlCreator(12, T12, "q<sub>АУ</sub> ⋅ n<sub>АУ</sub> ⋅ n<sub>пал</sub> ⋅ k<sub>12</sub> ⋅ k<sub>нов</sub>", _t12, new string[] {
            $"q<sub>АУ</sub> = {_q_АУ.Out()}",
            $"n<sub>АУ</sub> = {N_АУ}",
            $"n<sub>пал</sub> = {N_пал_БЖ}",
            $"k<sub>12</sub> = {_k12.Out()}",
            $"k<sub>нов</sub> = {K_нов_12.Coef.Out()}" });
        string rowT13 = RowHtmlCreator(13, T13, "(t<sub>11</sub> ⋅ k<sub>13</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>", _t13, new string[] {
            $"t<sub>11</sub> = {_t11.Out()}",
            $"k<sub>13</sub> = {_k13.Out()}",
            $"k<sub>нов</sub> = {K_нов_13.Coef.Out()}",
            $"k<sub>11</sub> = {_k11.Out()}" });
        string rowT14 = RowHtmlCreator(14, T14, "(t<sub>11</sub> ⋅ k<sub>14</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>", _t14, new string[] {
            $"t<sub>11</sub> = {_t11.Out()}",
            $"k<sub>14</sub> = {_k14.Out()}",
            $"k<sub>нов</sub> = {K_нов_14.Coef.Out()}",
            $"k<sub>11</sub> = {_k11.Out()}" });
        string rowT15 = RowHtmlCreator(15, T15, "(t<sub>11</sub> ⋅ k<sub>15</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>", _t15, new string[] {
            $"t<sub>11</sub> = {_t11.Out()}",
            $"k<sub>15</sub> = {_k15.Out()}",
            $"k<sub>нов</sub> = {K_нов_15.Coef.Out()}",
            $"k<sub>11</sub> = {_k11.Out()}" });
        string rowT16 = RowHtmlCreator(16, T16, "(t<sub>11</sub> ⋅ k<sub>16</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>", _t16, new string[] {
            $"t<sub>11</sub> = {_t11.Out()}",
            $"k<sub>16</sub> = {_k16.Out()}",
            $"k<sub>нов</sub> = {K_нов_16.Coef.Out()}",
            $"k<sub>11</sub> = {_k11.Out()}" });
        string rowT17 = RowHtmlCreator(17, T17, "(t<sub>12</sub> ⋅ k<sub>17</sub> ⋅ k<sub>нов</sub>) / k<sub>12</sub>", _t17, new string[] {
            $"t<sub>12</sub> = {_t12.Out()}",
            $"k<sub>17</sub> = {_k13.Out()}",
            $"k<sub>нов</sub> = {K_нов_17.Coef.Out()}",
            $"k<sub>12</sub> = {_k12.Out()}" });
        string rowT18 = RowHtmlCreator(18, T18, "(t<sub>11</sub> ⋅ k<sub>18</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>", _t18, new string[] {
            $"t<sub>11</sub> = {_t11.Out()}",
            $"k<sub>18</sub> = {_k18.Out()}",
            $"k<sub>нов</sub> = {K_нов_18.Coef.Out()}",
            $"k<sub>11</sub> = {_k11.Out()}" });
        string rowT19 = RowHtmlCreator(19, T19, "q<sub>ОКС</sub> ⋅ n<sub>ОКС</sub> ⋅ k<sub>19</sub> ⋅ k<sub>нов</sub>", _t19, new string[] {
            $"q<sub>ОКС</sub> = {_q_ОКС.Out()}",
            $"n<sub>ОКС</sub> = {N_ОКС}",
            $"k<sub>19</sub> = {_k19.Out()}",
            $"k<sub>нов</sub> = {K_нов_19.Coef.Out()}" });
        string rowT20 = RowHtmlCreator(20, T20, "(t<sub>19</sub> ⋅ k<sub>20</sub> ⋅ k<sub>нов</sub>) / k<sub>19</sub>", _t20, new string[] {
            $"t<sub>19</sub> = {_t19.Out()}",
            $"k<sub>20</sub> = {_k20.Out()}",
            $"k<sub>нов</sub> = {K_нов_20.Coef.Out()}",
            $"k<sub>19</sub> = {_k19.Out()}" });
        string rowT21 = RowHtmlCreator(21, T21, "(t<sub>11</sub> ⋅ k<sub>21</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>", _t21, new string[] {
            $"t<sub>11</sub> = {_t11.Out()}",
            $"k<sub>21</sub> = {_k21.Out()}",
            $"k<sub>нов</sub> = {K_нов_21.Coef.Out()}",
            $"k<sub>11</sub> = {_k11.Out()}" });
        string rowT22 = RowHtmlCreator(22, T22, "(t<sub>11</sub> ⋅ k<sub>22</sub> ⋅ k<sub>нов</sub>) / k<sub>11</sub>", _t22, new string[] {
            $"t<sub>11</sub> = {_t11.Out()}",
            $"k<sub>22</sub> = {_k22.Out()}",
            $"k<sub>нов</sub> = {K_нов_22.Coef.Out()}",
            $"k<sub>11</sub> = {_k11.Out()}" });
        string rowT23 = RowHtmlCreator(23, T23, "(t<sub>19</sub> ⋅ k<sub>23</sub> ⋅ k<sub>нов</sub>) / k<sub>19</sub>", _t23, new string[] {
            $"t<sub>19</sub> = {_t19.Out()}",
            $"k<sub>23</sub> = {_k23.Out()}",
            $"k<sub>нов</sub> = {K_нов_23.Coef.Out()}",
            $"k<sub>19</sub> = {_k19.Out()}" });
        string rowT24 = RowHtmlCreator(24, T24, "(t<sub>12</sub> ⋅ k<sub>24</sub> ⋅ k<sub>нов</sub>) / k<sub>12</sub>", _t24, new string[] {
            $"t<sub>12</sub> = {_t12.Out()}",
            $"k<sub>24</sub> = {_k24.Out()}",
            $"k<sub>нов</sub> = {K_нов_24.Coef.Out()}",
            $"k<sub>12</sub> = {_k12.Out()}" });
        string rowT25 = RowHtmlCreator(25, T25, "q<sub>АК</sub> ⋅ n<sub>АК</sub> ⋅ k<sub>25</sub> ⋅ k<sub>нов</sub>", _t25, new string[] {
            $"q<sub>АК</sub> = {_q_АК.Out()}",
            $"n<sub>АК</sub> = {N_АК}",
            $"k<sub>25</sub> = {_k25.Out()}",
            $"k<sub>нов</sub> = {K_нов_25.Coef.Out()}" });
        #endregion

        string html = $@"
Общая трудоёмкость формирования ИМ СПО СИП БЖ (T<sub>ИМ</sub>) определяется по формуле:
T<sub>ИМ</sub> = T<sub>Н</sub> + T<sub>БЖ</sub> <br>
где<br>
T<sub>Н</sub> = {_T_Н} н/ч - трудоёмкость формирования (корректировки) ИМ задач непотопляемости <br>
T<sub>БЖ</sub> = {_T_БЖ} н/ч - трудоёмкость формирования (корректировки) ИМ задач борьбы с пожаром и водой. Определяется суммой трудоёмкостей работ таблицы 3-5 <br>
<br>

{(IsT_К && IsT_ВО ?
$@"
T<sub>Н</sub> = T<sub>К</sub> + T<sub>ВО</sub> <br>
где <br>
T<sub>К</sub> = {_T_K} н/ч - трудоёмкости заполнения (корректировки) ИМ задач непотопляемости в части данных по кораблю/судну в целом. Определяется суммой трудоёмкостей работ таблицы 3-2<br>
T<sub>ВО</sub> = {_T_ВО} н/ч - трудоёкости формирования (корректировки) ИМ задач непотопляемости в части данных по ВО корпуса, включая газоплотные отделения надстройки корабля/судна. Определяется суммой трудоёмкостей работ таблицы 3-3 <br>
" : "")}

{(IsT_К ?
$@"
<table>
    <caption>т.3-2 Определение трудоёмкости работ по формированию (корректировке) ИМ в части данных по кораблю (судну) в целом</caption>
    <tr>
        <th style=""width:5%"">t<sub>i</sub></th>
        <th>Наименование работы</th>
        <th style=""width:20%"">Формула</th>
        <th style=""width:10%"">Значения</th>
        <th style=""width:12%"">Трудоёмкость</th>
    </tr>
    {(IsT1 ? rowT1 : " ")}
    {(IsT2 ? rowT2 : " ")}
    {(IsT3 ? rowT3 : " ")}
    {(IsT4 ? rowT4 : " ")}
    {(IsT5 ? rowT5 : " ")}
    {(IsT6 ? rowT6 : " ")}
    {(IsT7 ? rowT7 : " ")}  
</table>
" : "")}

{(IsT_ВО ?
$@"
<table>
    <caption>т.3-3 Трудоёмкость работ по заполнению (корректировке) ИМ в части данных по ВО корпуса</caption>
    <tr>
        <th style=""width:5%"">t<sub>i</sub></th>
        <th>Наименование работы</th>
        <th style=""width:20%"">Формула</th>
        <th style=""width:10%"">Значения</th>
        <th style=""width:12%"">Трудоёмкость</th>
    </tr>
    {(IsT8 ? rowT8 : " ")}
    {(IsT9 ? rowT9 : " ")}
    {(IsT10 ? rowT10 : " ")}    
</table>
" : "")}

{(IsT_БЖ ?
$@"
<table>
    <caption>т.3-5 Порядок определения трудоёмкости заполнения ИМ в части данных задач борьбы с пожаром и водой</caption>
    <tr>
        <th style=""width:5%"">t<sub>i</sub></th>
        <th>Наименование работы</th>
        <th style=""width:20%"">Формула</th>
        <th style=""width:10%"">Значения</th>
        <th style=""width:12%"">Трудоёмкость</th>
    </tr>
    {(IsT11 ? rowT11 : " ")}
    {(IsT12 ? rowT12 : " ")}
    {(IsT13 ? rowT13 : " ")}
    {(IsT14 ? rowT14 : " ")}
    {(IsT15 ? rowT15 : " ")}
    {(IsT16 ? rowT16 : " ")}
    {(IsT17 ? rowT17 : " ")}  
    {(IsT18 ? rowT18 : " ")}  
    {(IsT19 ? rowT19 : " ")}  
    {(IsT20 ? rowT20 : " ")}  
    {(IsT21 ? rowT21 : " ")}  
    {(IsT22 ? rowT22 : " ")}  
    {(IsT23 ? rowT23 : " ")}  
    {(IsT24 ? rowT24 : " ")}  
    {(IsT25 ? rowT25 : " ")}  
</table>
" : "")}

";

        return html;
    }

    public Methodic03_2()
    {

    }


    #region DATA

    #region НЕПОТОПЛЯЕМОСТЬ _T_Н

    private double _T_Н => _T_K + _T_ВО;


    #region T_К

    private bool _isT_К = true;
    public bool IsT_К // Reactive
    {
        get => _isT_К;
        set
        {
            IsT1 = IsT2 = IsT3 = IsT4 = IsT5 = IsT6 = IsT7 = value;
            this.SetProperty(ref _isT_К, value);
        }
    }

    private double _T_K => _t1 + _t2 + _t3 + _t4 + _t5 + _t6 + _t7; // трудоёмкость ввода данных по кораблю в целом


    #region _t 1-7 (t.3-2)

    #region t1
    public static string T1 = "Ввод геометрии теоретической поверхности корпуса";
    [NotifyParentProperty(true)] private double _t1 => !IsT1 ? 0 : _q_пш * N_пш * K1.Coef * K_нов_1.Coef;
    private const double _q_пш = 1.6;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t1), nameof(_t2), nameof(_t3),
        nameof(_t4), nameof(_t5), nameof(_t6), nameof(_t7))] public int n_пш;  // количество практических шпангоутов

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t1), nameof(_t2), nameof(_t3),
        nameof(_t4), nameof(_t5), nameof(_t6), nameof(_t7))] Correction k1 = s_Corrections3_4_1[0];

    public static List<Correction> s_Corrections3_4_1 = new()
    {
        new Correction("Традиционные обводы корпуса", 1),
        new Correction("Сложные обводы носовой и кормовой оконечности", 1.2)
    }; // k_1 Cложность геометрии обводов корпуса

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t1), nameof(_t2), nameof(_t3),
        nameof(_t4), nameof(_t5), nameof(_t6), nameof(_t7))] Correction k_нов_1 = s_Corrections3_6[0];

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t1), nameof(_t2), nameof(_t3),
        nameof(_t4), nameof(_t5), nameof(_t6), nameof(_t7))] bool isT1 = true;
    #endregion t1

    #region t2
    public static string T2 = "Ввод геометрии палуб, платформ, ярусов надстроек и др.";
    private double _t2 => !IsT2 ? 0 : _t1 * _k2 * K_нов_2.Coef / K1.Coef;
    private double _k2 => N_пал_Н < 6 ? 1.8 : 1.8 + 0.1 * (N_пал_Н - 5); // выбор делается автоматически
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t2))] public int n_пал_Н; // количество палуб, платформ и ярусов надстроки (исп. в k2)
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t2))] Correction k_нов_2 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t2))] bool isT2 = true;
    #endregion t2

    #region t3 
    public static string T3 = "Ввод геометрии выступающих частей";
    private double _t3 => !IsT3 ? 0 : _t1 * K3.Coef * K_нов_3.Coef / K1.Coef;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t3))] Correction k3 = s_Corrections3_4_3[0];
    public static List<Correction> s_Corrections3_4_3 = new()
    {
        new Correction("3 и менее", 1),
        new Correction("Более 3", 1.1)
    }; // k_3 Количество выступающих частей 
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t3))] Correction k_нов_3 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t3))] bool isT3 = true;
    #endregion t3

    #region t4
    public static string T4 = "Ввод геометрии зон обледенения";
    private double _t4 => !IsT4 ? 0 : _t1 * _k4 * K_нов_4.Coef / K1.Coef;
    private const double _k4 = 3.0;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t4))] Correction k_нов_4 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t4))] bool isT4 = true;
    #endregion t4

    #region t5
    public static string T5 = "Ввод постоянных данных по кораблю";
    private double _t5 => !IsT5 ? 0 : _t1 * _k5 * K_нов_5.Coef / K1.Coef;
    private const double _k5 = 2.2;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t5))] Correction k_нов_5 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t5))] bool isT5 = true;
    #endregion t5

    #region t6
    public static string T6 = "Ввод данных по штатным твердым грузам";
    private double _t6 => !IsT6 ? 0 : _t1 * _k6 * K_нов_6.Coef / K1.Coef;
    private const double _k6 = 1.0;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t6))] Correction k_нов_6 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t6))] bool isT6 = true;
    #endregion t6

    #region t7
    public static string T7 = "Ввод данных по возимым грузам";
    private double _t7 => !IsT7 ? 0 : _t1 * K7.Coef * K_нов_7.Coef / K1.Coef;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t7))] Correction k7 = s_Corrections3_4_4[0];
    public static List<Correction> s_Corrections3_4_4 = new()
    {
        new Correction("Не предусмотрены", 0),
        new Correction("Контейнеры", 1.0),
        new Correction("Жидкие грузы", 1.1),
        new Correction("Десант", 1.3)
    }; // k_7 Вид, номенклатура, расположение массы возимых грузов
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t7))] Correction k_нов_7 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t7))] bool isT7 = true;
    #endregion t7

    #endregion _t 1-7 (t.3-2)


    #endregion T_К


    #region T_ВО

    private bool _isT_ВО = true;
    public bool IsT_ВО // Reactive
    {
        get => _isT_ВО;
        set
        {
            IsT8 = IsT9 = IsT10 = value;
            this.SetProperty(ref _isT_ВО, value);
        }
    }

    private double _T_ВО => _t8 + _t9 + _t10; // трудоёмкость ввода (проверки и корректировки) данных по ВО корпуса


    #region _t 8-10 (t.3-3)

    #region t8
    public static string T8 = "Ввод геометрии водонепроницаемых отсеков ";
    private double _t8 => !IsT8 ? 0 : _q_ВО * N_ВО * K8.Coef * K_нов_8.Coef;
    private const double _q_ВО = 10;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t8), nameof(_t9), nameof(_t10))] public int n_ВО; // количество ВО (водонипрониц. отсеков) судна, включая газоплотные отделения надстроки

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t8), nameof(_t9), nameof(_t10))] Correction k8 = s_Corrections3_4_5[0];

    public static List<Correction> s_Corrections3_4_5 = new()
    {
        new Correction("Традиционная архитектура", 1),
        new Correction("Наличие второго борта и др. особенности", 1.2)
    }; // k_8 Cложность геометрии ВО

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t8), nameof(_t9), nameof(_t10))] Correction k_нов_8 = s_Corrections3_6[0];

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t8), nameof(_t9), nameof(_t10))] bool isT8 = true;
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

    #endregion _t 8-10 (t.3-3)


    #endregion T_ВО


    #endregion НЕПОТОПЛЯЕМОСТЬ _T_Н


    #region ПОЖАРЫ И ВОДА _T_БЖ

    private double _T_БЖ => _t11 + _t12 + _t13 + _t14 + _t15 + _t16 + _t17 + _t18 + _t19 + _t20 +
        _t21 + _t22 + _t23 + _t24 + _t25; // трудоёмкость заполнения (корректировки) ИМ задач непотопляемости в части данных по кораблю в целом

    private bool _isT_БЖ = true;
    public bool IsT_БЖ // Reactive
    {
        get => _isT_БЖ;
        set
        {
            IsT11 = IsT12 = IsT13 = IsT14 = IsT15 = IsT16 = IsT17 = IsT18 = IsT19 = IsT20
                = IsT21 = IsT22 = IsT23 = IsT24 = IsT25 = value;
            this.SetProperty(ref _isT_БЖ, value);
        }
    }


    #region _t 11-25

    // t.3-5
    #region t11
    public static string T11 = "Ввод геометрии корабельных (судовых) помещений";
    [NotifyParentProperty(true)] private double _t11 => !IsT11 ? 0 : _q_пом * N_пом * _k11 * K_нов_11.Coef;
    private const double _q_пом = 0.6;
    private const double _k11 = 1.2;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t11), nameof(_t13), nameof(_t14), nameof(_t15),
        nameof(_t16), nameof(_t18), nameof(_t21), nameof(_t22))] public int n_пом; // количество помещений

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t11), nameof(_t13), nameof(_t14), nameof(_t15),
        nameof(_t16), nameof(_t18), nameof(_t21), nameof(_t22))] Correction k_нов_11 = s_Corrections3_6[0];

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t11), nameof(_t13), nameof(_t14), nameof(_t15),
        nameof(_t16), nameof(_t18), nameof(_t21), nameof(_t22))] bool isT11 = true;
    #endregion t11

    #region t12
    public static string T12 = "Ввод геометрии аварийных участков (АУ) на планах палуб, платформ, ярусов надстроек";
    [NotifyParentProperty(true)] private double _t12 => !IsT12 ? 0 : _q_АУ * N_АУ * N_пал_БЖ * _k12 * K_нов_12.Coef;
    private const double _q_АУ = 1.0;
    private const double _k12 = 0.8;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t12), nameof(_t17), nameof(_t24))] public int n_АУ;  // количество АУ (аварийных участков) (исп. в t12)

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_t12), nameof(K8), nameof(_t17), nameof(_t24))] public int n_пал_БЖ; // количество палуб, платформ и ярусов надстроки (исп. в t12)

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t17), nameof(_t24))] Correction k_нов_12 = s_Corrections3_6[0];

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t17), nameof(_t24))] bool isT12 = true;
    #endregion t12

    #region t13
    public static string T13 = "Ввод в корабельных помещениях расположения и типа дверей, люков, иллюминаторов, трапов и т.п.";
    private double _t13 => !IsT13 ? 0 : _t11 * _k13 * K_нов_13.Coef / _k11;
    private const double _k13 = 2.5;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t13))] Correction k_нов_13 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t13))] bool isT13 = true;
    #endregion t13

    #region t14
    public static string T14 = "Ввод расположения в корабельных помещениях и на открытых палубах средств управления стационарными средствами пожаротушения, удаления воды и вентиляции";
    private double _t14 => !IsT14 ? 0 : _t11 * _k14 * K_нов_14.Coef / _k11;
    private const double _k14 = 2.2;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t14))] Correction k_нов_14 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t14))] bool isT14 = true;
    #endregion t14

    #region t15
    public static string T15 = "Ввод расположения в корабельных помещениях АСИ, СИЗ и средств связи";
    private double _t15 => !IsT15 ? 0 : _t11 * _k15 * K_нов_15.Coef / _k11;
    private const double _k15 = 3.5;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t15))] Correction k_нов_15 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t15))] bool isT15 = true;
    #endregion t15

    #region t16
    public static string T16 = "Ввод данных по особенностям корабельных помещений с точки зрения опасности возникновения пожара, возможности затопления и др.";
    private double _t16 => !IsT16 ? 0 : _t11 * _k16 * K_нов_16.Coef / _k11;
    private const double _k16 = 2.0;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t16))] Correction k_нов_16 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t16))] bool isT16 = true;
    #endregion t16

    #region t17
    public static string T17 = "Ввод данных по особенностям АУ";
    private double _t17 => !IsT17 ? 0 : _t12 * _k17 * K_нов_17.Coef / _k12;
    private const double _k17 = 5.0;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t17))] Correction k_нов_17 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t17))] bool isT17 = true;
    #endregion t17

    #region t18
    public static string T18 = "Ввод расположения в корабельных помещениях устройств обесточивания электрооборудования";
    private double _t18 => !IsT18 ? 0 : _t11 * _k18 * K_нов_18.Coef / _k11;
    private const double _k18 = 3.2;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t18))] Correction k_нов_18 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t18))] bool isT18 = true;
    #endregion t18

    #region t19
    public static string T19 = "Ввод схем трассировки трубопроводов ОКС в привязке к корабельным помещениям";
    private double _t19 => !IsT19 ? 0 : _q_ОКС * N_ОКС * _k19 * K_нов_19.Coef;
    private const double _q_ОКС = 4.5;
    private const double _k19 = 1.3;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t19))] public int n_ОКС; // количество ОКС (общекораб. систем), исп. в СПО СИП БЖ для задач инф. поддержки
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t19))] Correction k_нов_19 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t19))] bool isT19 = true;
    #endregion t19

    #region t20
    public static string T20 = "Ввод расположения в корабельных помещениях органов управления ОКС";
    private double _t20 => !IsT20 ? 0 : _t19 * _k20 * K_нов_20.Coef / _k19;
    private const double _k20 = 3.0;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t20))] Correction k_нов_20 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t20))] bool isT20 = true;
    #endregion t20

    #region t21
    public static string T21 = "Ввод данных по наличию датчиков пожарной сигнализации в корабельных помещениях";
    private double _t21 => !IsT21 ? 0 : _t11 * _k21 * K_нов_21.Coef / _k11;
    private const double _k21 = 0.7;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t21))] Correction k_нов_21 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t21))] bool isT21 = true;
    #endregion t21

    #region t22
    public static string T22 = "Ввод данных по наличию датчиков закрытия дверей и люков";
    private double _t22 => !IsT22 ? 0 : _t11 * _k22 * K_нов_22.Coef / _k11;
    private const double _k22 = 0.8;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t22))] Correction k_нов_22 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t22))] bool isT22 = true;
    #endregion t22

    #region t23
    public static string T23 = "Ввод данных по характеристикам технических средств ОКС";
    private double _t23 => !IsT23 ? 0 : _t19 * _k23 * K_нов_23.Coef / _k19;
    private const double _k23 = 0.8;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t23))] Correction k_нов_23 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t23))] bool isT23 = true;
    #endregion t23

    #region t24
    public static string T24 = "Ввод данных по границам рубежей обороны";
    private double _t24 => !IsT24 ? 0 : _t12 * _k24 * K_нов_24.Coef / _k12;
    private const double _k24 = 1.2;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t24))] Correction k_нов_24 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t24))] bool isT24 = true;
    #endregion t24

    #region t25
    public static string T25 = "Ввод данных по особенностям АК";
    private double _t25 => !IsT25 ? 0 : _q_АК * N_АК * _k25 * K_нов_25.Coef;
    private const double _q_АК = 0.3;
    private const double _k25 = 0.9;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t25))] public int n_АК;  // количество практических шпангоутов
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t25))] Correction k_нов_25 = s_Corrections3_6[0];
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_t25))] bool isT25 = true;
    #endregion t25

    #endregion _t 11-25


    #endregion ПОЖАРЫ И ВОДА _T_БЖ


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
            K_нов_1 = K_нов_2 = K_нов_3 = K_нов_4 = K_нов_5 = K_нов_6
               = K_нов_7 = K_нов_8 = K_нов_9 = K_нов_10 = K_нов_11
               = K_нов_12 = K_нов_13 = K_нов_14 = K_нов_15 = K_нов_16
               = K_нов_17 = K_нов_18 = K_нов_19 = K_нов_20 = K_нов_21
               = K_нов_22 = K_нов_23 = K_нов_24 = K_нов_25 = value;

            this.SetProperty(ref _methodicCorrection, value);
        }
    }

    #endregion CORRECTION

    #endregion DATA
}