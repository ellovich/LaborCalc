using Avalonia.Interactivity;

namespace LaborCalc.Views;

public partial class Methodic04_6Template : UserControl
{
    private Methodic04_6 Methodic { get; set; }

    public Methodic04_6Template()
    {
        InitializeComponent();
        Methodic = new Methodic04_6();
        DataContext = Methodic;
    }

    public Methodic04_6Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic04_6)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}