using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LaborCalc.Views;

public partial class MyTable : UserControl
{
    public MyTable()
    {
        InitializeComponent();
    }

    public MyTable(string name, Table table)
    {
        InitializeComponent();


    }



    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
