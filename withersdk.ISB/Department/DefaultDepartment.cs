using System;
using System.Collections.Generic;
using System.Text;
using withersdk.ISB.Tests;

namespace withersdk.ISB.Department
{
    [Serializable]
    public class DefaultDepartment : IDepartment
    {
        public DefaultTest this[int index] => Tests[index];

        public string Name { get; set; }

        public List<DefaultTest> Tests { get; set; }

        public int Count => Tests.Count;

        public DefaultDepartment(string name)
        {
            Tests = new List<DefaultTest>();
            Name = name;
        }

        public void Add(DefaultTest test)
        {
            Tests.Add(test);
        }

        public void Clear()
        {
            Tests.Clear();
        }

        public void Insert(int index, DefaultTest test)
        {
            Tests.Insert(index, test);
        }

        public void Remove(DefaultTest test)
        {
            Tests.Remove(test);
        }

        public void RemoveAt(int index)
        {
            Tests.RemoveAt(index);
        }

        public int IndexOf(DefaultTest test)
        {
            return Tests.IndexOf(test);
        }
    }
}
