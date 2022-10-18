namespace LaborCalc.Views;

public partial class Methodic16Template : UserControl
{
    private Methodic16 Methodic { get; set; }

    public Methodic16Template()
    {
        InitializeComponent();
        Methodic = new Methodic16();
        DataContext = Methodic;
    }

    public Methodic16Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic16)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
