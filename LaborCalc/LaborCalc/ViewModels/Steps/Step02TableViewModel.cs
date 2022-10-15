namespace LaborCalc.ViewModels;

public partial class Step02TableViewModel : ViewModelBase
{
    private Step02 Step { get; }
    public List<Item> SingleSteps { get; }
    [ObservableProperty] public Table tableModel;

    public Step02TableViewModel(Step02Table step02Table, Step02Page step02Page, Step02 step)
    {
        Step = step;


        SingleSteps = Step02.SingleStepsItems;


        TableModel = new("");
        Step.AddedTables.Add(TableModel);
    }

    public Step02TableViewModel() { }


    [RelayCommand] 
    void MoveUp() { }

    [RelayCommand]
    void MoveDown() { }

    //[RelayCommand]
    //void EditSubsteps()
    //{
    //    new Step02ItemsSelector(step02Page, w, null, this, Step02.SingleStepsItems).ShowDialog(w);
    //}

    //[RelayCommand]
    //public void RemoveSubstep()
    //{
    //    ((Step02)_step02PageViewModel.Step).AddedTables.Remove(TableModel);
    //    step02Page.RemoveSubstep(step02Table);
    //}
}
