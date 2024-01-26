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
using System.Xml.Serialization;
using withersdk.ISB.Tests;
using withersdk.Ui;

namespace Witherbit_IS_Forms.Controls
{
    /// <summary>
    /// Логика взаимодействия для TestControl.xaml
    /// </summary>
    public partial class TestControl : UserControl
    {
        public ITest Test { get; set; }
        public TestControl(ITest test)
        {
            InitializeComponent();
            Test = test;
            uiName.Text = test.Name;
            CreateQuestions();
        }

        public void CreateQuestions()
        {
            foreach (var question in Test.Questions)
            {
                uiPanel.Children.Add(new QuestControl(question)
                {
                    Margin = new Thickness(10),
                    Height = 300,
                    Width = 600,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                });
            }
        }

        public void Save()
        {
            foreach (var child in uiPanel.Children)
            {
                var item = child as QuestControl;
                item.Save();
            }
        }
    }
}
