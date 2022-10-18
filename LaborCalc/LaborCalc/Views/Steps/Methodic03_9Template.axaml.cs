namespace LaborCalc.Views;

public partial class Methodic03_9Template : UserControl
{
    private Methodic03_9 Methodic { get; set; }

    public Methodic03_9Template()
    {
        InitializeComponent();
        Methodic = new Methodic03_9();
        DataContext = Methodic;
    }

    public Methodic03_9Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic03_9)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}