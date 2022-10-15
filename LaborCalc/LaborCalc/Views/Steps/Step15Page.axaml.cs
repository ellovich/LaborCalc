namespace LaborCalc.Views;

public partial class Step15Page : UserControl
{
    private Step15 Step { get; set; }

    public Step15Page()
    {
        InitializeComponent();
        Step = new Step15();
        DataContext = Step;
    }

    public Step15Page(Step step)
    {
        InitializeComponent();
        Step = (Step15)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}