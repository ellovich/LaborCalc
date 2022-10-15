namespace LaborCalc.Views;

public partial class Step10Page : UserControl
{
    private Step10 Step { get; set; }

    public Step10Page()
    {
        InitializeComponent();
        Step = new Step10();
        DataContext = Step;
    }

    public Step10Page(Step step)
    {
        InitializeComponent();
        Step = (Step10)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}