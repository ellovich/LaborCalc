namespace LaborCalc.Models;

public partial class Step09 : Step
{
    public override double MethodicId => 9;
    public override string MethodicName => "Математическое моделирование";

    public override double CalcLabor()
    {
        return (Aggregation) ?
            T_9_1.FullLabor * 1.3 : // + (0,3 трудоемкости разработки входящих в нее мат. моделей)
            T_9_1.FullLabor;
    }

    public override string CreateHtmlReport()
    {
        string html = $@"
<p>Нормы времени на математическое моделирование определяются по следующей таблице:</p>
{T_9_1.ToHtml()}

{(Aggregation ? 
$@"
    Вследствие комплексирования мат. моделей отдельных элементов
    в математическую модель агрегата (установки), к сумме трудоемкостей
    ({ T_9_1.FullLabor }ч) прибавляется 0,3 трудоемкости разработки
    входящих в нее мат. моделей (+ { T_9_1.FullLabor * 0.3 } н/ч).
" : "")}
";

        return html;
    }


    #region DATA

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))]
    Table t_9_1 = new(9.1, "Нормы времени на математическое моделирование моделирование",
        new Item("Разработка математических моделей единиц технических средств с числом входных и выходных аналоговых и дискретных сигналов до 50",   "1 модель", 180 ),
        new Item("Разработка математических моделей единиц технических средств с числом входных и выходных аналоговых и дискретных сигналов до 100",  "1 модель", 350 ),
        new Item("Разработка математических моделей единиц технических средств с числом входных и выходных аналоговых и дискретных сигналов до 250",  "1 модель", 800 ),
        new Item("Разработка математических моделей единиц технических средств с числом входных и выходных аналоговых и дискретных сигналов до 500",  "1 модель", 1700),
        new Item("Разработка математических моделей единиц технических средств с числом входных и выходных аналоговых и дискретных сигналов до 1000", "1 модель", 3000)
        );

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] bool aggregation;

    public static readonly List<Correction> s_Corrections9_2 = new()
    {
        new Correction("Малая",                            0.3 ),
        new Correction("Средняя",                          0.5 ),
        new Correction("Значительная",                     0.7 ),
        new Correction("Приминение нового метода решения", 0.8 ),
    };

    #endregion
}
