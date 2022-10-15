using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace LaborCalc.Views;

public partial class Step02Table : UserControl
{
    public Step02Table()
    {
        InitializeComponent();
        DataContext = new Step02TableViewModel();
    }

    public Step02Table(Step02Page step02Page, Step02 step02)
    {
        InitializeComponent();
        DataContext = new Step02TableViewModel(this, step02Page, step02);
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void AddSubstep(object sender, RoutedEventArgs e)
    {
        new Step02ItemsSelector().ShowDialog((Window)Parent.Parent.Parent.Parent.Parent.Parent);
    }
}
