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
using WpfApp.ViewModel;
using AutoMapper;
using Bl.Services;

namespace WpfApp
{

    public partial class MainWindow : Window
    {
        private MeteorService _meteorService;
        private ExpeditionService _expeditionService;
        private MagnitudeService _magnitudeService;
        private GroupService _groupService;

        public MainWindow()
        {
            InitializeComponent();

            AutoMapperConfig.RegisterMappings();
            Load();
        }

        private void Load()
        {
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
        }

        private void ViewAllGroups_Click(object sender, RoutedEventArgs e)
        {
            var mainModel = (MainViewModel) this.DataContext;
            mainModel.Groups = Mapper.Map<List<GroupViewModel>>(_groupService.GetAll());
        }

        private void AddExpedition_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewExpedition();
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
            Load();
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
}
