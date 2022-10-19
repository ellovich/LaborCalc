using Avalonia.Data;

namespace LaborCalc.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    ObservableCollection<TabItem>? tabs = new();

    public Project Project { get; set; }

    public MainViewModel()
    {
        string[] args = Environment.GetCommandLineArgs();

        //args = new string[]
        //{
        //    "",
        //    "C:\\Users\\ello\\Desktop\\TEST_PROJECT.labor"
        //};


        Project project;

        if (args != null && args.Length > 1)
        {
            Project = Project.LoadFromJson(args[1]);
            Project.ReportsManager = new(Project); // создается отдельно из-за зацикливания
        }
        else
        {
            Project = new();
        }

        LoadTabs();
    }

    private void LoadTabs()
    {
        Tabs = MethodicToTabItemConverter.Convert(Project.StepsManager.DoneSteps);
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