using System.Runtime.Serialization;

namespace LaborCalc.Models;

public class Project
{
    public int Id => GetHashCode();
    public string Name { get; set; }
    public string Location { get; set; }

    public StepsManager StepsManager { get; set; }

    [DataMember]
    public ReportsManager ReportsManager { get; set; }

    [JsonConstructor]
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

        StepsManager = StepsManager.CreateTemplate();
        ReportsManager = new ReportsManager(this);
    }


    public async void SaveToJson()
    {
        string json = JsonConvert.SerializeObject(this);

        if (Location is null)
        {
            string standartLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\LaborCalc";
            Directory.CreateDirectory(standartLocation);
            await File.WriteAllTextAsync($"{standartLocation}\\{Name}.labor", json);
            Debug.WriteLine($"Saved to: {standartLocation}");
        }
        else 
        {
            await File.WriteAllTextAsync($"{Location}", json);
            Debug.WriteLine($"Saved to: {Location}");
        }
    }

    public static Project LoadFromJson(string path)
    {
        try
        {
            string json = File.ReadAllText(path);
            var p = JsonConvert.DeserializeObject<Project>(json);

            return p;
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex, "ERROR");
            return new Project();
        }
    }
}