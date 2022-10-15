namespace LaborCalc.Views;

public partial class Step09Page : UserControl
{
    private Step09 Step { get; set; }

    public Step09Page()
    {
        InitializeComponent();
        Step = new Step09();
        DataContext = Step;
    }

    public Step09Page(Step step)
    {
        InitializeComponent();
        Step = (Step09)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
