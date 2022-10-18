using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Newtonsoft.Json;
using System.IO;

namespace AvaloniaApplication1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}