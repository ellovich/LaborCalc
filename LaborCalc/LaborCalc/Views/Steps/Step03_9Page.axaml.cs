namespace LaborCalc.Views;

public partial class Step03_9Page : UserControl
{
    private Step03_9 Step { get; set; }

    public Step03_9Page()
    {
        InitializeComponent();
        Step = new Step03_9();
        DataContext = Step;
    }

    public Step03_9Page(Step step)
    {
        InitializeComponent();
        Step = (Step03_9)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}