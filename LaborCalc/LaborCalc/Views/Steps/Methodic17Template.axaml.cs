namespace LaborCalc.Views;

public partial class Methodic17Template : UserControl
{
    private Methodic17 Methodic { get; set; }

    public Methodic17Template()
    {
        InitializeComponent();
        Methodic = new Methodic17();
        DataContext = Methodic;
    }

    public Methodic17Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic17)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
