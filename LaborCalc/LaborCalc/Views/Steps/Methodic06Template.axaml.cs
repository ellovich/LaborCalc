namespace LaborCalc.Views;

public partial class Methodic06Template : UserControl
{
    private Methodic06 Methodic { get; set; }

    public Methodic06Template()
    {
        InitializeComponent();
        Methodic = new Methodic06();
        DataContext = Methodic;
    }

    public Methodic06Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic06)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
