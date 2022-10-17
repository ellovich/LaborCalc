using LaborCalc.ViewModels;
using LaborCalc.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace LaborCalc
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            Project project;

            string[] args = Environment.GetCommandLineArgs();







            //args = new string[]
            //{
            //    "",
            //    "\"C:\\Users\\ello\\Desktop\\Проект23130.labor"
            //};








            if (args != null && args.Length > 1)
            {
                project = Project.LoadFromJson(args[1]);
            }
            else
            {
                project = new();
            }


            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainViewModel(project)
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = new MainViewModel(project)
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}