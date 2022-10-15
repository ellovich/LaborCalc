namespace LaborCalc.Views;

public partial class Step05Page : UserControl
{
    private Step05 Step { get; set; }

    public Step05Page()
    {
        InitializeComponent();
        Step = new Step05();
        DataContext = Step;
    }

    public Step05Page(Step step)
    {
        InitializeComponent();
        Step = (Step05)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}