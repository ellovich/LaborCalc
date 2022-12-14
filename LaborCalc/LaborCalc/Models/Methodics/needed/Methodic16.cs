namespace LaborCalc
{
    public partial class Methodic16 : Methodic
    {
        public override double MethodicId => 16;
        public override string MethodicName => "Оформление отчётных материалов";

        protected override double CalcLabor()
        {
            return T_16_1.FullLabor;
        }

        public override string CreateHtmlReport()
        {
            string html = $@"
<p>Трудозатраты на оформление отчётных материалов по результатам выполнения работ рассчиваются согласно следующей таблице:</p>
{T_16_1.ToHtml()}
";

            return html;
        }
        

        public Methodic16()
        {
            t_16_1 = new(16.1, "Нормы времени на оформление отчетных материалов",
                new Item("Создание презентации", "1 слайд", 7.0),
                new Item("Создание демонстрационного видеоролика", "1 видеосцена", 4.5),
                new Item("Создание электронного носителя (подготовка файлов к записи, запись носителя)", "1 носитель", 4.4),
                new Item("Маркировка электронного носителя", "1 носитель", 2.2)
            );
        }

        [JsonConstructor]
        public Methodic16(int a = 0) { }


        #region DATA

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))]
        Table t_16_1;

        #endregion DATA
    }
}
