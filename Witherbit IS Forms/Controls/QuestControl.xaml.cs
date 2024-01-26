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
using withersdk.ISB.Tests;

namespace Witherbit_IS_Forms.Controls
{
    /// <summary>
    /// Логика взаимодействия для QuestControl.xaml
    /// </summary>
    public partial class QuestControl : UserControl
    {
        public QuestContainer QuestContainer { get; set; }
        public QuestControl(QuestContainer container)
        {
            InitializeComponent();
            QuestContainer = container;
            uiQuestion.Text = QuestContainer.Quest;
            uiValue.ValueChanged += uiValue_ValueChanged;
        }

        public void Save()
        {
            QuestContainer.Estimation = uiEstimation.Estimation;
            QuestContainer.SignificanceCoefficient = ((int)uiValue.Value);
        }

        private void uiValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                uiTextValue.Text = ((int)uiValue.Value).ToString();
            }
            catch { }
        }
    }
}
