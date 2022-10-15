namespace LaborCalc.Models;

public partial class Step01 : Step
{
    public override double MethodicId => 1;
    public override string MethodicName => "Разработка (доработка) СПО СИП БЖ";
    
    public override double CalcLabor()
    {
        return 0;
    }

    public override Report CreateReport()
    {
        string html = "";

        return new Report(this, html);
    }


    #region DATA

    public List<string> СтадииРазработки = new List<string>()
    {
        "Техническое задание",
        "Эскизный проект",
        "Технический проект",
        "Рабочий проект",
        "Внедрение"
    };

    //Вход
    //ПИ
    //НСИ
    //БД
    //Выход:

    //Степень новизны разрабатываемых комплексов задач
    //Группа сложности алгоритма
    //Вид обработки информации 

    #endregion DATA
}

