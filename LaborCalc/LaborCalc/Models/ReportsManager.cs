namespace LaborCalc.Models;

public class ReportsManager
{
    private Project _project { get; set; }
    private string _path => $"{_project.Location}\\report{_project.Name}";
    private List<string> _reports = new();

    public ReportsManager(Project project)
    {
        _project = project;
    }

    public string DesignReport(Step step, string html)
    {
        string stepReportHead = $@"
<h2>{step.Name}</h2>
<p><i>Расчёт производится в соответствии с пунктом {step.MethodicId.ToString().Replace(",", ".")} - {step.MethodicName}.</i></p>
";

        string stepReportTail = $@"
<p><b>Итого: {step.Labor.Out()} н/ч</b></p>
" + "\n";

        return string.Concat(stepReportHead, html, stepReportTail);
    }

    private string Generate()
    {
        foreach (var step in _project.StepsManager.DoneSteps)
            _reports.Add(DesignReport(step, step.CreateHtmlReport()));

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

        try
        {
            Directory.CreateDirectory(_path);
            File.Copy("Helpers/report_style.css", _path);

            using (var sw = new StreamWriter(_path, false, System.Text.Encoding.Default))
            {
                sw.Write(this.Generate());
            }

            Debug.WriteLine($"Запись выполнена в {_path}");

            var process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = _path;
            process.Start();
        }
        catch (Exception e) { Debug.WriteLine(e.Message); }
    }
}
