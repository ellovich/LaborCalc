namespace LaborCalc.Models;

public partial class Step : ViewModelBase, IEntity
{
    [ObservableProperty] string name;
    public ObservableCollection<Methodic> Methodics { get; set; }


    public Step()
    {
        Methodics = new();
    }

    [JsonConstructor]
    public Step(int a = 0)
    {
    }


    public double Labor => Math.Round(Methodics.Sum(m => m.Labor), 2);

    public string CreateHtmlReport() 
    {
        return String.Empty;
    }
}
