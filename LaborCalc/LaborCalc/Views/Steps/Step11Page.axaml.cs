namespace LaborCalc.Views;

public partial class Step11Page : UserControl
{
    private Step11 Step { get; set; }

    public Step11Page()
    {
        InitializeComponent();
        Step = new Step11();
        DataContext = Step;
    }

    public Step11Page(Step step)
    {
        InitializeComponent();
        Step = (Step11)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
