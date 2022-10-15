namespace LaborCalc.Views;

public partial class Step17Page : UserControl
{
    private Step17 Step { get; set; }

    public Step17Page()
    {
        InitializeComponent();
        Step = new Step17();
        DataContext = Step;
    }

    public Step17Page(Step step)
    {
        InitializeComponent();
        Step = (Step17)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
