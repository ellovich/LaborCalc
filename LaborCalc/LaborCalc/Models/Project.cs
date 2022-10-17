namespace LaborCalc.Models;

public class Project
{
    public int Id => GetHashCode();
    public string Name { get; set; }
    public string Location { get; set; }

    public StepsManager StepsManager { get; set; }
    public ReportsManager ReportsManager { get; set; }


    public Project(string name, string location)
    {
        Name = name;
        Location = location;

        StepsManager = new StepsManager();
        ReportsManager = new ReportsManager(this);
    }

    public Project()
    {
        Name = $"LaborCalc_{Id}";
        Location = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\LaborCalc";

        StepsManager = StepsManager.CreateTemplate();
        ReportsManager = new ReportsManager(this);
    }


    public void SaveToJson()
    {
        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\LaborCalc");
        string json = JsonConvert.SerializeObject(this);
        File.WriteAllText($"{Location}\\{Name}.labor", json);

        Debug.WriteLine($"Saved to: {Location}\\{Name}.labor");
    }

    public static Project LoadFromJson(string path)
    {
        try
        {
            string json = File.ReadAllText(path);
            var deserializedObject = JsonConvert.DeserializeObject<Project>(json);

            if (deserializedObject is null) 
                throw new Exception("Failed to load project!");
            else
            {
                return new Project()
                {
                    Name = deserializedObject.Name,
                    Location = path,
                    StepsManager = deserializedObject.StepsManager,
                    ReportsManager = deserializedObject.ReportsManager,
                };
            }
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex, "ERROR");
            return new Project();
        }
    }
}