namespace LaborCalc.Models;

public partial class StepsManager : ViewModelBase
{
    [ObservableProperty, NotifyPropertyChangedFor(nameof(FullLabor))] TrulyObservableCollection<Step> doneSteps;

    public StepsManager()
    {
        DoneSteps = new()
            {
            new Step("Разработка СПО СИП БЖ", new List<Methodic>() {
                new Methodic01() { Name = "Постановка задач на стадии \"Рабочий проект\"" }
            }),

            //new Step("Формирование ИМ данных СПО СИП БЖ", new List<Methodic>() {
            //    new Methodic03_2() { Name = "Формирование ИМ данных СПО СИП БЖ" },
            //}),
            //new Step("Разработка СПО СИП БЖ", new List<Methodic>() {
            //    new Methodic01() { Name = "Постановка задач на стадии \"Рабочий проект\"" },
            //    new Methodic01() { Name = "Разработка ПО стадии на \"Рабочий проект\"" },
            //    new Methodic04_6() { Name = "Разработка 3D-модели" },
            //    new Methodic16() { Name = "Создание компакт-диска с ПО"}
            //}),
            //new Step("Разработка программной и эксплуатационной документации", new List<Methodic>() {
            //    new Methodic02() { Name = "Разработка документации" },
            //    new Methodic16() { Name = "Создание компакт-диска с документацией"}
            //}),
            //new Step("Разработка протоколов сопряжения", new List<Methodic>() {
            //    new Methodic03_6() { Name = "Разработка протоколов сопряжения" },
            //}),
            //new Step("Корректировка ИМ по результатам кренования и проливки цистерн", new List<Methodic>() {
            //    new Methodic03_7() {  },
            //    new Methodic16() { Name = "Создание компакт-диска с откорректированным ПО"}
            //}),
            //new Step("Приёмо-сдаточные испытания СПО СИП БЖ на судне", new List<Methodic>() {
            //    new Methodic12() {  }
            //}),
            //new Step("Руководство проектом", new List<Methodic>() {
            //    new Methodic07() {  },
            //})
        };
    }

    [JsonConstructor]
    public StepsManager(int a = 0) { }

    public double FullLabor => Math.Round(DoneSteps.Sum(st => st.Labor), 2);


    [RelayCommand]
    public void AddNewStep()
    {
        DoneSteps.Add(new Step("Руководство проектом", new List<Methodic>() { new Methodic07() }));
    }

    public static List<(double, string)> s_MethodicsTemplates { get; } = new List<(double, string)>()
    {
        (3.2, "Формирование ИМ СПО СИП БЖ"),
        (1, "Разработка СПО СИП БЖ"),
        (4.6, "Создание (доработка) 3D моделей корабля/судна"),
        (6, "Формирование электронной тех. библиотеки интерактивных документов"),
        (3.6, "Разработка протокола сопряжения с внешними системами"),
        (2, "Разработка документации"),
        (14, "Закупка аппаратных и программных средств"),
        (3.7, "Корректировки ИМ СПО по результатам кренования и тарирорки цистерн"),
        (11, "Обучение командного состава судна порядку исп. СПО"),
        (7, "Руководство проектом"),
        (13, "Испытание и сдача СИП БЖ заказчику"),
        (3.8, "Проведение сравнительных расчётов посадки и остойчивости"),
        (3.9, "Отладка инф.-тех. сопряжения СПО с внешними источниками инф-ии"),

        // не нужны
        (9, "Математическое моделирование"),
        (12, "Проведение испытаний"),
        (16, "Оформление отчётных материалов"),
        (17, "Каталогизация"),
        (18, "Изготовление оптических изделий"),
    };
}
