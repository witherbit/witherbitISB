using System;
using System.Collections.Generic;
using System.Text;
using withersdk.ISB.Tests;

namespace withersdk.ISB.Department
{
    public class DefaultDepartment : IDepartment
    {
        public ITest this[int index] => Tests[index];

        public string Name { get; set; }

        public List<ITest> Tests { get; set; }

        public int Count => Tests.Count;

        public DefaultDepartment(string name)
        {
            Tests = new List<ITest>();
            Name = name;
        }

        public void Add(ITest test)
        {
            Tests.Add(test);
        }

        public void Clear()
        {
            Tests.Clear();
        }

        public void Insert(int index, ITest test)
        {
            Tests.Insert(index, test);
        }

        public void Remove(ITest test)
        {
            Tests.Remove(test);
        }

        public void RemoveAt(int index)
        {
            Tests.RemoveAt(index);
        }

        public int IndexOf(ITest test)
        {
            return Tests.IndexOf(test);
        }
    }
}
