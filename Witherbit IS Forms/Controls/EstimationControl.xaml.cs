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

namespace Witherbit_IS_Forms.Controls
{
    /// <summary>
    /// Логика взаимодействия для EstimationControl.xaml
    /// </summary>
    public partial class EstimationControl : UserControl
    {
        public double Estimation {  get; private set; }
        public EstimationControl()
        {
            InitializeComponent();
            Estimation = 0.5;
        }

        private void ui_MouseEnter(object sender, MouseEventArgs e)
        {
            var grid = sender as Border;
            if(grid == ui0 && Estimation != 0)
            {
                grid.BackgroundFadeTo("#30ff7272".ConvertToBrush(), 0.2);
            }
            else if (grid == ui0point25 && Estimation != 0.25)
            {
                grid.BackgroundFadeTo("#30ffc873".ConvertToBrush(), 0.2);
            }
            else if (grid == ui0point5 && Estimation != 0.5)
            {
                grid.BackgroundFadeTo("#30f0ff73".ConvertToBrush(), 0.2);
            }
            else if (grid == ui0point75 && Estimation != 0.75)
            {
                grid.BackgroundFadeTo("#30abff73".ConvertToBrush(), 0.2);
            }
            else if (grid == ui1 && Estimation != 1)
            {
                grid.BackgroundFadeTo("#3049e8c2".ConvertToBrush(), 0.2);
            }
        }

        private void ui_MouseLeave(object sender, MouseEventArgs e)
        {
            var grid = sender as Border;
            if (grid == ui0 && Estimation != 0)
            {
                grid.BackgroundFadeTo(Brushes.Transparent, 0.2);
            }
            else if (grid == ui0point25 && Estimation != 0.25)
            {
                grid.BackgroundFadeTo(Brushes.Transparent, 0.2);
            }
            else if (grid == ui0point5 && Estimation != 0.5)
            {
                grid.BackgroundFadeTo(Brushes.Transparent, 0.2);
            }
            else if (grid == ui0point75 && Estimation != 0.75)
            {
                grid.BackgroundFadeTo(Brushes.Transparent, 0.2);
            }
            else if (grid == ui1 && Estimation != 1)
            {
                grid.BackgroundFadeTo(Brushes.Transparent, 0.2);
            }
        }

        private void ui_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as Border;
            if (grid == ui0 && Estimation != 0)
            {
                grid.BackgroundFadeTo("#ff7272".ConvertToBrush(), 0.2);
                ui0point25.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui0point5.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui0point75.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui1.BackgroundFadeTo(Brushes.Transparent, 0.2);
                Estimation = 0;
            }
            else if (grid == ui0point25 && Estimation != 0.25)
            {
                grid.BackgroundFadeTo("#ffc873".ConvertToBrush(), 0.2);
                ui0.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui0point5.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui0point75.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui1.BackgroundFadeTo(Brushes.Transparent, 0.2);
                Estimation = 0.25;
            }
            else if (grid == ui0point5 && Estimation != 0.5)
            {
                grid.BackgroundFadeTo("#f0ff73".ConvertToBrush(), 0.2);
                ui0.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui0point25.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui0point75.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui1.BackgroundFadeTo(Brushes.Transparent, 0.2);
                Estimation = 0.5;
            }
            else if (grid == ui0point75 && Estimation != 0.75)
            {
                grid.BackgroundFadeTo("#abff73".ConvertToBrush(), 0.2);
                ui0.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui0point5.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui0point25.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui1.BackgroundFadeTo(Brushes.Transparent, 0.2);
                Estimation = 0.75;
            }
            else if (grid == ui1 && Estimation != 1)
            {
                grid.BackgroundFadeTo("#49e8c2".ConvertToBrush(), 0.2);
                ui0.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui0point25.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui0point75.BackgroundFadeTo(Brushes.Transparent, 0.2);
                ui0point5.BackgroundFadeTo(Brushes.Transparent, 0.2);
                Estimation = 1;
            }
        }
    }
}
