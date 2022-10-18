namespace LaborCalc.Views;

public partial class Methodic05Template : UserControl
{
    private Methodic05 Methodic { get; set; }

    public Methodic05Template()
    {
        InitializeComponent();
        Methodic = new Methodic05();
        DataContext = Methodic;
    }

    public Methodic05Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic05)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}