using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;
using Witherbit_IS_Analyzer.Controls;
using withersdk.ISB;
using withersdk.Ui;

namespace Witherbit_IS_Analyzer.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExplorerPage.xaml
    /// </summary>
    public partial class ExplorerPage : Page
    {
        public ExplorerPage()
        {
            InitializeComponent();
            this.OpacityAnimation(0, 1, 0.2);
            Load();
        }

        private void Load()
        {
            Directory.CreateDirectory("C:\\Witherbit\\Testers");
            foreach(var file in Directory.GetFiles("C:\\Witherbit\\Testers"))
            {
                uiPanel.Children.Add(new FileControl(Tester.DeserializeFromFile(file))
                {
                    Margin = new Thickness(5),
                    Height = 60,
                    Width = 650
                });
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Controller = new EstimationController();
            foreach (var item in uiPanel.Children)
            {
                var file = item as FileControl;
                if (file.Selected)
                    MainWindow.Controller.Testers.Add(file.Tester);
            }
            if(MainWindow.Controller.Testers.Count > 0)
            {
                this.OpacityAnimation(1, 0, 0.2);
                await Task.Run(() =>
                {
                    Task.Delay(200).Wait();
                    this.Invoke(() =>
                    {
                        MainWindow.SetPage(new AnalyzerPage());
                    });
                });
            }
        }
    }
}
