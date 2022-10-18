namespace LaborCalc.Models;

public class Project : IEntity
{
    string s_standartLocation =>
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\LaborCalc";

    public Guid Id => Guid.NewGuid();
    public string Name { get; set; }     // название проекта
    public string Location { get; set; } // папка с проектом
    public StepsManager StepsManager { get; set; }
    public ReportsManager ReportsManager { get; set; }      // НЕ СОХРАНЯЕТСЯ ИЗ-ЗА ССЫЛКИ НА СЕБЯ


    [JsonConstructor]
    public Project(int a = 0) { }

    public Project()
    {
        Name = $"Проект_{Id}";
        Location = $"{s_standartLocation}\\{Name}";
        StepsManager = StepsManager.CreateTemplate();
        ReportsManager = new ReportsManager(this);
    }


    public async void SaveToJson()
    {
        string json = JsonConvert.SerializeObject(
            this,
            new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            }
        );

        Directory.CreateDirectory(Location);
        await File.WriteAllTextAsync($"{Location}\\{Name}.labor", json);
    }

    public static Project LoadFromJson(string path)
    {
        try
        {
            string json = File.ReadAllText(path);
            var p = JsonConvert.DeserializeObject<Project>(json);

            if (p != null)
            {
                p.Location = Path.GetDirectoryName(path);
                p.Name = Path.GetFileNameWithoutExtension(path);
            }
            else
            {
                throw new Exception($"Ошибка чтения файла {path}");
            }

            return p;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка чтения файла {path}");
        }
    }
}