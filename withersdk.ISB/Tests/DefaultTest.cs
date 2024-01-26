using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace withersdk.ISB.Tests
{
    [Serializable]
    public class DefaultTest : ITest
    {
        public string Name { get; set; }
        [JsonIgnore]
        public QuestContainer this[int index] { get => Questions[index]; }

        public List<QuestContainer> Questions { get; set; }

        public int Count => Questions.Count;
        [JsonIgnore]
        public int Max => Questions.Count;

        public DefaultTest(string name, string[] questions)
        {
            Name = name;
            Questions = new List<QuestContainer>();
            foreach (var quest in questions)
            {
                Add(quest);
            }
        }

        public void Add(string quest, double estimation = 0.5, int significanceCoefficient = 5)
        {
            Questions.Add(new QuestContainer
            {
                Quest = quest,
                Estimation = estimation,
                SignificanceCoefficient = significanceCoefficient
            });
        }
        public void Add(QuestContainer item)
        {
            Questions.Add(item);
        }

        public void Clear()
        {
            Questions.Clear();
        }

        public void Insert(int index, QuestContainer item)
        {
            Questions.Insert(index, item);
        }
        public void Remove(QuestContainer item)
        {
            Questions.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Questions.RemoveAt(index);
        }

        public double[] CalculateSignificanceCoefficient()
        {
            List<double> result = new List<double>();
            List<double> scores = new List<double>();
            foreach (var quest in Questions)
            {
                scores.Add(quest.SignificanceCoefficient);
            }
            foreach (var quest in Questions)
            {
                result.Add(quest.SignificanceCoefficient / scores.ToArray().CalculateSum());
            }
            return result.ToArray();
        }

        public double CalculateEstimation(double[] significanceCoefficients)
        {
            var estimations = new List<double>();
            foreach (var quest in Questions)
            {
                estimations.Add(quest.Estimation);
            }
            return significanceCoefficients.CalculateSum(estimations.ToArray());
        }
    }
}
