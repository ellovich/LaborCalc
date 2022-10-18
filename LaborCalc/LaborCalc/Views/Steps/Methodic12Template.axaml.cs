using Avalonia.Interactivity;

namespace LaborCalc.Views;

public partial class Methodic12Template : UserControl
{
    private Methodic12 Methodic { get; set; }

    public Methodic12Template()
    {
        InitializeComponent();
        Methodic = new Methodic12();
        DataContext = Methodic;
    }

    public Methodic12Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic12)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}