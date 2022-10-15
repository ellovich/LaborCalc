using Avalonia.Data;

namespace LaborCalc.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    ObservableRangeCollection<TabItem>? tabs = new ObservableRangeCollection<TabItem>();

    StepsManager StepsManager = StepsManager.LoadAll();

    public MainViewModel()
    {
        Tabs.AddRange(StepToTabItemConverter.Convert(StepsManager.DoneSteps));
        Tabs.Insert(0, new TabItem()
        {
            Header = "Все этапы",
            Content = new StepsManagerPage(StepsManager),
            [!TabItem.TagProperty] = new Binding(nameof(StepsManager.FullLabor)) { Source = StepsManager }
        });

        //// сделать чтобы не удалялись старые вкладки
        //StepsManager.DoneSteps.CollectionChanged += (obj, args) =>
        //{
        //    Tabs.Clear();
        //    Tabs.Add(StepManagerPageTab);
        //    Tabs.AddRange(StepToTabItemConverter.Convert(StepsManager.DoneSteps));
        //};
    }

    #region MENU COMMANDS

    [RelayCommand] void New() { /*StepsManager.NewInstance();*/ }
    [RelayCommand] void Open() { StepsManager.LoadAll(); }
    [RelayCommand] void Properties() { }
    [RelayCommand] void Save() { StepsManager.SaveAll(); }
    [RelayCommand] void Exit() { }

    [RelayCommand] void ExportToHtml() {/* Task.Run(() => Report.Show());*/ }
    [RelayCommand] void ExportToExcel() { }
    [RelayCommand] void MailMe() { }

    #endregion
}