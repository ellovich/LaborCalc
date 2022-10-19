namespace LaborCalc.Models;

public class ReportsManager
{
    private Project _project { get; set; } 
    private string _reportPath => $"{_project.Location}\\Пояснительная записка {_project.Name}.html";
    private string _reportStylePath => $"{_project.Location}\\report_style.css";


    private List<string> _reports = new();

    public ReportsManager(Project project)
    {
        _project = project;
    }

    public string DesignReport(Methodic methodic, string html)
    {
        string methodicReportHead = $@"
<h2>{methodic.Name}</h2>
<p><i>Расчёт производится в соответствии с пунктом {methodic.MethodicId.ToString().Replace(",", ".")} - {methodic.MethodicName}.</i></p>
";

        string methodicReportTail = $@"
<p><b>Итого: {methodic.Labor.Out()} н/ч</b></p>
" + "\n";

        return string.Concat(methodicReportHead, html, methodicReportTail);
    }

    private string GenerateReport()
    {
        //foreach (var methodic in _project.StepsManager.DoneSteps)
        //    _reports.Add(DesignReport(methodic, methodic.CreateHtmlReport()));

        return $@"
<!doctype html>

<html lang=""en-ru"">
    <head>
        <title>Проект {_project.Name}</title>
        <link rel=""stylesheet"" href=""report_style.css""/>
    </head>
    <body>
        <h1>Пояснительная записка к расчёту трудоёмкости работ по проекту {_project.Name}</h1>
        {string.Join("<hr>", _reports)}
        <hr>
        <h2>Общая трудоёмкость проекта: {_project.StepsManager.FullLabor.Out()} н/ч</h2>
    </body>
</html>
";
    }

    public void Show()
    {
        _reports.Clear();

        Directory.CreateDirectory($"{_project.Location}");

        if(!File.Exists(_reportStylePath))
            File.Copy("Helpers/report_style.css", _reportStylePath);

        using (StreamWriter sw = new(_reportPath))
            sw.WriteLine(GenerateReport());
        Debug.WriteLine($"Запись выполнена в {_reportPath}");

        var process = new Process();
        process.StartInfo.UseShellExecute = true;
        process.StartInfo.FileName = _reportPath;
        process.Start();
    }

    public override string ToString()
    {
        return _project.Name;
    }
}
