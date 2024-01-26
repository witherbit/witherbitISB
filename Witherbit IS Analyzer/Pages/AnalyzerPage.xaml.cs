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
using withersdk.Ui;
using Witherbit_IS_Analyzer.Controls;

namespace Witherbit_IS_Analyzer.Pages
{
    /// <summary>
    /// Логика взаимодействия для AnalyzerPage.xaml
    /// </summary>
    public partial class AnalyzerPage : Page
    {
        public AnalyzerPage()
        {
            InitializeComponent();
            var departments = MainWindow.Controller.GetDepartments();
            this.OpacityAnimation(0, 1, 0.2);
            foreach (var department in departments)
            {
                uiTemp.Children.Add(new EstimationChartsControl(department)
                {
                    Margin = new Thickness(10)
                });
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            this.OpacityAnimation(1, 0, 0.2);
            await Task.Run(() =>
            {
                Task.Delay(200).Wait();
                this.Invoke(() =>
                {
                    MainWindow.SetPage(new ExplorerPage());
                });
            });
        }
    }
}
