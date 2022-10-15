using Avalonia.Web.Blazor;

namespace LaborCalc.Web
{
    public partial class App
    {
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            WebAppBuilder.Configure<LaborCalc.App>()
                .SetupWithSingleViewLifetime();
        }
    }
}