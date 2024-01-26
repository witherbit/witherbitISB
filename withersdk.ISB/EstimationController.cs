using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using withersdk.ISB.Tables;
using withersdk.ISB.Tests;

namespace withersdk.ISB
{
    public sealed class EstimationController
    {
        public List<Tester> Testers { get; }
        public EstimationController() 
        {
            Testers = new List<Tester>();
        }

        public List<SignificanceCoefficientTable> GetSignificanceCoefficientTables(string departmentName)
        {
            var result = new List<SignificanceCoefficientTable>();
            var testsCount = GetTestsCount(departmentName);
            for (int i = 0; i < testsCount; i++)
            {
                result.Add(new SignificanceCoefficientTable(this, i, departmentName));
            }
            return result;
        }

        public List<EstimationTable> GetEstimationTables(string departmentName)
        {
            var result = new List<EstimationTable>();
            foreach (var tester in Testers)
            {
                var testsCount = GetTestsCount(departmentName);
                for (int i = 0; i < testsCount; i++)
                {
                    result.Add(new EstimationTable(this, tester, i, departmentName));
                }
            }
            return result;
        }

        public List<double[]> GetSignificanceCoefficients(string departmentName)
        {
            var result = new List<double[]>();
            var tables = GetSignificanceCoefficientTables(departmentName);
            foreach (var table in tables)
            {
                result.Add(table.GetRow(table.Table.GetLength(0) - 1));
            }
            return result;
        }

        public double[] GetEstimations(string departmentName, int testIndex)
        {
            List<double> result = new List<double>();
            var significanceCoefficients = GetSignificanceCoefficients(departmentName);
            foreach (var tester in Testers)
            {
                foreach (var department in tester.Departments)
                {
                    if (department.Name == departmentName)
                    {
                        result.Add(department[testIndex].CalculateEstimation(significanceCoefficients[testIndex]));
                        break;
                    }
                }
            }
            return result.ToArray();
        }

        public double GetEstimation(string departmentName)
        {
            double result = -1;
            var temp = new List<double>();
            var testsCount = GetTestsCount(departmentName);
            for (int i = 0; i < testsCount; i++)
            {
                temp.Add(GetEstimations(departmentName, i).Min());
            }
            if(temp.Count > 0)
                result = temp.Min();
            return result;
        }

        public int GetTestsCount(string departmentName)
        {
            int result = 0;
            foreach (var tester in Testers)
            {
                foreach (var department in tester.Departments)
                {
                    if (department.Name == departmentName)
                    {
                        result = department.Count;
                        break;
                    }
                }
                if (result > 0) break;
            }
            return result;
        }

        public ITest[] GetTests(string departmentName)
        {
            ITest[] result = null;
            foreach (var tester in Testers)
            {
                foreach (var department in tester.Departments)
                {
                    if (department.Name == departmentName)
                    {
                        return department.Tests.ToArray();
                    }
                }
            }
            return result;
        }
        public ITest[] GetTestsByTester(string departmentName, Tester tester)
        {
            ITest[] result = null;
            foreach (var item in Testers)
            {
                if(tester == item)
                foreach (var department in item.Departments)
                {
                    if (department.Name == departmentName)
                    {
                        return department.Tests.ToArray();
                    }
                }
            }
            return result;
        }
        public int[] GetTestsIndex(string departmentName)
        {
            var result = new List<int>();
            foreach (var tester in Testers)
            {
                foreach (var department in tester.Departments)
                {
                    if (department.Name == departmentName)
                    {
                        for (int i = 0; i < department.Tests.Count; i++)
                        {
                            result.Add(i);
                        }
                    }
                }
            }
            return result.ToArray();
        }

        public Tester[] GetTesters(string departmentName)
        {
            var result = new List<Tester>();
            foreach (var tester in Testers)
            {
                foreach (var department in tester.Departments)
                {
                    if (department.Name == departmentName)
                    {
                        result.Add(tester);
                        break;
                    }
                }
            }
            return result.ToArray();
        }
        public int[] GetTestersIndex(string departmentName)
        {
            var result = new List<int>();
            foreach (var tester in Testers)
            {
                foreach (var department in tester.Departments)
                {
                    if (department.Name == departmentName)
                    {
                        result.Add(Testers.IndexOf(tester));
                        break;
                    }
                }
            }
            return result.ToArray();
        }

        public string[] GetDepartments()
        {
            List<string> result = new List<string>();
            foreach(var tester in Testers)
            {
                foreach(var dep in tester.Departments)
                {
                    if(!result.Contains(dep.Name))
                        result.Add(dep.Name);
                }
            }
            return result.ToArray();
        }
    }
}
