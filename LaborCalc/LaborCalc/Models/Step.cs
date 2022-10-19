namespace LaborCalc.Models;

public partial class Step : ViewModelBase, IEntity
{
    [ObservableProperty] string name;
    public ObservableCollection<Methodic> Methodics { get; set; }

    public Step()
    {
        Name = $"Этап №{Methodics.Count}";
        Methodics = new();
    }

    public Step(string name)
    {
        Name = name;
        Methodics = new();
    }

    public Step(string name, List<Methodic> methodics)
    {
        Name = name;
        Methodics = new(methodics);
    }

    public Step(string name, Methodic methodic)
    {
        Name = name;
        Methodics = new() { methodic };
    }

    [JsonConstructor]
    public Step(int a = 0) { }


    public double Labor => Math.Round(Methodics.Sum(m => m.Labor), 2);

    //[RelayCommand] void AddMethodic()
    //{
    //    Methodics.Add(new Methodic04_6() { Name = "Разработка 3D-модели" });
    //}

    public string CreateHtmlReport() 
    {
        return String.Empty;
    }
}
