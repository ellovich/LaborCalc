namespace LaborCalc.Views;

public partial class Step01Page : UserControl
{
    private Step01 Step { get; set; }

    public Step01Page()
    {
        InitializeComponent();
        Step = new Step01();
        DataContext = Step;
    }

    public Step01Page(Step step)
    {
        InitializeComponent();
        Step = (Step01)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}