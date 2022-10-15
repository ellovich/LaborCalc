namespace LaborCalc.Views;

public partial class Step13Page : UserControl
{
    private Step13 Step { get; set; }

    public Step13Page()
    {
        InitializeComponent();
        Step = new Step13();
        DataContext = Step;
    }

    public Step13Page(Step step)
    {
        InitializeComponent();
        Step = (Step13)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}