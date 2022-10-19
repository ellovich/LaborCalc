namespace LaborCalc.Models;

public partial class Methodic03_9 : Methodic // TODO нужна ли корректировка
{
    public override double MethodicId => 3.9;
    public override string MethodicName => "Отладка информационно-технического сопряжения СПО с внешними источниками информации";

    protected override double CalcLabor()
    {
        return K * T;
    }

    public override string CreateHtmlReport()
    {
        string html = $@"
<p>
    Трудоёмкость отладки на судне информационно-технического сопряжения СПО с внешними, по отношению к СПО, источниками информации определяется по формуле:</br>
    T<sub>ос</sub> = k ⋅ t <br>
    где<br>
    k = {K} чел. - количество сотрудников, принимающих участие в отладке сопряжения <br>
    t = {T} н/ч - длительность отладки <br>
</p>
";
        return html;
    }

    public Methodic03_9()
    {

    }


    #region DATA

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] int k; // количество сотрудников, принимающих участие в испытании
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] int t; // длительность отладки, н/ч

    #endregion DATA
}




/*

namespace LaborCalc.Models;

public partial class Methodic03_9 : Methodic // TODO нужна ли корректировка
{
    public override double MethodicId => 3.9;
    public override string MethodicName => "Отладка информационно-технического сопряжения СПО с внешними источниками информации";

    protected override double CalcLabor()
    {
        return _T_ос;
    }

    public override Report CreateReport()
    {
        string html = $@"
<h2>{Name}</h2>
<p>Расчёт этапа производиться в соответствии с пунктом {MethodicId} - {MethodicName}.</p>

<p>
    Трудоёмкость отладки на судне информационно-технического сопряжения СПО 
    с внешними, по отношению к СПО, источниками информации: <br>

    <table>
        <caption>Отладки</caption>
        <tr>
            <th>                     Источник инфорации   </th>
            <th style=""width:10%""> Количество людей     </th>
            <th style=""width:10%""> Длительность отладки </th>
            <th style=""width:10%""> Трудоёмкость         </th>
        </tr>
        {string.Join('\n', Отладки.Select(x => x.ToHTML()))}
    </table>
    <br>
    T<sub>ос</sub> = {Labor.Out()} <br>
</p>

<p><b>Итого:{Labor.Out()}ч</b></p>
" + "\n";
        return new Report(46, html);
    }

    public Methodic03_9()
    {

    }

    #region DATA

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] ObservableRangeCollection<Отладка> отладки = new ObservableRangeCollection<Отладка>();
    private double _T_ос => Отладки.Sum(o => o._T_ос); // (11) отладка инф-тех сопряж. СПО с внешними ист. инф-ии

    public struct Отладка
    {
        public string Name;
        public int K;       // количество сотрудников, принимающих участие в отладке сопряжения
        public double T;    // длительность отладки

        public double _T_ос => K * T;

        public Отладка(string name, int k, double t)
        {
            Name = name;
            K = k;
            T = t;
        }

        public string ToHTML()
        {
            return $@"
<tr>
    <td>
        {Name}
    </td>
    <td>
        {K}
    </td>
    <td>
        {T.Out()}
    </td>
    <td>
        {_T_ос.Out()}
    </td>
</tr>
";
        }

        public override string ToString()
        {
            return $"Отладка: {Name}. T_ос:{_T_ос} = k:{K} * t:{T}";
        }
    }

    #endregion
}
 
  
*/



/*

    #region 3.9. ОТЛАДКА ИНФ-ТЕХ СОПРЯЖЕНИЯ _T_ос

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] bool isT_ос = true;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] ObservableRangeCollection<Отладка> отладки = new ObservableRangeCollection<Отладка>();
    private double _T_ос => Отладки.Sum(o => o._T_ос); // (11) отладка инф-тех сопряж. СПО с внешними ист. инф-ии

    public struct Отладка
    {
        public string Name;
        public int K;       // количество сотрудников, принимающих участие в отладке сопряжения
        public double T;    // длительность отладки

        public double _T_ос => K * T;

        public Отладка(string name, int k, double t)
        {
            Name = name;
            K = k;
            T = t;
        }

        public string ToHTML()
        {
            return $@"
<tr>
    <td>
        {Name}
    </td>
    <td>
        {K}
    </td>
    <td>
        {T.Out()}
    </td>
    <td>
        {_T_ос.Out()}
    </td>
</tr>
";
        }

        public override string ToString()
        {
            return $"Отладка: {Name}. T_ос:{_T_ос} = k:{K} * t:{T}";
        }
    }

    #endregion 
 
*/



//{(IsT_ос ?
//$@"
//<p>
//    Трудоёмкость отладки на судне информационно-технического сопряжения СПО 
//    с внешними, по отношению к СПО, источниками информации: <br>

//    <table>
//        <caption>Отладки</caption>
//        <tr>
//            <th>                     Источник инфорации   </th>
//            <th style=""width:10%""> Количество людей     </th>
//            <th style=""width:10%""> Длительность отладки </th>
//            <th style=""width:10%""> Трудоёмкость         </th>
//        </tr>
//        {string.Join('\n', Отладки.Select(x => x.ToHTML()))}
//    </table>
//    <br>
//    T<sub>ос</sub> = {_T_ос.Out()} <br>
//</p>
//" : "")}