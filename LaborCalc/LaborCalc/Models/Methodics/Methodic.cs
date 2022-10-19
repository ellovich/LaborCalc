namespace LaborCalc.Models;

[JsonConverter(typeof(MethodicJsonConverter))]
public abstract partial class Methodic : ViewModelBase, IEntity
{
    public abstract double MethodicId { get; }
    public abstract string MethodicName { get; }
    public string Name { get; set; }
    protected abstract double CalcLabor();

    [NotifyParentProperty(true)]
    public double Labor => Math.Round( CalcLabor(), 2 );

    protected Methodic()
    {
        Name = MethodicName;
    }

    public abstract string CreateHtmlReport();


    //[RelayCommand]
    //void DeleteMethodic()
    //{
    //    // var messageBoxCustomWindow = MessageBox.Avalonia.MessageBoxManager
    //    //                .GetMessageBoxCustomWindow(new MessageBoxCustomParams
    //    //                {
    //    //                    Style = Style.UbuntuLinux,
    //    //                    ContentMessage = "支持FontFamily",
    //    //                    FontFamily = "Microsoft YaHei,Simsun",
    //    //                    ButtonDefinitions = new[] {
    //    //                 new ButtonDefinition {Name = "My"},
    //    //                 new ButtonDefinition {Name = "Buttons", Type = ButtonType.Colored}
    //    //                    },
    //    //                    WindowStartupLocation = WindowStartupLocation.CenterOwner
    //    //                });
    //    // messageBoxCustomWindow.Show();

    //    // Project.MethodicsManager.DoneSteps.Remove(this);
    //}

    //public void Serialize()
    //{
    //    string personJson = JsonSerializer.Serialize(this, typeof(Methodic));
    //}

    public override string ToString() => $"Этап {MethodicId}: {Labor}ч";

    public static Methodic Create(double id, string name)
    {
        return id switch
        {
            1 => new Methodic01() { Name = name },
            2 => new Methodic02() { Name = name },
            3.2 => new Methodic03_2() { Name = name },
            3.6 => new Methodic03_6() { Name = name },
            3.7 => new Methodic03_7() { Name = name },
            3.8 => new Methodic03_8() { Name = name },
            3.9 => new Methodic03_9() { Name = name },
            4.6 => new Methodic04_6() { Name = name },
            5 => new Methodic05() { Name = name },
            6 => new Methodic06() { Name = name },
            7 => new Methodic07() { Name = name },
            8 => new Methodic08() { Name = name },
            9 => new Methodic09() { Name = name },
            10 => new Methodic10() { Name = name },
            11 => new Methodic11() { Name = name },
            12 => new Methodic12() { Name = name },
            13 => new Methodic13() { Name = name },
            14 => new Methodic14() { Name = name },
            15 => new Methodic15() { Name = name },
            16 => new Methodic16() { Name = name },
            17 => new Methodic17() { Name = name },
            18 => new Methodic18() { Name = name },
            _ => throw new Exception("No such ID"),
        };
    }
}
