namespace LaborCalc.Views;

public partial class Methodic03_8Template : UserControl
{
    private Methodic03_8 Methodic { get; set; }

    public Methodic03_8Template()
    {
        InitializeComponent();
        Methodic = new Methodic03_8();
        DataContext = Methodic;
    }

    public Methodic03_8Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic03_8)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}