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
using Witherbit_IS_Forms.Controls;
using withersdk.Ui;

namespace Witherbit_IS_Forms.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();
            this.OpacityAnimation(0, 1, 0.2);
            DrawTests();
        }


        private void DrawTests()
        {
            foreach(var test in MainWindow.Tester.Departments[0].Tests)
            {
                this.Invoke(() =>
                {
                    uiPanel.Children.Add(new TestControl(test)
                    {
                        Margin = new Thickness(10),
                    });
                });
            }
        }

        public void Save()
        {
            foreach (var item in uiPanel.Children)
            {
                var test = item as TestControl;
                test.Save();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы уверены, что хотите сохранить тест?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Save();
                Directory.CreateDirectory("C:\\Witherbit");
                Directory.CreateDirectory("C:\\Witherbit\\Testers");
                //File.WriteAllText($"C:\\Witherbit\\Testers\\{MainWindow.Tester.Name}_{MainWindow.Tester.Id.Replace('-', '_')}.json", MainWindow.Tester.Serialize());
                MainWindow.Tester.Serialize($"C:\\Witherbit\\Testers\\{MainWindow.Tester.Name}_{MainWindow.Tester.Id.Replace('-', '_')}.dat");
                this.OpacityAnimation(1, 0, 0.2);
                await Task.Run(() =>
                {
                    Task.Delay(200).Wait();
                    this.Invoke(() =>
                    {
                        MainWindow.SetPage(new AuthorizationPage());
                    });
                });
            }
        }
    }
}
