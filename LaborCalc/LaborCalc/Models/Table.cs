using MvvmHelpers.Commands;
using System.Runtime.Serialization;

namespace LaborCalc.Models;

public partial class Item : ViewModelBase, IEntity, IReport
{
    public int Id => GetHashCode();
    public double MethodicId { get; set; }
    public string Name { get; }
    public string Measure { get; }
    public double Norm { get; }

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] double quantity;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] Correction correction;

    public double Labor => Math.Round(Quantity * Norm * Correction.Coef, 3);


    public Item(string name, string measure, double norm)
    {
        Name = name;
        Measure = measure;
        Norm = norm;

        Correction = new Correction("None", 1);
    }


    public string ToHtml()
    {
        return $@"
<tr>
    <td>{Name}</td>
    <td>{Measure}</td>
    <td>{Norm}</td>
    <td>{Correction.Coef}</td>
    <td>{Quantity}</td>
    <td>{Labor.Out()}</td>
</tr>
" + "\n";
    }

    public override string ToString()
    {
        return $"{Name}: {Quantity} ({Measure}) шт. x {Norm} н/ч x {Correction.Coef} ({Correction.Name} ст.кор.) = {Labor.Out()} н/ч/ч;";
    }
}

public partial class Table : ViewModelBase, IEntity, IReport
{
    public int Id => GetHashCode();
    public double MethodicId { get; }
    public string Name { get; set; }

    [ObservableProperty, NotifyPropertyChangedFor(nameof(FullLabor))] ObservableCollection<Item>? tableItems;

    bool _isCustom = false;

    public Table(string name, params Item[] tableItems)
    {
        _isCustom = true;

        Name = name;
        TableItems = new(tableItems);

        for (int i = 0; i < TableItems.Count(); i++)
            TableItems[i].MethodicId = i + 1;

        RemoveItem = new Command<Item>((Item item) => TableItems.Remove(item));
    }

    [JsonConstructor]
    public Table(double methodicId, string name, params Item[] tableItems)
    {
        _isCustom = false;

        MethodicId = methodicId;
        Name = name;
        TableItems = new(tableItems);

        for (int i = 0; i < TableItems.Count; i++)
            TableItems[i].MethodicId = i + 1;

        RemoveItem = new Command<Item>((Item item) => TableItems.Remove(item));
    }

    public List<Item> SelectedItems => TableItems.Where(item => item.Quantity != 0).ToList();

    public double FullLabor => Math.Round(SelectedItems.Sum(item => item.Labor), 3);

    [JsonIgnore]
    public Command<Item> RemoveItem { get; set; }
    public void AddItem(Item item) => TableItems?.Add(item);


    public string ToHtml()
    {
        var caption = _isCustom ? $"{Name}" : $"{MethodicId.ToString().Replace(',', '-')}. {Name}";

        return $@"
<table>
    <caption>{caption}</caption>
    <tr>
        <th>Название</th>
        <th style=""width:15%"">Единица измерения</th>
        <th style=""width:8%"">Норма</th>
        <th style=""width:12%"">Коэффициент</th>
        <th style=""width:10%"">Количество</th>
        <th style=""width:12%"">Трудоёмкость</th>
    </tr>
    {string.Join("\n", SelectedItems.Select(i => i.ToHtml()))}
</table>
" + "\n";
    }

    public override string ToString()
    {
        string str = $"!!! { Name }\n";

        if (TableItems != null)
        {
            foreach (var item in TableItems)
                str += item + "\n";
            str += $" --> Итого: {FullLabor.Out()}\n";
        }

        return str;
    }
}