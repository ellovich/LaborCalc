using LaborCalc.Models;
using MvvmHelpers.Commands;

namespace LaborCalc.Views;

public partial class Step02Page : UserControl
{
    private Step02 _step { get; set; }

    public Step02Page()
    {
        InitializeComponent();
        _step = new Step02();
        DataContext = _step;

        InitSuperDocs();
    }

    public Step02Page(Step step)
    {
        InitializeComponent();
        _step = (Step02)step;
        DataContext = _step;

        InitSuperDocs();
    }

    private void InitSuperDocs()
    {
        var docsPanel = this.FindControl<StackPanel>("DocsPanel");

        foreach (var item in _step.AddedSuperDocs)
            docsPanel?.Children.Add(new Step02Table(_step, item));
    }

    private void AddSuperDoc_Click(object sender, RoutedEventArgs e)
    {
        var docsPanel = this.FindControl<StackPanel>("DocsPanel");

        var newSuperDock = _step.AddNewSuperDoc();
        docsPanel?.Children.Add(new Step02Table(_step, newSuperDock));
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}