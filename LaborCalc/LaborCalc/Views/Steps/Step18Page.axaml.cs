namespace LaborCalc.Views;

public partial class Step18Page : UserControl
{
    private Step18 Step { get; set; }

    public Step18Page()
    {
        InitializeComponent();
        Step = new Step18();
        DataContext = Step;
    }

    public Step18Page(Step step)
    {
        InitializeComponent();
        Step = (Step18)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
