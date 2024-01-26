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
using withersdk.ISB;
using withersdk.Ui;

namespace Witherbit_IS_Forms.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            this.OpacityAnimation(0, 1, 0.2);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (uiName.Text.Length > 0 && uiDepartment.Text.Length > 0)
            {
                MainWindow.Tester = Tester.Build(uiName.Text, uiDepartment.Text);
                this.OpacityAnimation(1, 0, 0.2);
                await Task.Run(() =>
                {
                    Task.Delay(200).Wait();
                    this.Invoke(() =>
                    {
                        MainWindow.SetPage(new TestPage());
                    });
                });
            }
            else
                MessageBox.Show("Требуется, чтобы оба поля содержали в себе хотя бы один символ", "Ошибка");
        }
    }
}
