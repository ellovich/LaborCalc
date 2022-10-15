using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Newtonsoft.Json;
using System.IO;

namespace AvaloniaApplication1;

public partial class MainWindow : Window
{
    public Person me { get; set; } = new();

    public MainWindow()
    {
        me = Person.LoadAll();
        DataContext = this;
        InitializeComponent();
    }

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}


public struct Gender
{
    public string Name { get; }
    public double Coef { get; }

    [JsonConstructor]
    public Gender(string name, double coef)
    {
        Name = name;
        Coef = coef;
    }

    public override string ToString()
    {
        return $"{Name} (коэф. = {Coef})";
    }
}

[INotifyPropertyChanged]
public partial class Person
{
    [ObservableProperty]
    Gender gender;

    public static List<Gender> ListOfGenders = new()
    {
        new Gender("Полная разработка", 1),
        new Gender("Очень высокий", 0.85),
        new Gender("Высокий", 0.70),
        new Gender("Средний", 0.5),
        new Gender("Низкий", 0.3),
        new Gender("Очень низкий", 0.15),
        new Gender("Не требуется", 0)
    }; // k_нов Коэффициент новизны разработки
    [RelayCommand]
    public void SaveAll()
    {
        string json = JsonConvert.SerializeObject(this);
        Debug.WriteLine($"{json}");

        using StreamWriter sw = new($"person.json");
        sw.WriteLine(json);
    }

    public static Person? LoadAll()
    {
        Person? p;

        try
        {
            string json = File.ReadAllText($"person.json");
            p = JsonConvert.DeserializeObject<Person>(json);

            if (p is null) throw new Exception("No steps loaded!");
        }
        catch (Exception ex)
        {
            Console.Beep();
            Debug.WriteLine(ex);
            p = new Person()
            {
                Gender = ListOfGenders[0]
            };
        }

        return p;
    }
}