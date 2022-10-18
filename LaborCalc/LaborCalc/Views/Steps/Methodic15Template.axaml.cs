namespace LaborCalc.Views;

public partial class Methodic15Template : UserControl
{
    private Methodic15 Methodic { get; set; }

    public Methodic15Template()
    {
        InitializeComponent();
        Methodic = new Methodic15();
        DataContext = Methodic;
    }

    public Methodic15Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic15)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}