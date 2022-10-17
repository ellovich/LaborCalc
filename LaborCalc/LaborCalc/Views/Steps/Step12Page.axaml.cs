using Avalonia.Interactivity;

namespace LaborCalc.Views;

public partial class Step12Page : UserControl
{
    private Step12 Step { get; set; }

    public Step12Page()
    {
        InitializeComponent();
        Step = new Step12();
        DataContext = Step;
    }

    public Step12Page(Step step)
    {
        InitializeComponent();
        Step = (Step12)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}