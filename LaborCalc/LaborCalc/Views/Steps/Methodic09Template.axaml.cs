namespace LaborCalc.Views;

public partial class Methodic09Template : UserControl
{
    private Methodic09 Methodic { get; set; }

    public Methodic09Template()
    {
        InitializeComponent();
        Methodic = new Methodic09();
        DataContext = Methodic;
    }

    public Methodic09Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic09)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
