namespace LaborCalc.Models;

public partial class Methodic13 : Methodic
{
    public override double MethodicId => 13;
    public override string MethodicName => "Проведение пуско-наладочных работ";

    public override double CalcLabor()
    {
        return 0;
        //return т_13_1.ОбщаяТрудоемкость;
    }

    public override string CreateHtmlReport()
    {
        string html = "Трудоемкость пуско-наладочных работ определяется как сумма трудоемкостей технологических этапов их проведения.\n";
//         algo += т_13_1.ВывестиВыбранные();
        return html;
    }

    //#region ДАННЫЕ
    //public TableModel т_13_1= new Model("Нормы времени на проведение пуско - наладочных работ",
    //    new St("Корректировка информационных массивов(ИМ) СПО по результатам кренования корабля/судна и тарировки(проливки) цистерн",         MethodicsManager.GetMethodic(3).Labor),
    //    new St("Проведение автономной отладки специального программного обеспечения" ,                                                        MethodicsManager.GetMethodic(1).Labor), /// НЕВЕРНО
    //    new St("Внедрение программного обеспечения" ,                                                                                         MethodicsManager.GetMethodic(1).Labor), /// НЕВЕРНО
    //    new St("Отладка на судне информационно - технического сопряжения СПО с внешними по отношению к СПО источниками информации, " +
    //        "такими как метеостанция, комплексная система управления техническими средствами, пожарная сигнализация, навигационный комплекс", MethodicsManager.GetMethodic(1).Labor), /// НЕВЕРНО
    //    new St("Разработка программы и методики испытаний СПО на судне в период проведения швартовных испытаний судна",                       MethodicsManager.GetMethodic(2).Labor),
    //    new St("Участие в швартовных испытаниях на судне",                                                                                    MethodicsManager.GetMethodic(12).Labor),
    //    new St("Сборка аппаратных средств автоматизированного рабочего места",                                                                MethodicsManager.GetMethodic(14).Labor),
    //    new St("Сборка конструктива для аппаратных средств автоматизированного рабочего места",                                               MethodicsManager.GetMethodic(14).Labor)
    //    );
    //#endregion
}
