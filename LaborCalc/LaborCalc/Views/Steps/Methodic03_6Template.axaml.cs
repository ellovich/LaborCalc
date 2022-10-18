namespace LaborCalc.Views;

public partial class Methodic03_6Template : UserControl
{
    private Methodic03_6 Methodic { get; set; }

    public Methodic03_6Template()
    {
        InitializeComponent();
        Methodic = new Methodic03_6();
        DataContext = Methodic;
    }

    public Methodic03_6Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic03_6)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}