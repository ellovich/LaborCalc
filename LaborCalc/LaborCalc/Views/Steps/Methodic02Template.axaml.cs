using LaborCalc.Models;
using MvvmHelpers.Commands;

namespace LaborCalc.Views;

public partial class Methodic02Template : UserControl
{
    private Methodic02 _methodic { get; set; }

    public Methodic02Template()
    {
        InitializeComponent();
        _methodic = new Methodic02();
        DataContext = _methodic;

        InitSuperDocs();
    }

    public Methodic02Template(Methodic methodic)
    {
        InitializeComponent();
        _methodic = (Methodic02)methodic;
        DataContext = _methodic;

        InitSuperDocs();
    }

    private void InitSuperDocs()
    {
        var docsPanel = this.FindControl<StackPanel>("DocsPanel");

        foreach (var item in _methodic.AddedSuperDocs)
            docsPanel?.Children.Add(new Methodic02Table(_methodic, item));
    }

    private void AddSuperDoc_Click(object sender, RoutedEventArgs e)
    {
        var docsPanel = this.FindControl<StackPanel>("DocsPanel");

        var newSuperDock = _methodic.AddNewSuperDoc();
        docsPanel?.Children.Add(new Methodic02Table(_methodic, newSuperDock));
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}