namespace LaborCalc.Views;

public partial class Step03_8Page : UserControl
{
    private Step03_8 Step { get; set; }

    public Step03_8Page()
    {
        InitializeComponent();
        Step = new Step03_8();
        DataContext = Step;
    }

    public Step03_8Page(Step step)
    {
        InitializeComponent();
        Step = (Step03_8)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}