using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;

namespace LaborCalc.Views;

public partial class Methodic03_7Template : UserControl
{
    private Methodic03_7 Methodic { get; set; }

    public Methodic03_7Template()
    {
        InitializeComponent();
        Methodic = new Methodic03_7();
        DataContext = Methodic;
    }

    public Methodic03_7Template(Methodic methodic)
    {
        InitializeComponent();
        Methodic = (Methodic03_7)methodic;
        DataContext = Methodic;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }



    private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
    {
        CheckBox cb = (CheckBox)sender;
        Border b = (Border)cb.Parent.Parent;
        Grid g = (Grid)b.GetVisualChildren().First();

        b.Background = new SolidColorBrush(Color.FromRgb(48, 48, 48));

        foreach (Control c in g.GetVisualChildren())
            c.IsEnabled = true;

        cb.IsEnabled = true;
    }

    private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
    {
        CheckBox cb = (CheckBox)sender;
        Border b = (Border)cb.Parent.Parent;
        Grid g = (Grid)b.GetVisualChildren().First();

        b.Background = new SolidColorBrush(Color.FromRgb(89, 89, 89));

        foreach (Control c in g.GetVisualChildren())
        {
            if (!(c is TextBox))
                c.IsEnabled = false;
        }

        cb.IsEnabled = true;
    }
}