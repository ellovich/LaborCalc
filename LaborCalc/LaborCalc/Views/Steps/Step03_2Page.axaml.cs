using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;

namespace LaborCalc.Views;

public partial class Step03_2Page : UserControl
{
    private Step03_2 Step { get; set; }

    public Step03_2Page()
    {
        InitializeComponent();
        Step = new Step03_2();
        DataContext = Step;
    }

    public Step03_2Page(Step step)
    {
        InitializeComponent();
        Step = (Step03_2)step;
        DataContext = Step;
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