namespace LaborCalc.Views;

public partial class Methodic11Template : UserControl
{
    private Methodic11 Methodic { get; set; }

    public Methodic11Template()
    {
        InitializeComponent();
        Methodic = new Methodic11();
        DataContext = Methodic;
    }

    public Methodic11Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic11)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
