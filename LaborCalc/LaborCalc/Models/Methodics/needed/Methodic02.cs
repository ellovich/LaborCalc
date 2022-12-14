using MvvmHelpers.Commands;

namespace LaborCalc.Models;

public partial class Methodic02 : Methodic
{
    public override double MethodicId => 2;
    public override string MethodicName => "Разработка документации";

    protected override double CalcLabor()
    {
        return addedReadyDocs.FullLabor + addedSuperDocs.Sum(s => s.FullLabor);
    }

    public override string CreateHtmlReport()
    {
        string html = $@"
<p>Трудоёмкость работы является суммой трудоёмкостей изготовления и выпуска перечисленных документов:</p>
{string.Join("\n", AddedSuperDocs.Select(t => t.ToHtml()))}
";

        return html;
    }

    public Methodic02()
    {
        foreach (var item in ReadyDocsTables.SelectMany(t => t.TableItems))
        {
            item.Correction = MethodicCorrection;

            ReadyDocsActions.Add(new MenuItemViewModel
            {
                Header = item.Name,
                Command = new Command(() => AddedReadyDocs.AddItem(item))
            });
        }
    }

    public Table AddNewSuperDoc()
    {
        var newSuperDock = new Table($"Документ {AddedSuperDocs.Count + 1}");
        AddedSuperDocs.Add(newSuperDock);

        return newSuperDock;
    }

    public void RemoveSuperDoc(Table superDoc)
    {
        Debug.WriteLine(ReadyDocsActions.Count);

        AddedSuperDocs.Remove(superDoc);
    }


    #region DATA

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] Table addedReadyDocs = new("Документы", new Item("a","b",2));
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] TrulyObservableCollection<Table> addedSuperDocs = new();


    #region STATIC TABLES

    private static readonly Table s_T_2_1 = new(2.1, "Нормы времени на разработку чертежей",
        new Item("Габаритный чертеж", "Лист А4", 9.9),
        new Item("Монтажный чертеж", "Лист А4", 6),
        new Item("Сборочный чертеж", "Лист А4", 42.11),
        new Item("Схема деления", "Лист А4", 21),
        new Item("Схема электрическая", "Лист А4", 8),
        new Item("Теоретический чертеж", "Лист А4", 11.3),
        new Item("Чертеж детали", "Лист А4", 3.42)
    );

    private static readonly Table s_T_2_2 = new(2.2, "Нормы на разработку текстовых документов по погрузке и упаковке изделия",
        new Item("Текстовые документы на упаковочную и погрузочную документацию", "Лист А4", 2.0)
    );

    private static readonly Table s_T_2_3 = new(2.3, "Нормы времени на разработку текстовых конструкторских документов",
        new Item("Акт приёма-передачи", "Лист А4", 4.4),
        new Item("Бланки формуляров (паспортов, этикеток)", "Лист А4", 2),
        new Item("Ведомость держателей подлинника", "Позиция", 3),
        new Item("Ведомость одиночного ЗИП", "Лист А4", 3),
        new Item("Ведомость покупных изделий", "Лист А4", 5),
        new Item("Ведомость разрешения применения изделий", "Лист А4", 4),
        new Item("Ведомость спецификаций", "Лист А4", 3),
        new Item("Ведомость ссылочных документов", "Лист А4", 3),
        new Item("Ведомость эксплуатационных документов", "Лист А4", 4.4),
        new Item("Документы ремонтные", "Лист А4", 5),
        new Item("Документы эксплуатационные и программные", "Лист А4", 4.4),
        new Item("Оценка запасов в комплектах ЗИП", "Лист А4", 4.4),
        new Item("Перечень (комплектность) документации изделия", "Лист А4", 3),
        new Item("Программа и методика испытаний", "Лист А4", 6),
        new Item("Проектная оценка надежности", "Лист А4", 5),
        new Item("Расчёт и обоснование уровня унификации", "Лист А4", 4.33),
        new Item("Расчет надежности изделия", "Лист А4", 5.0),
        new Item("Спецификация", "Лист А4", 3.75),
        new Item("Технические условия", "Лист А4", 5),
        new Item("Технический акт", "Лист А4", 4.4),
        new Item("Информационно-удостоверяющий лист", "Лист А4", 4.4)
    );

    private static readonly Table s_T_2_4 = new(2.4, "Нормы на работы, сопутствующие разработке конструкторской и программной документации",
        new Item("Внесение изменений в один экземпляр документа", "Одно изменение", 0.06),
        new Item("Внесение изменений в один экземпляр чертежа", "Одно изменение", 0.26),
        new Item("Внесение литеры в КД и ПД", "Лист А4", 0.083),
        new Item("Заполнение бланков формуляров (паспортов, этикеток)", "Один документ", 8),
        new Item("Кодирование и перекодирование чертежей и текстовых документов", "Одна позиция", 0.14),
        new Item("Конструкторский контроль", "Лист А4", 0.45),
        new Item("Метрологический контроль текстового документа", "Лист А4", 0.20),
        new Item("Метрологический контроль чертежа", "Лист А4", 0.40),
        new Item("Нормоконтроль спецификации", "Лист А4", 0.14),
        new Item("Нормоконтроль текстового документа", "Лист А4", 0.20),
        new Item("Нормоконтроль чертежа", "Лист А4", 0.45),
        new Item("Технологический контроль", "Лист А4", 0.18)
    );

    private static readonly Table s_T_2_5 = new(2.5, "Нормы на составление служебной и организационно-распорядительной документации",
        new Item("Заполнение и оформление титульных листов, содержания, описи документов, листов примечаний", "Один документ", 0.9),
        new Item("Составление служебных писем, требующих побора технической документации, их изучения и согласования с другими подразделениями", "Лист А4", 7),
        new Item("Протокол по результатам технического совещания", "Лист А4", 3.0),
        new Item("Разработка графика выпуска документации по заказу", "Лист А4", 1.5),
        new Item("Служебная записка технического характера без иллюстраций", "Лист А4", 2.25),
        new Item("Согласование документации с представителем заказчика, сторонними организациями и предприятиями", "Лист А4", 1), // ФЗ
        new Item("Сопроводительное письмо (технического характера)", "Лист А4", 1.8),
        new Item("Справка производственного характера", "Лист А4", 2.0),
        new Item("Составление технических, экономических отчетов и заключений по отчетам, отзывов по проектам инструкций и нормативно-технической документации; разработка информационного письма", "Лист А4", 5.25),
        new Item("Согласование текста методик, графиков, планов, этапов, сроков исполнения работ с другими подразделениями, корректировка после согласования", "Лист А4", 0.22),
        new Item("Рассмотрение и анализ проектно-конструкторской, информационной, экономической и технической документации в том числе разработанной сторонними организациями", "Лист А4", 0.5)
    );

    private static readonly Table s_T_2_6 = new(2.6, "Нормы на составление пояснительной записки и ведомости технического предложения, технического и эскизного проектов",
        new Item("Техническое предложение (Пояснительная записка)", "Лист А4", 6.0),
        new Item("Эскизный проект (Пояснительная записка)", "Лист А4", 5.4),
        new Item("Технический проект (Пояснительная записка)", "Лист А4", 5.1),
        new Item("Техническое предложение (Ведомость технического предложения)", "Лист А4", 1.3),
        new Item("Эскизный проект (Ведомость эскизного проекта)", "Лист А4", 1.5),
        new Item("Технический проект (Ведомость технического проекта)", "Лист А4", 1.5),
        new Item("Технический проект (Описание постановки задач)", "Лист А4", 5.1)
    );

    private static readonly Table s_T_2_7 = new(2.7, "Затраты времени на разработку элементов программной документации",
        new Item("Обработка фотографии для подготовки к публикации (изменение размеров, цветокоррекция)", "Фотография A4", 0.1),
        new Item("Обработка скриншота для подготовки к публикации", "Рисунок A4", 0.2),
        new Item("Сканирование изображения", "Лист А2", 0.033),
        new Item("Обработка сканированного изображения", "Лист А4", 0.3),
        new Item("Составление программной документации", "Лист А4", 3),
        new Item("Набор текстового материала со смешанными цифрами", "Лист А4", 0.25),
        new Item("Набор сплошного цифрового материала / сплошного текста", "Лист А4", 0.2),
        new Item("Редактировании и оформление документации", "Лист А4", 0.3),
        new Item("Разработка таблиц для публикации", "Таблица", 0.5),
        new Item("Разработка рисунков", "Рисунок А4", 4),
        new Item("Разработка схем", "Схема А4", 4),
        new Item("Разработка графических алгоритмов", "Лист А4", 4),
        new Item("Разработка текстовых алгоритмов", "Лист А4", 2.5)
    );

    private static readonly Table s_T_2_8 = new(2.8, "Затраты времени на разработку элементов программной документации",
        new Item("Научно-технический отчет", "Лист А4", 15),
        new Item("Отчет о патентных исследованиях", "Лист А4", 10),
        new Item("Форма результата интеллектуальной деятельности", "Лист А4", 0.3)
    );

    #endregion STATIC TABLES

    public static List<Table> ReadyDocsTables { get; } = new() { s_T_2_1, s_T_2_2, s_T_2_3, s_T_2_6, s_T_2_8 };
    public static List<Table> SingleDocsTables { get; } = new() { s_T_2_4, s_T_2_5, s_T_2_7 };


    [JsonIgnore] public List<MenuItemViewModel> ReadyDocsActions { get; set; } = new();

    #region CORRECTION

    public static readonly List<Correction> s_Corrections2_9 = new()
    {
        new Correction("Значительная",   0.8 ),
        new Correction("Малая",          0.5 ),
        new Correction("Средняя",        0.3 ),
        new Correction("Незначительная", 0.1 ),
    };

    private Correction _methodicCorrection = s_Corrections2_9[0]; // общий коэффициент новизны работы
    public Correction MethodicCorrection // Reactive
    {
        get => _methodicCorrection;
        set
        {
            foreach (var doc in AddedReadyDocs?.TableItems)
                doc.Correction = value;

            this.SetProperty(ref _methodicCorrection, value);
        }
    }

    #endregion CORRECTION

    #endregion DATA
}

public class MenuItemViewModel
{
    public string Header { get; set; }
    public Command Command { get; set; }

    //public object CommandParameter { get; set; }
    //public IList<MenuItemViewModel> Items { get; set; }
}