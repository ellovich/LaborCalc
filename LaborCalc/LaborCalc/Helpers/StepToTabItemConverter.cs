using Avalonia.Data;
using Avalonia.Data.Converters;
using System.Globalization;

namespace LaborCalc.Helpers;

public class StepToTabItemConverter
{
    public static ObservableCollection<TabItem> Convert(TrulyObservableCollection<Step> steps)
    {
        if (steps is null)
            throw new Exception("Trying to convert non-step object to step-tab item");

        ObservableCollection<TabItem> tabItems = new();

        foreach (var step in steps)
        {
            var tabItem = new TabItem()
            {
                //[!TabItem.HeaderProperty] = new Binding(nameof(step.Name)) { Source = step },
                Header = $"{step.MethodicId.ToString().Replace(',', '.')}  {step.Name}",
                Content = CreateStepPage(step),
                [!TabItem.TagProperty] = new Binding(nameof(step.Labor)) { Source = step }
            };
            tabItems.Add(tabItem);
        }

        return tabItems;
    }

    public static UserControl CreateStepPage(Step step)
    {
        return step.MethodicId switch
        {
            1 => new Step01Page(step),
            2 => new Step02Page(step),
            3.2 => new Step03_2Page(step),
            3.6 => new Step03_6Page(step),
            3.7 => new Step03_7Page(step),
            3.8 => new Step03_8Page(step),
            3.9 => new Step03_9Page(step),
            4.6 => new Step04_6Page(step),
            5 => new Step05Page(step),
            6 => new Step06Page(step),
            7 => new Step07Page(step),
            8 => new Step08Page(step),
            9 => new Step09Page(step),
            10 => new Step10Page(step),
            11 => new Step11Page(step),
            12 => new Step12Page(step),
            13 => new Step13Page(step),
            14 => new Step14Page(step),
            15 => new Step15Page(step),
            16 => new Step16Page(step),
            17 => new Step17Page(step),
            18 => new Step18Page(step),
            _ => throw new Exception(),
        };
    }
}





//public class StepToTabItemConverter : IValueConverter
//{
//    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
//    {
//        var steps = value as TrulyObservableCollection<Step>;

//        if (steps is null)
//            throw new Exception("Trying to convert non-step object to step-tab item");

//        List<TabItem> tabItems = new List<TabItem>();

//        foreach (var step in steps)
//        {
//            var tabItem = new TabItem()
//            {
//                // [!TabItem.HeaderProperty] = new Binding(nameof(step.Name)) { Source = step },
//                Header = $"{step.MethodicId.ToString().Replace(',', '.')}  {step.Name}",
//                Content = CreateStepPage(step),
//                [!TabItem.TagProperty] = new Binding(nameof(step.Labor)) { Source = step }
//            };
//            tabItems.Add(tabItem);
//        }

//        //tabItems.Insert(0, new TabItem()
//        //{
//        //    Header = "Все этапы",
//        //    Content = new StepsManagerPage(),
//        //    [!TabItem.TagProperty] = new Binding(nameof(StepsManager.FullLabor)) { Source = Project.StepsManager }
//        //});

//        return tabItems;
//    }

//    public static UserControl CreateStepPage(Step step)
//    {
//        return step.MethodicId switch
//        {
//            1 => new Step01Page(step),
//            2 => new Step02Page(step),
//            3.2 => new Step03_2Page(step),
//            3.6 => new Step03_6Page(step),
//            3.7 => new Step03_7Page(step),
//            3.8 => new Step03_8Page(step),
//            3.9 => new Step03_9Page(step),
//            4.6 => new Step04_6Page(step),
//            5 => new Step05Page(step),
//            6 => new Step06Page(step),
//            7 => new Step07Page(step),
//            8 => new Step08Page(step),
//            9 => new Step09Page(step),
//            10 => new Step10Page(step),
//            11 => new Step11Page(step),
//            12 => new Step12Page(step),
//            13 => new Step13Page(step),
//            14 => new Step14Page(step),
//            15 => new Step15Page(step),
//            16 => new Step16Page(step),
//            17 => new Step17Page(step),
//            18 => new Step18Page(step),
//            _ => throw new Exception(),
//        };
//    }

//    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
//    {
//        return new NotImplementedException();
//    }
//}
