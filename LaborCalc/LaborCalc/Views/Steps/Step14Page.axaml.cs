namespace LaborCalc.Views;

public partial class Step14Page : UserControl
{
    private Step14 Step { get; set; }

    public Step14Page()
    {
        InitializeComponent();
        Step = new Step14();
        DataContext = Step;
    }

    public Step14Page(Step step)
    {
        InitializeComponent();
        Step = (Step14)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
