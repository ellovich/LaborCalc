namespace LaborCalc.Views;

public partial class Methodic13Template : UserControl
{
    private Methodic13 Methodic { get; set; }

    public Methodic13Template()
    {
        InitializeComponent();
        Methodic = new Methodic13();
        DataContext = Methodic;
    }

    public Methodic13Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic13)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}