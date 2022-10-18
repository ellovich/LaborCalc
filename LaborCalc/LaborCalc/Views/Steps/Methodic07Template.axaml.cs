namespace LaborCalc.Views;

public partial class Methodic07Template : UserControl
{
    private Methodic07 Methodic { get; set; }

    public Methodic07Template()
    {
        InitializeComponent();
        Methodic = new Methodic07();
        DataContext = Methodic;
    }

    public Methodic07Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic07)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
