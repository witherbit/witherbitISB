using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using withersdk.ISB.Tests;

namespace withersdk.ISB.Tables
{
    public class EstimationTable
    {
        public double[,] Table { get; set; }
        public Tester Tester { get; set; }
        public ITest Test { get; set; }
        public EstimationTable(EstimationController controller, Tester tester, int testIndex, string departmentName)
        {
            Tester = tester;
            var itm = Tester.Departments.FirstOrDefault(x => x.Name == departmentName)[testIndex];
            Table = new double[5, itm.Count];
            var scTable = new SignificanceCoefficientTable(controller, testIndex, departmentName);  //таблица коэффициентов значимости
            var est = new List<double>();   //частные показатель
            var sc = new List<double>();    //частные баллы значимости
            var asc = controller.GetSignificanceCoefficients(departmentName)[testIndex];    //общие коэфф. значимости
            var tests = controller.GetTestsByTester(departmentName, tester);
            var d_est = tests[testIndex].CalculateEstimation(asc);  //оценка
            var d_sc = scTable.GetRow(controller.Testers.IndexOf(tester));  // частные коэфф. значимости
            Test = tests[testIndex];
            foreach ( var question in tests[testIndex].Questions )
            {
                est.Add(question.Estimation);
                sc.Add(question.SignificanceCoefficient);
            }
            InsertRowToArray(0, est.ToArray()); //частные показатель
            InsertRowToArray(1, sc.ToArray());  //частные баллы значимости
            InsertRowToArray(2, d_sc);          //частные коэфф. значимости
            InsertRowToArray(3, asc);           //общие коэфф. значимости
            InsertRowToArray(4, new double[] { d_est });    //оценка
        }
        private void InsertRowToArray(int row, double[] values)
        {
            for (int j = 0; j < values.Length; j++)
            {
                Table[row, j] = values[j];
            }
        }
        public double[] GetColumn(int columnIndex, int endTrim = 0)
        {
            var result = new List<double>();
            for (int i = 0; i < Table.GetLength(0) - endTrim; i++)
                result.Add(Table[i, columnIndex]);
            return result.ToArray();
        }
        public double[] GetRow(int rowindex, int endTrim = 0)
        {
            var result = new List<double>();
            for (int j = 0; j < Table.GetLength(1) - endTrim; j++)
                result.Add(Table[rowindex, j]);
            return result.ToArray();
        }
    }
}
