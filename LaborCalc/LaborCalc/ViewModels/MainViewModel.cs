using Avalonia.Data;

namespace LaborCalc.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    ObservableCollection<TabItem>? tabs = new();

    public Project Project { get; set; }

    public MainViewModel(Project project)
    {
        Project = project;
        LoadTabs();
    }

    public MainViewModel()
    {
        Project = new();
        LoadTabs();
    }

    private void LoadTabs()
    {
        Tabs = StepToTabItemConverter.Convert(Project.StepsManager.DoneSteps);
        Tabs.Insert(0, new TabItem()
        {
            Header = "Все этапы",
            Content = new StepsManagerPage(Project.StepsManager),
            [!TabItem.TagProperty] = new Binding(nameof(Project.StepsManager.FullLabor)) { Source = Project.StepsManager }
        });
    }


    #region MENU COMMANDS

    [RelayCommand] void New() { }
    [RelayCommand] void Open() { Project.LoadFromJson("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"); } // TODO 
    [RelayCommand] void Properties() { }
    [RelayCommand] void Save() { Project.SaveToJson(); }
    [RelayCommand] void Exit() { }

    [RelayCommand] void ExportToHtml() { Project.ReportsManager.Show(); }
    [RelayCommand] void ExportToExcel() { }
    [RelayCommand] void MailMe() { }

    #endregion
}