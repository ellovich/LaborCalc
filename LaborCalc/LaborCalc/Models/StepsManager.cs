namespace LaborCalc.Models;

public partial class StepsManager : ViewModelBase
{
    [ObservableProperty, NotifyPropertyChangedFor(nameof(FullLabor))] TrulyObservableCollection<Step> doneSteps = new();

    public StepsManager()
    {
        //    DoneSteps.CollectionChanged += People_CollectionChanged;
    }

    public double FullLabor => Math.Round(DoneSteps.Sum(st => st.Labor), 2);

    //private void People_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    //{
    //    //Debug.WriteLine("-------------------");
    //    //Debug.WriteLine(FullLabor);

    //    //foreach (var item in DoneSteps)
    //    //{
    //    //    Debug.WriteLine(item);
    //    //}
    //}

    //[RelayCommand]
    //public void AddNewStep(int id, string name)
    //{
    //    var step = Step.Create(id, name);
    //    Instance.DoneSteps.Add(step);

    //    return step;
    //}


    public static StepsManager CreateTemplate()
    {
        return new StepsManager()
        {
            DoneSteps = new()
            {
                new Step03_2() { Name = "Формирование ИМ СПО СИП БЖ" },
                new Step01() { Name = "Разработка СПО СИП БЖ" },
                new Step04_6() { Name = "Разработка 3D-модели" },
                //new Step06() { Name = "Формирование электронной библиотеки" },
                //new Step03_6() { Name = "Разработка протокола сопряжения с внешними  системами" },
                new Step02(),
                //new Step14(),
                //new Step03_7() { Name = "Корректировка ИМ СПО по результатам кренования и тарировки" },
                //new Step11() { Name = "Обучение порядку использования СПО" },
                //new Step07(),
                //// new Step13(),
                //new Step03_8(),
                //new Step03_9() { Name = "Отладка инф.-тех. сопряжения СПО с внешними ист. инф-ии" },

                //////не нужны
                new Step16(),
                //new Step09(),
                //new Step12(),
                //new Step17(),
                //new Step18(),
            }
        };
    }

    public static List<(double, string)> s_StepsTemplates { get; } = new List<(double, string)>()
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
