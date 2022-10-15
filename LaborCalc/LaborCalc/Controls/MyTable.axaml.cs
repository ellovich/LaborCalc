using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LaborCalc.Views;

public partial class MyTable : UserControl
{
    public MyTable()
    {
        InitializeComponent();
    }


    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
