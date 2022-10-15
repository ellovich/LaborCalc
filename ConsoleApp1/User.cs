using CommunityToolkit.Mvvm.ComponentModel;

[INotifyPropertyChanged]
public partial class User
{
    [ObservableProperty] int id;
    [ObservableProperty] string? name;
    [ObservableProperty] int age;
}