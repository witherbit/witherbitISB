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
using withersdk.ISB;
using withersdk.Ui;

namespace Witherbit_IS_Analyzer.Controls
{
    /// <summary>
    /// Логика взаимодействия для FileControl.xaml
    /// </summary>
    public partial class FileControl : UserControl
    {
        public Tester Tester { get; set; }

        public bool Selected { get; private set; }
        public FileControl(Tester tester)
        {
            InitializeComponent();
            Tester = tester;
            uiName.Text = Tester.Name;
            uiId.Text = Tester.Id;
            uiDepartment.Text = Tester.Departments[0].Name;
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            var border = sender as Border;
            if (!Selected)
            {
                border.BackgroundFadeTo("#358f7a".ConvertToBrush(), 0.2);
            }
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            var border = sender as Border;
            if (!Selected)
            {
                border.BackgroundFadeTo("#ff5c83".ConvertToBrush(), 0.2);
            }
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            if (Selected)
            {
                border.BackgroundFadeTo("#ff5c83".ConvertToBrush(), 0.2);
            }
            else
            {
                border.BackgroundFadeTo("#49e8c2".ConvertToBrush(), 0.2);
            }
            Selected = !Selected;
        }
    }
}
