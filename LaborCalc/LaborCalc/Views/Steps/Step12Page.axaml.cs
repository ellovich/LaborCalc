using Avalonia.Interactivity;

namespace LaborCalc.Views;

public partial class Step12Page : UserControl
{
    private Step12 Step { get; set; }

    public Step12Page()
    {
        InitializeComponent();
        Step = new Step12();
        DataContext = Step;
    }

    public Step12Page(Step step)
    {
        InitializeComponent();
        Step = (Step12)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void AddBigSubstep(object sender, RoutedEventArgs e)
    {
        //var table = new Step02Table(this, Step12PageViewModel);
        //this.Find<StackPanel>("SubstepsPanel").Children.Add(table);
    }

    private void AddSubstep(object sender, RoutedEventArgs e)
    {
        var dgv = this.Find<DataGrid>("Substeps");

        if (dgv.IsVisible)
            new Step02ItemsSelector().ShowDialog((Window)Parent);
        else
        {
            dgv.IsVisible = true;
            new Step02ItemsSelector().ShowDialog((Window)Parent.Parent.Parent.Parent.Parent.Parent);
        }
    }

    public void RemoveSubstep(Step02Table table)
    {
        this.Find<StackPanel>("SubstepsPanel").Children.Remove(table);
    }
}