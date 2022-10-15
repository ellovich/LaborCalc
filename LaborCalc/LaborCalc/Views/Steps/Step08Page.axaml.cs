namespace LaborCalc.Views;

public partial class Step08Page : UserControl
{
    private Step08 Step { get; set; }

    public Step08Page()
    {
        InitializeComponent();
        Step = new Step08();
        DataContext = Step;
    }

    public Step08Page(Step step)
    {
        InitializeComponent();
        Step = (Step08)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}