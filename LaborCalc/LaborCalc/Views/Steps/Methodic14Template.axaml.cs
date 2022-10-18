namespace LaborCalc.Views;

public partial class Methodic14Template : UserControl
{
    private Methodic14 Methodic { get; set; }

    public Methodic14Template()
    {
        InitializeComponent();
        Methodic = new Methodic14();
        DataContext = Methodic;
    }

    public Methodic14Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic14)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
