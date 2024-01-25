using System;
using System.Collections.Generic;
using System.Text;
using withersdk.ISB.Tests;

namespace withersdk.ISB.Department
{
    public interface IDepartment
    {
        string Name { get; }
        List<ITest> Tests { get; }
        ITest this[int index] { get; }
        int Count { get; }
        void Add(ITest test);
        void Remove(ITest test);
        void RemoveAt(int index);
        void Clear();
        void Insert(int index, ITest test);
        int IndexOf(ITest test);
    }
}
