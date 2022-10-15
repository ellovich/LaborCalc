using Avalonia.Controls;
using Avalonia.Interactivity;

namespace LaborCalc.Views;

public partial class Step02Page : UserControl
{
    private Step02 Step { get; set; }

    public Step02Page()
    {
        InitializeComponent();
        Step = new Step02();
        DataContext = Step;
    }

    public Step02Page(Step step)
    {
        InitializeComponent();
        Step = (Step02)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void AddSubstep(object sender, RoutedEventArgs e)
    {
        var w = (Window)this.Parent.Parent.Parent.Parent.Parent.Parent;
        new Step02ItemsSelector(this, w, Step, null, Step02.ReadyStepsItems).ShowDialog(w);
    }

    public void RemoveSubstep(Step02Table table)
    {
        this.Find<StackPanel>("SubstepsPanel").Children.Remove(table);
    }
}