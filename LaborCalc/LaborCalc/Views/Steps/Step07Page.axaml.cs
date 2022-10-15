namespace LaborCalc.Views;

public partial class Step07Page : UserControl
{
    private Step07 Step { get; set; }

    public Step07Page()
    {
        InitializeComponent();
        Step = new Step07();
        DataContext = Step;
    }

    public Step07Page(Step step)
    {
        InitializeComponent();
        Step = (Step07)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
