namespace LaborCalc.Views;

public partial class Methodic10Template : UserControl
{
    private Methodic10 Methodic { get; set; }

    public Methodic10Template()
    {
        InitializeComponent();
        Methodic = new Methodic10();
        DataContext = Methodic;
    }

    public Methodic10Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic10)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}