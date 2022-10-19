using LaborCalc.Models;
using LaborCalc.Helpers;
using Avalonia.Controls;
using Avalonia.Data;

namespace LaborCalc.Views;

public partial class StepPage : UserControl
{
    //private ObservableCollection<Methodic> Methodics { get; set; }
    //private ObservableCollection<UserControl> MethodicTemplates { get; set; } = new();
    private Step _step;

    public StepPage()
    {
        InitializeComponent();
        _step = new();
        DataContext = _step;

        InitMethodics();
    }

    public StepPage(Step step)
    {
        InitializeComponent();
        _step = step;
        DataContext = _step;

        InitMethodics();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void InitMethodics()
    {
        var panel = this.FindControl<StackPanel>("MethodicsPanel");

        foreach (var item in _step.Methodics)
            panel?.Children.Add(MethodicToControlConverter.CreateMethodicTemplate(item));
    }


    //private void AddSuperDoc_Click(object sender, RoutedEventArgs e)
    //{
    //    var docsPanel = this.FindControl<StackPanel>("DocsPanel");

    //    var newSuperDock = _methodic.AddNewSuperDoc();
    //    docsPanel?.Children.Add(new Methodic02Table(_methodic, newSuperDock));
    //}
}