namespace LaborCalc.Views;

public partial class Step16Page : UserControl
{
    private Step16 Step { get; set; }

    public Step16Page()
    {
        InitializeComponent();
        Step = new Step16();
        DataContext = Step;
    }

    public Step16Page(Step step)
    {
        InitializeComponent();
        Step = (Step16)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
