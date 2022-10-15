namespace LaborCalc.Models;

[JsonConverter(typeof(StepJsonConverter))]
public abstract partial class Step : ViewModelBase, IEntity
{
    public int Id => GetHashCode();
    public abstract double MethodicId { get; }
    public abstract string MethodicName { get; }
    public string Name { get; set; }
    public abstract double CalcLabor();
    public double Labor => Math.Round( CalcLabor(), 2 );

    protected Step()
    {
        Name = MethodicName;
    }

    public abstract Report CreateReport();


    [RelayCommand]
    void DeleteStep()
    {
        //var messageBoxCustomWindow = MessageBox.Avalonia.MessageBoxManager
        //               .GetMessageBoxCustomWindow(new MessageBoxCustomParams
        //               {
        //                   Style = Style.UbuntuLinux,
        //                   ContentMessage = "支持FontFamily",
        //                   FontFamily = "Microsoft YaHei,Simsun",
        //                   ButtonDefinitions = new[] {
        //                new ButtonDefinition {Name = "My"},
        //                new ButtonDefinition {Name = "Buttons", Type = ButtonType.Colored}
        //                   },
        //                   WindowStartupLocation = WindowStartupLocation.CenterOwner
        //               });
        //messageBoxCustomWindow.Show();

        // StepsManager.DoneSteps.Remove(this);
    }

    //public void Serialize()
    //{
    //    string personJson = JsonSerializer.Serialize(this, typeof(Step));
    //}

    public override string ToString() => $"Этап {MethodicId}: {Labor}ч";

    public static Step Create(double id, string name)
    {
        return id switch
        {
            1 => new Step01() { Name = name },
            2 => new Step02() { Name = name },
            3.2 => new Step03_2() { Name = name },
            3.6 => new Step03_6() { Name = name },
            3.7 => new Step03_7() { Name = name },
            3.8 => new Step03_8() { Name = name },
            3.9 => new Step03_9() { Name = name },
            5 => new Step05() { Name = name },
            6 => new Step06() { Name = name },
            7 => new Step07() { Name = name },
            8 => new Step08() { Name = name },
            9 => new Step09() { Name = name },
            10 => new Step10() { Name = name },
            11 => new Step11() { Name = name },
            12 => new Step12() { Name = name },
            13 => new Step13() { Name = name },
            14 => new Step14() { Name = name },
            15 => new Step15() { Name = name },
            16 => new Step16() { Name = name },
            17 => new Step17() { Name = name },
            18 => new Step18() { Name = name },
            _ => throw new Exception("No such ID"),
        };
    }
}
