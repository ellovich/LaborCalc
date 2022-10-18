namespace LaborCalc.Views;

public partial class Methodic08Template : UserControl
{
    private Methodic08 Methodic { get; set; }

    public Methodic08Template()
    {
        InitializeComponent();
        Methodic = new Methodic08();
        DataContext = Methodic;
    }

    public Methodic08Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic08)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}