namespace LaborCalc.Views;

public partial class Methodic01Template : UserControl
{
    private Methodic01 Methodic { get; set; }

    public Methodic01Template()
    {
        InitializeComponent();
        Methodic = new Methodic01();
        DataContext = Methodic;
    }

    public Methodic01Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic01)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}