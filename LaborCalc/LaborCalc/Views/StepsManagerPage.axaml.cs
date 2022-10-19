namespace LaborCalc.Views;

public partial class StepsManagerPage : UserControl
{
    private StepsManager StepsManager { get; set; }

    public StepsManagerPage()
    {
        InitializeComponent();
        StepsManager = new StepsManager();
        DataContext = StepsManager;

    //    InitTreeDataGrid();
    }

    public StepsManagerPage(StepsManager stepsManager)
    {
        InitializeComponent();
        StepsManager = stepsManager;
        DataContext = StepsManager;

    //    InitTreeDataGrid();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }


    public void InitTreeDataGrid()
    {
        //Source = new FlatTreeDataGridSource<Step>(StepsManager.DoneSteps)
        //{
        //    Columns =
        //    {
        //        new TextColumn<Step, string>("Наименование", x => x.Name, (r, v) => r.Name = v, new GridLength(6, GridUnitType.Star))
        //            {
        //                IsTextSearchEnabled = true
        //            },
        //        new TextColumn<Step, double>("Трудоёмкость", x => x.Labor, new GridLength(3, GridUnitType.Star))
        //        }
        //};
    }
}