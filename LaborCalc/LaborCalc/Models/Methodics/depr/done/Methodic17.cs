namespace LaborCalc.Models;

public partial class Methodic17 : Methodic
{
    public override double MethodicId => 17;
    public override string MethodicName => "Каталогизация";

    public override double CalcLabor()
    {
        return T_17_1.FullLabor;
    }

    public override string CreateHtmlReport()
    {
        string html = $@"
<p>Трудоёмкость проведения работ по каталогизации рассчивается согласно следующей таблице:</p>
{T_17_1.ToHtml()}
";

        return html;
    }

    public Methodic17()
    {
        t_17_1 = new(17.1, "Нормы времени на проведение работ по каталогизации",
            new Item("Регистрация в системе каталогизации предметов снабжения Вооруженных Сил Российской Федерации", "Количество часов", 1), // ФЗ
            new Item("Составление запроса в центр каталогизации предметов снабжения ВС РФ по закрепленным группам однородной продукции", "Лист А4", 7),

            new Item("Анализ содержания разделов федерального каталога продукции для федеральных государственных нужд (ФКП) с целью определения возможности " +
                     "использования существующих предметов снабжения в составе разрабатываемого изделия", "1 разрабатываемое изделие", 1), // ФЗ

            new Item("Разработка плана мероприятий по каталогизации предметов снабжения, подлежащих включению в ФКП", "1 документ", 1), // ФЗ
            new Item("Разработка проекта номенклатурного перечня предметов снабжения, подлежащих включению в ФКП", "1 документ", 1) // ФЗ
        );
    }

    [JsonConstructor]
    public Methodic17(int a = 0) { }


    #region DATA

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] Table t_17_1;

    #endregion
}
