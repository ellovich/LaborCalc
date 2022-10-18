namespace LaborCalc.Views;

public partial class Methodic18Template : UserControl
{
    private Methodic18 Methodic { get; set; }

    public Methodic18Template()
    {
        InitializeComponent();
        Methodic = new Methodic18();
        DataContext = Methodic;
    }

    public Methodic18Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic18)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
