using Avalonia.Collections;
using Avalonia.Data;
using LaborCalc.Models;
using MvvmHelpers.Commands;

namespace LaborCalc.Views;

public partial class Methodic02Table : UserControl
{
    private Methodic02 _methodic;
    public Table Table { get; private set; }
    public List<MenuItemViewModel> SingleDocsActions { get; set; } = new();


    public Methodic02Table()
    {
        InitializeComponent();
        Table = new Table("DEFAULT", new Item("Что-то 1", "лист А0", 5));
        DataContext = this;

        BindToTable();
        InitActions();
    }

    public Methodic02Table(Methodic02 methodic, Table table)
    {
        InitializeComponent();

        _methodic = methodic;
        Table = table;
        DataContext = this;

        BindToTable(); 
        InitActions();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void BindToTable()
    {
        var dgv = this.FindControl<DataGrid>("DocsTable");
        var tb = this.FindControl<TextBox>("DocName");

        if (dgv is not null && tb is not null)
        {
            dgv[!DataGrid.ItemsProperty] = new Binding(nameof(Table.TableItems)) { Source = Table };
            tb[!TextBox.TextProperty] = new Binding(nameof(Table.Name)) { Source = Table };
        }
    }

    private void InitActions()
    {

        foreach (var item in Methodic02.SingleDocsTables.SelectMany(t => t.TableItems))
        {
            item.Correction = _methodic.MethodicCorrection;

            SingleDocsActions.Add(new MenuItemViewModel
            {
                Header = item.Name,
                Command = new Command(() => Table.AddItem(item))
            });
        }
    }

    private void RemoveSuperDoc_Click(object sender, RoutedEventArgs e)
    {
        StackPanel? docsPanel = this.Parent as StackPanel;

     //   var docsPanel = this.FindControl<StackPanel>("DocsPanel");

        _methodic.RemoveSuperDoc(Table);
        docsPanel?.Children.Remove(this);
    }
}