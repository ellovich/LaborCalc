namespace LaborCalc.Views;

public partial class Step03_6Page : UserControl
{
    private Step03_6 Step { get; set; }

    public Step03_6Page()
    {
        InitializeComponent();
        Step = new Step03_6();
        DataContext = Step;
    }

    public Step03_6Page(Step step)
    {
        InitializeComponent();
        Step = (Step03_6)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}