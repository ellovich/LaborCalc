namespace LaborCalc.Views;

public partial class Step06Page : UserControl
{
    private Step06 Step { get; set; }

    public Step06Page()
    {
        InitializeComponent();
        Step = new Step06();
        DataContext = Step;
    }

    public Step06Page(Step step)
    {
        InitializeComponent();
        Step = (Step06)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
