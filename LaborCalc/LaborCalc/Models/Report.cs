namespace LaborCalc.Models;

public class Report
{
    public StepsManager StepsManager;

    private string path => $@"Reports\report{StepsManager.ProjName}.html";
    private readonly List<string> s_reports = new();

    public Report(Step step, string html)
    {
        string stepReportHead = $@"
<h2>{step.Name}</h2>
<p><i>Расчёт производится в соответствии с пунктом {step.MethodicId.ToString().Replace(",",".")} - {step.MethodicName}.</i></p>
";

        string stepReportTail = $@"
<p><b>Итого: {step.Labor.Out()} н/ч</b></p>
" + "\n";

        s_reports.Add(stepReportHead + html + stepReportTail);
    }

    private string Generate()
    {
        return $@"
<!doctype html>

<html lang=""en-ru"">
    <head>
        <title>Проект {StepsManager.ProjName}</title>
        <link rel=""stylesheet"" href=""report_style.css""/>
    </head>
    <body>
        <h1>Пояснительная записка к расчёту трудоёмкости работ по проекту {StepsManager.ProjName}</h1>
        {string.Join("<hr>", s_reports)}
        <hr>
        <h2>Общая трудоёмкость проекта: {StepsManager.FullLabor.Out()} н/ч</h2>
    </body>
</html>
";
    }

    public void Show()
    {
        s_reports.Clear();

        foreach (var step in StepsManager.DoneSteps)
            step.CreateReport();

        try
        {
            //System.IO.Directory.CreateDirectory(path);
            using (var sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                sw.Write(Generate());

            Debug.WriteLine($"Запись выполнена в {path}");
        }
        catch (Exception e) { Debug.WriteLine(e.Message); }

        try
        {
            var process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = path;
            process.Start();
        }
        catch (Exception e) { Debug.WriteLine(e.Message); }
    }
}
