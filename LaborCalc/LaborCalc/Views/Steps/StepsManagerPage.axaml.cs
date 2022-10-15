using LaborCalc.Models;

namespace LaborCalc.Views;

public partial class StepsManagerPage : UserControl
{
    private StepsManager StepsManager { get; set; }

    public StepsManagerPage()
    {
        InitializeComponent();
        StepsManager = new StepsManager();
        DataContext = StepsManager;
    }

    public StepsManagerPage(StepsManager stepsManager)
    {
        InitializeComponent();
        StepsManager = (StepsManager)stepsManager;
        DataContext = StepsManager;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
