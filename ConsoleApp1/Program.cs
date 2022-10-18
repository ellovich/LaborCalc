using Newtonsoft.Json;

namespace ConsoleApp1;

public class Project
{
    public static string s_Path
        => Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\project.json";

    public Table T { get; set; }

    static int i = 0; // счетчик вызова конструктора
    public Project()
    {
        Console.WriteLine($"###############################>{++i} вызов Product");

        T = new Table("Нормы времени на оформление отчетных материалов",
            new List<Item>()
            {
                new Item("Создание презентации", 7.0),
                new Item("Создание демонстрационного видеоролика", 4.5),
                new Item("Создание электронного носителя", 4.4),
                new Item("Маркировка электронного носителя", 2.2)
            });
    }


    public void Save()
    {
        JsonSerializerSettings settings = new()
        {
            ObjectCreationHandling = ObjectCreationHandling.Replace, // не влияет
            Formatting = Formatting.Indented,
        };

        string output = JsonConvert.SerializeObject(this, settings);
        using (StreamWriter sw = new(s_Path))
            sw.WriteLine(output);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nSaved to: {s_Path}\n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static Project Load()
    {
        string json = File.ReadAllText(s_Path);
        var desPm = JsonConvert.DeserializeObject<Project>(json);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nLoaded from: {s_Path}\n");
        Console.ForegroundColor = ConsoleColor.White;

        return desPm;
    }

    public override string ToString()
    {
        return $"{T}";
    }
}

class Program
{
    public static void Main()
    {
        File.Delete(Project.s_Path);

        Project p = new();
        Console.WriteLine("После создания:\n" + p + "\n");

        p.T.TableItems[0].Val = 99999999;

        // сохраняю созданный объект
        p.Save();

        // загружаю сохраненный объект, !!! создаются дубликаты !!!
        var p2 = Project.Load();
        Console.WriteLine("После загрузки:\n" + p2 + "\n");

        // сохраняю, чтобы проверить, что в json-е дубликаты
        p2.Save();
    }
}