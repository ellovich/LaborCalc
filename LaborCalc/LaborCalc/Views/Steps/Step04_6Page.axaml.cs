using Avalonia.Interactivity;

namespace LaborCalc.Views;

public partial class Step04_6Page : UserControl
{
    private Step04_6 Step { get; set; }

    public Step04_6Page()
    {
        InitializeComponent();
        Step = new Step04_6();
        DataContext = Step;
    }

    public Step04_6Page(Step step)
    {
        InitializeComponent();
        Step = (Step04_6)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}