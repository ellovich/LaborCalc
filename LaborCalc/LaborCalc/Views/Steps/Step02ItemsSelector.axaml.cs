using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace LaborCalc.Views;

public partial class Step02ItemsSelector : Window
{
    public Step02Page Steps02Page { get; set; }
    public Step02 Step { get; set; }
    public Step02TableViewModel Step02TableViewModel { get; set; }
    public Window Window { get; set; }
    public List<Item> Items { get; set; }

    public Step02ItemsSelector()
    {
        InitializeComponent();
        Step02TableViewModel = new Step02TableViewModel();
        DataContext = this;
    }

    public Step02ItemsSelector(
        Step02Page steps02Page,
        Window w, 
        Step02 step, 
        Step02TableViewModel step02TableViewModel, 
        List<Item> items)
    {
        InitializeComponent();
        Steps02Page = steps02Page;
        Step02TableViewModel = step02TableViewModel;
        Step = step;
        Window = w;
        Items = items;
        DataContext = this;

        if (Step02TableViewModel != null)
        {
            this.Find<Button>("CreateNewDoc").IsVisible = false;
        }

        this.Find<DataGrid>("DgvSteps").Items = items;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void ToggleItemClick(object sender, RoutedEventArgs e)
    {
        var cb = (CheckBox)sender;
        var index = ((DataGridRow)cb.Parent?.Parent?.Parent?.Parent).GetIndex();

        if (Step02TableViewModel == null)
        {
            if ((bool)cb.IsChecked)
                Step.AddedTables[0].AddItem(Items[index]);
            else
                Step.AddedTables[0].RemoveItem(Items[index]);
        }
        else
        {
            if ((bool)cb.IsChecked)
                Step02TableViewModel.TableModel.AddItem(Items[index]);
            else
                Step02TableViewModel.TableModel.RemoveItem(Items[index]);
        }
    }

    private void CreateSubstep(object sender, RoutedEventArgs e)
    {
        //var w = (Window)this.Parent.Parent.Parent.Parent.Parent.Parent;
        //new Step02ItemsSelector(w, Step02.ReadyStepsItems).ShowDialog(w);
        var table = new Step02Table(Steps02Page, Step);
        Steps02Page.Find<StackPanel>("SubstepsPanel").Children.Insert(1, table);
        this.Close();
    }
}
