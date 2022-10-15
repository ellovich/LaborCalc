using Avalonia.Interactivity;

namespace LaborCalc.Views;

public partial class Step04Page : UserControl
{
    private Step04 Step { get; set; }

    public Step04Page()
    {
        InitializeComponent();
        Step = new Step04();
        DataContext = Step;
    }

    public Step04Page(Step step)
    {
        InitializeComponent();
        Step = (Step04)step;
        DataContext = Step;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void AddSuperstructure(object sender, RoutedEventArgs e)
    {
        Step.Надстройки.Add(new Step04.Надстройка("Надстройка", 0, Step04.s_Corrections3_4_1[0]));
    }

    public void RemoveSuperstructure(object sender, RoutedEventArgs e)
    {
        try
        {
            Button b = sender as Button;
            DataGridRow r = b.Parent.Parent.Parent.Parent as DataGridRow;

            var надстройки = Step.Надстройки;

            Debug.WriteLine("INDEX " + r.GetIndex());
            Debug.WriteLine("COUNT " + Step.Надстройки.Count);

            надстройки.Remove(надстройки[r.GetIndex()]);
        }
        catch (Exception ex) { Debug.WriteLine(ex.ToString()); }
    }
}