using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using Bl;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms.DataVisualization.Charting;
using WpfApp.ViewModel;
using AutoMapper;
using Bl.Services;
using WpfApp.ViewModel.Entity;
using WpfApp.ViewModel.Process;

namespace WpfApp
{

    public partial class MainWindow : Window
    {
        private MeteorService _meteorService;
        private ExpeditionService _expeditionService;
        private MagnitudeService _magnitudeService;
        private GroupService _groupService;
        private Process _process;

        public MainWindow()
        {
            InitializeComponent();

            chart.ChartAreas.Add(new ChartArea("Default"));

            // Добавим линию, и назначим ее в ранее созданную область "Default"
            chart.Series.Add(new Series("Series1"));
            chart.Series["Series1"].ChartArea = "Default";
            chart.Series["Series1"].ChartType = SeriesChartType.Line;

            chart1.ChartAreas.Add(new ChartArea("Default"));

            chart1.Series.Add(new Series("Series1"));
            chart1.Series["Series1"].ChartArea = "Default";
            chart1.Series["Series1"].ChartType = SeriesChartType.Point;

            AutoMapperConfig.RegisterMappings();
            Load();
        }

        private void Load()
        {
            _groupService = new GroupService();
            _expeditionService = new ExpeditionService();
            var expiditions = _expeditionService.GetAllExpeditions();
            var expeditionsViewModel = Mapper.Map<List<ExpeditionViewModel>>(expiditions);

            var mainModel = new MainViewModel()
            {
                Expiditions = expeditionsViewModel,
                Days = new List<DayViewModel>(),
                Intervals = new List<IntervalViewModel>(),
                Groups = new List<GroupViewModel>(),
                People = new List<PersonViewModel>(),
                Meteors = new List<MeteorViewModel>()
            };
            this.DataContext = mainModel;

            _process = new Process();
        }

        private void ViewAllGroups_Click(object sender, RoutedEventArgs e)
        {
            var mainModel = (MainViewModel)this.DataContext;
            mainModel.Groups = Mapper.Map<List<GroupViewModel>>(_groupService.GetAll());
        }

        private void AddExpedition_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewExpedition();
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
            Load();
        }

        private void CalculateGeneralReport_Click(object sender, RoutedEventArgs e)
        {
            var mainModel = (MainViewModel)this.DataContext;
            if (mainModel.SelectedExpeditionProcess == null)
            {
                MessageBox.Show("Выберите экспедицию в списке слева");
                return;
            }
            var id = mainModel.SelectedExpeditionProcess.Id;
            var reportItems = _process.CalculateGeneralReport(id, "per");
            mainModel.Report = new ReportViewModel()
            {
                GeneralReportItems = Mapper.Map<List<GeneralReportItemViewModel>>(reportItems)
            };
        }

        private void CalculateMagnitudeChart_Click(object sender, RoutedEventArgs e)
        {
            var mainModel = (MainViewModel)this.DataContext;
            if (mainModel.SelectedExpeditionProcess == null)
            {
                MessageBox.Show("Выберите экспедицию в списке слева");
                return;
            }
            var id = mainModel.SelectedExpeditionProcess.Id;

            // добавим данные линии
            int[] axisXData;
            int[] axisYData;

            _process.CalculateMagnitudeChart(id, out axisXData,out axisYData);
            chart.Series["Series1"].Points.Clear();
            chart.Series["Series1"].Points.DataBindXY(axisXData, axisYData);

        }

        private void CalculateDencity_Click(object sender, RoutedEventArgs e)
        {
            var m = 0;
            var Z = 0;
            double h = 0;
            if (!ConvertToNumber(this.txbMagnitude.Text, out m)) return;
            if (!ConvertToNumber(this.txbRadiantHeight.Text, out h)) return;
            if (!ConvertToNumber(this.txbZenit.Text, out Z)) return;
            //var source = Convert.ToString(txbSource.SelectedItem);
            var source = "per"; //TODO: сделать нормальный ввод потока
            var mainModel = (MainViewModel)this.DataContext;
            if (mainModel.SelectedExpeditionProcess == null)
            {
                MessageBox.Show("Выберите интервал в списке слева");
                return;
            }
            var id = mainModel.SelectedExpeditionProcess.Id;
            var dencity = _process.GetDencityOfMeteorShower(id, h, m, Z, source);
            _process.Dencity = dencity;
            DencityResult.Text = Convert.ToString(dencity);

            //пространственная плотность
            if (_process.Dencity == 0 || _process.GeoCentrVelocityKmCh == 0)
            {
                MessageBox.Show(
                    "Для расчета пространственной плотности, требуется расчитать плотность потока и геоцентрическую скорость");
            }
            var ro = _process.GetSpaceDencity(_process.Dencity, _process.GeoCentrVelocityKmCh);
            txbSpaceDencity.Text = ro.ToString();
        }

        private void CalcAndleVelocity_Click(object sender, RoutedEventArgs e)
        {
            var mainModel = (MainViewModel)this.DataContext;
            if (mainModel.SelectedExpeditionProcess == null)
            {
                MessageBox.Show("Выберите экспедицию в списке слева");
                return;
            }
            var id = mainModel.SelectedExpeditionProcess.Id;
            
            var m = 0;
            var Z = 0;
            
            if (!ConvertToNumber(this.txbMagnitudeV.Text, out m)) return;
            if (!ConvertToNumber(this.txbZenitV.Text, out Z)) return;
            //var source = Convert.ToString(txbSource.SelectedItem);
            var source = "per";
            double w = 0;
            w = _process.GetAngleVelocity(id, m,Z,source);
            _process.AngleVelocity5Point = w; //TODO: нельзя так присваевать это могут быть разные расчеты
            this.txbAngleVelocity.Text = _process.AngleVelocity.ToString();
        }

        public bool ConvertToNumber(string str, out int i)
        {
            if (!int.TryParse(str, out i))
            {
                MessageBox.Show("Неверный ввод параметра!");
                return false;
            }
            return true;
        }

        public bool ConvertToNumber(string str, out double i)
        {
            if (!double.TryParse(str, out i))
            {
                MessageBox.Show("Неверный ввод параметра!");
                return false;
            }
            return true;
        }

        private void CalcGeoCentrVelocity_Click(object sender, RoutedEventArgs e)
        {
            var v = _process.GetGeoCentrVelocity(_process.AngleVelocity);
            _process.GeoCentrVelocity = v;
            txbGeoCentrVelocity.Text = v.ToString();
        }



        /// <summary>
        /// Расчет активности метеорного потока
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalcFrequency_Click(object sender, RoutedEventArgs e)
        {
            var mainModel = (MainViewModel)this.DataContext;
            if (mainModel.SelectedExpeditionProcess == null)
            {
                MessageBox.Show("Выберите экспедицию в списке слева");
                return;
            }
            var id = mainModel.SelectedExpeditionProcess.Id;

            double d = 0;
            double t = 0;
            if (!ConvertToNumber(this.txbRadiantDelta.Text, out d)) return;
            if (!ConvertToNumber(this.txbRadiantHourAngle.Text, out t)) return;
            txbFrequency.Text = "";
            foreach (var day in _expeditionService.Get(id).Days)
            {
                txbFrequency.Text += day.Date.ToShortDateString() + ":";
                var frequencies = _process.GetFrequencyByDay(day.Id, d, t);
                int i = 0;
                foreach (var frequency in frequencies)
                {

                    txbFrequency.Text += Environment.NewLine;
                    var str = "№" + day.Intervals.ToList()[i].Number + " (" + day.Intervals.ToList()[i].Group.Name + ") - ";
                    txbFrequency.Text += str + frequency.ToString();
                    i++;
                }
                txbFrequency.Text += Environment.NewLine;
            }
            
        }

        private void CalcAbsoluteMagnitude_Click(object sender, RoutedEventArgs e)
        {
            var mainModel = (MainViewModel)this.DataContext;
            if (mainModel.SelectedExpeditionProcess == null)
            {
                MessageBox.Show("Выберите экспедицию в списке слева");
                return;
            }
            var id = mainModel.SelectedExpeditionProcess.Id;

            double m0 = 0;
            double h = 0;
            double m = 0;
            if (! ConvertToNumber(txbRadiantHeightMagnitude.Text, out h)) return;
            if (!ConvertToNumber(txbMagnitudeForCalcAbsolute.Text, out m)) return;
            m0 = _process.GetAbsoluteMagnitude(id, h, m);
            txbAbsoluteMagnitude.Text = m0.ToString();
        }

        private void CalculateLuminosityChart_Click(object sender, RoutedEventArgs e)
        {
            var mainModel = (MainViewModel)this.DataContext;
            if (mainModel.SelectedExpeditionProcess == null)
            {
                MessageBox.Show("Выберите экспедицию в списке слева");
                return;
            }
            var id = mainModel.SelectedExpeditionProcess.Id;
            double h = 0;
            if (!ConvertToNumber(txbRadiantHeightMagnitude.Text, out h)) return;
            // добавим данные линии
            int[] axisXData;
            double[] axisYData;

            _process.CalculateLuminosityChart(id, h , out axisXData, out axisYData);
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series1"].Points.DataBindXY(axisXData, axisYData);
        }
    }

    //private StackPanel CreateExpanders(System.Data.Entity.DbSet entities, string propertyNameForHeader)
    //{
    //    var stackPanelMain = new StackPanel();
    //    //цикл по Entities, например, Expedition 
    //    int i = 0;
    //    foreach (var entity in entities)
    //    {
    //        var radioButton = new RadioButton();
    //        radioButton.Checked += radioButton_Checked;
    //        var expander = new Expander();
    //        expander.Header = entity.GetType().GetProperty(propertyNameForHeader).GetValue(entity);

    //        //составляем внутренности expander 
    //        // он содержит:
    //        // имя свойства Entity (из DataAnnotations.DisplayAttribute)
    //        // значение этого свойства
    //        // и так несколько раз

    //        var stackPanel = new StackPanel() {  Margin = new Thickness() {  Left = 15, Top=15, Right=1, Bottom=1 } };
    //        //перебираем все свойства класса нашей Entity
    //        foreach (var prop in typeof(Expedition).GetProperties())
    //        {
    //            //получаем все аттрибуты
    //            object[] attrs = prop.GetCustomAttributes(false);
    //            Label label = new Label();
    //            foreach (Attribute attr in attrs)
    //            {
    //                if (attr is DisplayableAttribute)
    //                {
    //                    string name = (attr is DisplayAttribute) ? ((DisplayAttribute)attr).GetName() : prop.Name;
    //                    label = new Label() { Content = name + ": " + prop.GetValue(entity) };
    //                }
    //            }
    //            stackPanel.Children.Add(label);
    //        }
    //        expander.Content = stackPanel;
    //        radioButton.Content = expander;
    //        stackPanelMain.Children.Add(radioButton);
    //        i++;
    //    }
    //    return stackPanelMain;
    //}

    //private void radioButton_Checked(object sender, RoutedEventArgs e)
    //{
    //    //надо по выбранному checkbox понять у какого элемента он был установлен, например, у какой експедиции. 
    //    //по этой експедиции найти все дни и вывести их таким же образом в StackPanel - StPDays
    //}

    //private void button_Click(object sender, RoutedEventArgs e)
    //{
    //    var test = new ClassTest() { Expiditions = new List<Expedition>()
    //    {
    //        new Expedition() {Name = "111", Latitude =  12},
    //        new Expedition { Name = "222", Latitude = 13}
    //    } };
    //    this.DataContext = test;
    //}
}

