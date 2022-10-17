namespace LaborCalc.Models;

public partial class Step04_6 : Step // TODO _T_надстр
{
    public override double MethodicId => 4.6;
    public override string MethodicName => "Создание (доработка) интерактивных 3D-моделей корабля/судна";

    public override double CalcLabor()
    {
        return _T_ВВ + _T_ВР + _T_пом; // трудоёмкость создания (доработки) интерактивных 3D-моделей корабля/судна
    }

    public override string CreateHtmlReport()
    {
        string html = $@"
Общая трудоёмкость создания интерактивных 3D-моделей корабля/судна определяется по формуле 16: <br>
Т<sub>3D-K</sub> = Т<sub>BB</sub> + Т<sub>BР</sub> + Т<sub>пом</sub> <br>
  <br>
<p>
Т<sub>ВВ</sub> = Т<sub>корп</sub> + Т<sub>надстр</sub> + Т<sub>эл</sub> = {_T_корп} + {_T_надстр} + {_T_эл} = {_T_ВВ} <br>
  <br>
Т<sub>корп</sub> = Т<sub>О</sub> + Т<sub>ВЧ</sub> <br>
Т<sub>О</sub> = q<sub>О</sub> ⋅ k<sub>L</sub> ⋅ k<sub>1</sub> ⋅ k<sub>k</sub> ⋅ k<sub>нов</sub> <br>
Т<sub>ВЧ</sub> = q<sub>вч</sub> ⋅ n<sub>вч</sub> ⋅ k<sub>k</sub> ⋅ k<sub>нов</sub> <br>
  <br>
T<sub>надстр</sub> = СУММ(T<sub>надстр<sub>i</sub></sub>)  <br>
</p>

<p>
Т<sub>эл</sub> = (q<sub>ЭЛ<sub>В1</sub></sub> ⋅ n<sub>ЭЛ<sub>В1</sub></sub> + q<sub>ЭЛ<sub>В2</sub></sub> ⋅ n<sub>ЭЛ<sub>В2</sub></sub> + q<sub>ЭЛ<sub>H1</sub></sub> ⋅ n<sub>ЭЛ<sub>H1</sub></sub>) ⋅ k<sub>нов</sub> <br>
n<sub>ЭЛ<sub>В1</sub></sub> = {N_эл_В1} <br>
n<sub>ЭЛ<sub>В2</sub></sub> = {N_эл_В2} <br>
n<sub>ЭЛ<sub>H1</sub></sub> = {N_эл_Н1} <br>
</p>

<p>
Т<sub>ВР</sub> = Т<sub>ВВ</sub> ⋅ k<sub>ВР</sub> ⋅ k<sub>нов</sub>  = {_T_ВВ} ⋅ {_k_ВР} ⋅ {K_T_ВР_3D_нов.Coef} = {_T_ВВ} <br>
k<sub>ВР</sub> = 0.2 ⋅ n<sub>пал</sub> + 0.01 ⋅ n<sub>пом</sub> = 0.2 ⋅ {N_пал} + 0.01 ⋅ {N_пом} = {_k_ВР};
</p>
";

        return html;
    }


    public Step04_6()
    {
        Superstructure._outer = this;
    }


    #region DATA


    #region _T_ВВ  (ф.17)

    private double _T_ВВ => _T_корп + _T_надстр + _T_эл; // внешний вид


    #region _T_корп   (ф.18)

    private double _T_корп => _Т_О + _T_ВЧ;              // (ф.18, п.4.6.2, с.52) // корпус

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_Т_О), nameof(_T_ВЧ), nameof(_T_корп), nameof(_T_ВВ), nameof(_T_ВР))]
    public Correction k_K = s_Corrections4_7_2[0]; // качество конечной модели, опред. низко- или высокополигональным моделированием

    #region _T_O (ф.19)

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_Т_О), nameof(_T_корп), nameof(_T_ВВ), nameof(_T_ВР))]
    public Correction k_L = s_Corrections4_7_1[0]; // сложность разработки в зависимости от наиб. длины корпуса

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_Т_О), nameof(_T_корп), nameof(_T_ВВ), nameof(_T_ВР))]
    public Correction k_1 = s_Corrections3_4_1[0]; // сложность разработки в зависимости сложности геометрии обводов корпуса

    private double _Т_О => _q_O * K_L.Coef * K_1.Coef * K_K.Coef * K_T_О_3D_нов.Coef; // (ф.19, п.4.6.2, с.53) // обводы

    private const double _q_O = 20; // усред. норма времени на создание 3D-модели обводов корпуса
    public static readonly List<Correction> s_Corrections4_7_1 = new()
    {
        new Correction("< 60м", 1),
        new Correction("от 60 до 79м", 1.2),
        new Correction("от 80 до 99м", 1.6),
        new Correction("> 100м", 2.0),
    }; // значения для K_L
    public static readonly List<Correction> s_Corrections3_4_1 = new()
    {
        new Correction("Традиционные обводы корпуса", 1),
        new Correction("Сложные обводы носовой и кормовой оконечности", 1.2),
    }; // значения для K_1
    public static readonly List<Correction> s_Corrections4_7_2 = new()
    {
        new Correction("Низкополигональное", 1),
        new Correction("Восокополигональное", 1.5),
    }; // значения для K_K

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_Т_О), nameof(_T_корп), nameof(_T_ВВ), nameof(_T_ВР))]
    public Correction k_T_О_3D_нов = s_Corrections4_8[0];  // коэффициент корректировки

    #endregion


    #region _T_ВЧ (ф.20)
    private double _T_ВЧ => _q_вч * N_вч * K_K.Coef * K_T_вч_3D_нов.Coef; // конструктивные элементы подводной части корпуса
    private const double _q_вч = 16; // усред. норма создания одного конструктивного элемента подводной части корпуса

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_T_ВЧ), nameof(_T_корп), nameof(_T_ВВ), nameof(_T_ВР))]
    int n_вч; // количество выступающих частей

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_T_ВЧ), nameof(_T_корп), nameof(_T_ВВ), nameof(_T_ВР))]
    Correction k_T_вч_3D_нов = s_Corrections4_8[0]; // коэффициент корректировки
    #endregion


    #endregion _T_корп   (ф.18)


    #region _T_надстр (ф.21)

    private double _T_надстр => Superstructures.Sum(x => x.Labor);

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_T_надстр), nameof(_T_ВВ), nameof(_T_ВР), nameof(Superstructures))]
    double l_наиб = 129.6; // наибольшая длина корабля // TODO REMOVE

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_T_надстр), nameof(_T_ВВ), nameof(_T_ВР))]

    ObservableCollection<Superstructure> superstructures = new();

    [RelayCommand]
    void AddSuperstructure() => Superstructures.Add(new Superstructure($"Надстройка {Superstructures.Count + 1}", 0, _stepCorrection));

    public partial class Superstructure : ViewModelBase
    {
        public static Step04_6 _outer;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] string name;
        [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] double l; // длина надстройки
        [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor))] Correction k_нов_3D = s_Corrections4_8[0];

        public double K_надстр { get; set; }

        public double Labor => _outer._Т_О * K_надстр * K_нов_3D.Coef;

        public Superstructure(string name, double l, Correction k_нов_3D)
        {
            Name = name;
            L = l;
            L = 28.5; // TODO REMOVE
            K_нов_3D = k_нов_3D;

            K_надстр = L / _outer.L_наиб;
        }

        public override string ToString()
        {
            return $"Надстройкка: {Name} T_O:{_outer._Т_О} * K_надстр:{K_надстр} * K_нов:{K_нов_3D.Coef}";
        }

        [RelayCommand]
        void RemoveSuperstructure()
        {
            _outer.Superstructures.Remove(this);
        }
    }

    #endregion _T_надстр (ф.21)


    #region _T_эл     (ф.24)

    private double _T_эл => ((_q_эл_В1 * N_эл_В1) + (_q_эл_В2 * N_эл_В2) + (_q_эл_Н1 * N_эл_Н1)) * K_T_эл_3D_нов.Coef;

    private const double _q_эл_В1 = 40; // усред. норма для оборудования очень большого размера с высокой ст. деталировки
    private const double _q_эл_В2 = 16; // усред. норма для оборудования очень большого размера с низкой  ст. деталировки
    private const double _q_эл_Н1 = 16; // усред. норма для оборудования       большого размера с высокой ст. деталировки

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_T_эл), nameof(_T_ВВ), nameof(_T_ВР))]
    public int n_эл_В1; // кол-во эл-ов оборуд. очень большого размера с высокой ст. деталировки

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_T_эл), nameof(_T_ВВ), nameof(_T_ВР))]
    public int n_эл_В2; // кол-во эл-ов оборуд. очень большого размера с низкой  ст. деталировки

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_T_эл), nameof(_T_ВВ), nameof(_T_ВР))]
    public int n_эл_Н1; // кол-во эл-ов оборуд.       большого размера с высокой ст. деталировки

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor),
        nameof(_T_эл), nameof(_T_ВВ), nameof(_T_ВР))]
    public Correction k_T_эл_3D_нов = s_Corrections4_8[0]; // коэффициент корректировки

    #endregion _T_эл     (ф.24)


    #endregion _T_ВВ  (ф.17)


    #region _T_ВР  (ф.25)

    private double _T_ВР => _T_ВВ * _k_ВР * K_T_ВР_3D_нов.Coef; // внутренне расположение
    private double _k_ВР => 0.2 * N_пал + 0.01 * N_пом; // коэффициент, учитывающих количество палуб и количество помещений

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_T_ВР))] int n_пал; // количество палуб
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_T_ВР))] int n_пом; // количество помещений
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Labor), nameof(_T_ВР))] Correction k_T_ВР_3D_нов = s_Corrections4_8[0]; // коэффициент корректировки

    #endregion  _T_ВР  (ф.25)


    #region _T_пом (ф.??)

    private double _T_пом = 0; // TODO

    #endregion


    public static readonly List<Correction> s_Corrections4_8 = new()
    {
        new Correction("Полная разработка", 1),
        new Correction("Очень высокая", 0.85),
        new Correction("Высокая", 0.7),
        new Correction("Средняя", 0.5),
        new Correction("Низкая", 0.3),
        new Correction("Очень низкая", 0.15),
        new Correction("Не требуется", 0),
    }; // K_3D_нов

    private Correction _stepCorrection = s_Corrections4_8[0]; // общий коэффициент новизны работы
    public Correction StepCorrection // Reactive
    {
        get => _stepCorrection;
        set
        {
            K_T_О_3D_нов = K_T_вч_3D_нов = K_T_эл_3D_нов = K_T_ВР_3D_нов = value;
            foreach (var sup in Superstructures)
                sup.K_нов_3D = value;

            this.SetProperty(ref _stepCorrection, value);
        }
    }

    #endregion DATA
}
