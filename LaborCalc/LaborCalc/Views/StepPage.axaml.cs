namespace LaborCalc.Views;

public partial class StepPage : UserControl
{
    private Methodic Methodic { get; set; }

    public StepPage()
    {
        InitializeComponent();
    //    Methodic = new Methodic();
        DataContext = Methodic;
    }

    public StepPage(Methodic methodic)
    {
        InitializeComponent();
    //    Methodic = (Methodic01)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}