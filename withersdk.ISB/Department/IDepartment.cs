using System;
using System.Collections.Generic;
using System.Text;
using withersdk.ISB.Tests;

namespace withersdk.ISB.Department
{
    public interface IDepartment
    {
        string Name { get; }
        List<DefaultTest> Tests { get; }
        DefaultTest this[int index] { get; }
        int Count { get; }
        void Add(DefaultTest test);
        void Remove(DefaultTest test);
        void RemoveAt(int index);
        void Clear();
        void Insert(int index, DefaultTest test);
        int IndexOf(DefaultTest test);
    }
}
