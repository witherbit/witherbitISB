using System;
using System.Collections.Generic;
using System.Text;

namespace withersdk.ISB.Tests
{
    public interface ITest
    {
        string Name { get; }
        List<QuestContainer> Questions { get; }
        int Count { get; }
        int Max {  get; }
        QuestContainer this[int index] { get; }
        void Add(string quest, double estimation, int significanceCoefficient);
        void Add(QuestContainer item);
        void Remove(QuestContainer item);
        void RemoveAt(int index);
        void Clear();
        void Insert(int index, QuestContainer item);

        double[] CalculateSignificanceCoefficient();

        double CalculateEstimation(double[] significanceCoefficients);
    }
}
