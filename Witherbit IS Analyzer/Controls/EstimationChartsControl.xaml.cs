using LiveCharts;
using LiveCharts.Wpf;
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
using withersdk.ISB.Tables;

namespace Witherbit_IS_Analyzer.Controls
{
    /// <summary>
    /// Логика взаимодействия для EstimationChartsControl.xaml
    /// </summary>
    public partial class EstimationChartsControl : UserControl
    {
        public EstimationChartsControl(string departmentName)
        {
            InitializeComponent();
            uiDepartment.Text = departmentName;
            Load(departmentName);
        }

        public void Load(string departmentName)
        {
            var accessControl = new SeriesCollection();
            var antivirus = new SeriesCollection();
            var remoteWork = new SeriesCollection();
            var infoInsrastructure = new SeriesCollection();
            var all = new SeriesCollection();
            var p1 = new SeriesCollection();
            var p2 = new SeriesCollection();
            var p3 = new SeriesCollection();
            var p4 = new SeriesCollection();
            var tables = MainWindow.Controller.GetEstimationTables(departmentName);
            foreach (var table in tables)
            {
                if(table.Test.Name == "Обеспечение информационной безопасности при управлении доступом и регистрации")
                {
                    accessControl.Add(new LineSeries
                    {
                        Title = table.Tester.Name,
                        Values = new ChartValues<double>(table.GetRow(0))
                    });
                    p1.Add(new LineSeries
                    {
                        Title = table.Tester.Name,
                        Values = new ChartValues<double>(table.GetRow(1)),
                        PointGeometry = DefaultGeometries.Diamond,
                    });
                    p1.Add(new LineSeries
                    {
                        Title = table.Tester.Name,
                        Values = new ChartValues<double>(table.GetRow(2)),
                        PointGeometry = DefaultGeometries.Cross,
                        PointGeometrySize = 5
                    });
                }
                else if (table.Test.Name == "Обеспечение информационной безопасности средствами антивирусной защиты")
                {
                    antivirus.Add(new LineSeries
                    {
                        Title = table.Tester.Name,
                        Values = new ChartValues<double>(table.GetRow(0))
                    });
                    p2.Add(new LineSeries
                    {
                        Title = table.Tester.Name,
                        Values = new ChartValues<double>(table.GetRow(1)),
                        PointGeometry = DefaultGeometries.Diamond,
                    });
                    p2.Add(new LineSeries
                    {
                        Title = table.Tester.Name,
                        Values = new ChartValues<double>(table.GetRow(2)),
                        PointGeometry = DefaultGeometries.Cross,
                        PointGeometrySize = 5
                    });
                }
                else if (table.Test.Name == "Обеспечение информационной безопасности при дистанционном режиме работы")
                {
                    remoteWork.Add(new LineSeries
                    {
                        Title = table.Tester.Name,
                        Values = new ChartValues<double>(table.GetRow(0))
                    });
                    p3.Add(new LineSeries
                    {
                        Title = table.Tester.Name,
                        Values = new ChartValues<double>(table.GetRow(1)),
                        PointGeometry = DefaultGeometries.Diamond,
                    });
                    p3.Add(new LineSeries
                    {
                        Title = table.Tester.Name,
                        Values = new ChartValues<double>(table.GetRow(2)),
                        PointGeometry = DefaultGeometries.Cross,
                        PointGeometrySize = 5
                    });
                }
                else if (table.Test.Name == "Обеспечение информационной безопасности информационной инфраструктуры")
                {
                    infoInsrastructure.Add(new LineSeries
                    {
                        Title = table.Tester.Name,
                        Values = new ChartValues<double>(table.GetRow(0))
                    });
                    p4.Add(new LineSeries
                    {
                        Title = table.Tester.Name,
                        Values = new ChartValues<double>(table.GetRow(1)),
                        PointGeometry = DefaultGeometries.Diamond,
                    });
                    p4.Add(new LineSeries
                    {
                        Title = table.Tester.Name,
                        Values = new ChartValues<double>(table.GetRow(2)),
                        PointGeometry = DefaultGeometries.Cross,
                        PointGeometrySize = 5
                    });
                }
            }
            uiAccessControlTest.Series = accessControl;
            uiAntivirus.Series = antivirus;
            uiRemoteWork.Series = remoteWork;
            uiII.Series = infoInsrastructure;
            uiP1.Series = p1;
            uiP2.Series = p2;
            uiP3.Series = p3;
            uiP4.Series = p4;
            for (int i = 0; i < 4; i++)
            {
                var est = MainWindow.Controller.GetEstimations(departmentName, i);
                all.Add(new LineSeries
                {
                    Title = $"Общие оценки для П{i + 1}",
                    Values = new ChartValues<double>(est)
                });
            }
            for (int i = 0; i < 4; i++)
            {
                all.Add(new LineSeries
                {
                    Title = $"Общий коэффициент значимости для П{i + 1}",
                    Values = new ChartValues<double>(MainWindow.Controller.GetSignificanceCoefficients(departmentName)[i]),
                    PointGeometry = DefaultGeometries.Cross,
                });
            }
            uiAll.Series = all;

            var estTotal1 = MainWindow.Controller.GetEstimations(departmentName, 0).Min();
            uiValue1.Text = Math.Round(estTotal1, 3).ToString();
            uiLevel1.Text = GetLevelByValue(estTotal1).ToString();

            var estTotal2 = MainWindow.Controller.GetEstimations(departmentName, 1).Min();
            uiValue2.Text = Math.Round(estTotal2, 3).ToString();
            uiLevel2.Text = GetLevelByValue(estTotal2).ToString();

            var estTotal3 = MainWindow.Controller.GetEstimations(departmentName, 2).Min();
            uiValue3.Text = Math.Round(estTotal3, 3).ToString();
            uiLevel3.Text = GetLevelByValue(estTotal3).ToString();

            var estTotal4 = MainWindow.Controller.GetEstimations(departmentName, 3).Min();
            uiValue4.Text = Math.Round(estTotal4, 3).ToString();
            uiLevel4.Text = GetLevelByValue(estTotal4).ToString();

            uiValue5.Text = Math.Round(MainWindow.Controller.GetEstimation(departmentName), 3).ToString();
            uiLevel5.Text = GetLevelByValue(MainWindow.Controller.GetEstimation(departmentName)).ToString();
        }

        private double[] DivideArray(double[] array, double divide)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Math.Round(array[i] / divide, 2);
            }
            return array;
        }

        private int GetLevelByValue(double value)
        {
            if (value >= 0.85)
                return 5;
            else if (value >= 0.7)
                return 4;
            else if (value >= 0.5)
                return 3;
            else if (value >= 0.25)
                return 2;
            else if (value > 0)
                return 1;
            else return 0;
        }
    }
}
