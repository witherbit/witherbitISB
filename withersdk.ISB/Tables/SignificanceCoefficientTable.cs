using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using withersdk.ISB.Tests;

namespace withersdk.ISB.Tables
{
    public class SignificanceCoefficientTable
    {
        public double[,] Table { get; set; }
        public List<Tester> Testers { get; set; }

        public ITest Test { get; set; }
        public SignificanceCoefficientTable(EstimationController controller, int testIndex, string deparmentName)
        {
            Testers = new List<Tester>();
            Table = new double[controller.Testers.Count + 1, controller.Testers[0].Departments.FirstOrDefault(x => x.Name == deparmentName)[testIndex].Max];
            Test = controller.Testers[0].Departments.FirstOrDefault(x => x.Name == deparmentName)[testIndex];
            int row = 0;
            foreach (var tester in controller.Testers)
            {
                foreach (var department in tester.Departments)
                {
                    if (department.Name == deparmentName)
                    {
                        Testers.Add(tester);
                        InsertRowToArray(row++, department[testIndex].CalculateSignificanceCoefficient());
                    }
                }
            }
            var general = new List<double>();
            for (int j = 0; j < Table.GetLength(1); j++)
            {
                var col = GetColumn(j, 1);
                general.Add(col.CalculateSum() / row);
            }
            InsertRowToArray(row, general.ToArray());
        }

        private void InsertRowToArray(int row, double[] values)
        {
            for(int j = 0; j < values.Length; j++)
            {
                Table[row, j] = values[j];
            }
        }
        public double[] GetColumn(int columnIndex, int endTrim = 0)
        {
            var result = new List<double>();
            for(int i = 0; i < Table.GetLength(0) - endTrim; i++)
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
