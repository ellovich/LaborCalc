using Avalonia.Data;
using Avalonia.Data.Converters;
using System.Globalization;

namespace LaborCalc.Helpers;

public class MethodicToTabItemConverter
{
    public static ObservableCollection<TabItem> Convert(TrulyObservableCollection<Methodic> methodics)
    {
        if (methodics is null)
            throw new Exception("Trying to convert non-methodic object to methodic-tab item");

        ObservableCollection<TabItem> tabItems = new();

        foreach (var methodic in methodics)
        {
            var tabItem = new TabItem()
            {
                //[!TabItem.HeaderProperty] = new Binding(nameof(methodic.Name)) { Source = methodic },
                Header = $"{methodic.MethodicId.ToString().Replace(',', '.')}  {methodic.Name}",
                Content = CreateMethodicTemplate(methodic),
                [!TabItem.TagProperty] = new Binding(nameof(methodic.Labor)) { Source = methodic }
            };
            tabItems.Add(tabItem);
        }

        return tabItems;
    }

    public static UserControl CreateMethodicTemplate(Methodic methodic)
    {
        return methodic.MethodicId switch
        {
            1 => new Methodic01Template(methodic),
            2 => new Methodic02Template(methodic),
            3.2 => new Methodic03_2Template(methodic),
            3.6 => new Methodic03_6Template(methodic),
            3.7 => new Methodic03_7Template(methodic),
            3.8 => new Methodic03_8Template(methodic),
            3.9 => new Methodic03_9Template(methodic),
            4.6 => new Methodic04_6Template(methodic),
            5 => new Methodic05Template(methodic),
            6 => new Methodic06Template(methodic),
            7 => new Methodic07Template(methodic),
            8 => new Methodic08Template(methodic),
            9 => new Methodic09Template(methodic),
            10 => new Methodic10Template(methodic),
            11 => new Methodic11Template(methodic),
            12 => new Methodic12Template(methodic),
            13 => new Methodic13Template(methodic),
            14 => new Methodic14Template(methodic),
            15 => new Methodic15Template(methodic),
            16 => new Methodic16Template(methodic),
            17 => new Methodic17Template(methodic),
            18 => new Methodic18Template(methodic),
            _ => throw new Exception(),
        };
    }
}





//public class MethodicToTabItemConverter : IValueConverter
//{
//    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
//    {
//        var methodics = value as TrulyObservableCollection<Methodic>;

//        if (methodics is null)
//            throw new Exception("Trying to convert non-methodic object to methodic-tab item");

//        List<TabItem> tabItems = new List<TabItem>();

//        foreach (var methodic in methodics)
//        {
//            var tabItem = new TabItem()
//            {
//                // [!TabItem.HeaderProperty] = new Binding(nameof(methodic.Name)) { Source = methodic },
//                Header = $"{methodic.MethodicId.ToString().Replace(',', '.')}  {methodic.Name}",
//                Content = CreateMethodicTemplate(methodic),
//                [!TabItem.TagProperty] = new Binding(nameof(methodic.Labor)) { Source = methodic }
//            };
//            tabItems.Add(tabItem);
//        }

//        //tabItems.Insert(0, new TabItem()
//        //{
//        //    Header = "Все этапы",
//        //    Content = new MethodicsManagerTemplate(),
//        //    [!TabItem.TagProperty] = new Binding(nameof(MethodicsManager.FullLabor)) { Source = Project.MethodicsManager }
//        //});

//        return tabItems;
//    }

//    public static UserControl CreateMethodicTemplate(Methodic methodic)
//    {
//        return methodic.MethodicId switch
//        {
//            1 => new Methodic01Template(methodic),
//            2 => new Methodic02Template(methodic),
//            3.2 => new Methodic03_2Template(methodic),
//            3.6 => new Methodic03_6Template(methodic),
//            3.7 => new Methodic03_7Template(methodic),
//            3.8 => new Methodic03_8Template(methodic),
//            3.9 => new Methodic03_9Template(methodic),
//            4.6 => new Methodic04_6Template(methodic),
//            5 => new Methodic05Template(methodic),
//            6 => new Methodic06Template(methodic),
//            7 => new Methodic07Template(methodic),
//            8 => new Methodic08Template(methodic),
//            9 => new Methodic09Template(methodic),
//            10 => new Methodic10Template(methodic),
//            11 => new Methodic11Template(methodic),
//            12 => new Methodic12Template(methodic),
//            13 => new Methodic13Template(methodic),
//            14 => new Methodic14Template(methodic),
//            15 => new Methodic15Template(methodic),
//            16 => new Methodic16Template(methodic),
//            17 => new Methodic17Template(methodic),
//            18 => new Methodic18Template(methodic),
//            _ => throw new Exception(),
//        };
//    }

//    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
//    {
//        return new NotImplementedException();
//    }
//}
