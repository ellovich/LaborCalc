using LaborCalc.Models;

namespace LaborCalc.Views;

public partial class MethodicsManagerPage : UserControl
{
    private StepsManager MethodicsManager { get; set; }

    public MethodicsManagerPage()
    {
        InitializeComponent();
        MethodicsManager = new StepsManager();
        DataContext = MethodicsManager;
    }

    public MethodicsManagerPage(StepsManager methodicsManager)
    {
        InitializeComponent();
        MethodicsManager = (StepsManager)methodicsManager;
        DataContext = MethodicsManager;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
