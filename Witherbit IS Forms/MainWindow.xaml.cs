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
using withersdk.Ui;
using withersdk.ISB;
using Witherbit_IS_Forms.Pages;

namespace Witherbit_IS_Forms
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Tester Tester { get; set; }
        public static MainWindow Instance { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            StateChanged += StateChange;
            SetPage(new AuthorizationPage());
        }

        internal static Page SetPage(Page page)
        {
            var result = Instance.uiFrame.Content as Page;
            Instance.uiFrame.Content = page;
            return result;
        }
        // Верхний бар (открыть, закрыть, перетаскивать окно)
        #region TopBar                                                  

        private void Window_Loaded(object sender, RoutedEventArgs e)    //При загрузке окна происходит размытие
        {
            this.EnableBlur();
        }

        private void StateChange(object sender, EventArgs e)            //анимация при сворачивании окна, постепенно меняет прозрачность
        {
            try
            {
                this.OpacityAnimation(0, 1, 0.1);
            }
            catch (Exception ex)
            {
            }
        }

        private void UI_MouseEnter(object sender, MouseEventArgs e)
        {
            var grid = sender as Grid;
            if (grid == uiGridButtonExit)
            {
                ellipseClose.Fill = "#fe90ab".ConvertToBrush();
            }
            else if (grid == uiGridButtonMinimize)
            {
                ellipseMinimize.Fill = "#76ffde".ConvertToBrush();
            }
        }

        private void UI_MouseLeave(object sender, MouseEventArgs e)
        {
            var grid = sender as Grid;
            if (grid == uiGridButtonExit)
            {
                ellipseClose.Fill = "#ff5c83".ConvertToBrush();
            }
            else if (grid == uiGridButtonMinimize)
            {
                ellipseMinimize.Fill = "#49e8c2".ConvertToBrush();
            }
        }
        private async void UI_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as Grid;
            if (grid == uiGridButtonExit)
            {
                Close();
            }
            else if (grid == uiGridButtonMinimize)
            {
                this.OpacityAnimation(1, 0, 0.2);
                await Task.Run(() =>
                {
                    Task.Delay(200).Wait();
                    this.Invoke(new Action(() =>
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Minimized;
                    }));
                });
            }
        }

        private void uiGridTab_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        #endregion                                                      
    }
}
