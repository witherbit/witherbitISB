using System;
using System.Collections.Generic;
using System.Text;

namespace withersdk.ISB.Tests
{
    internal class RemoteWorkTest : ITest
    {
        public string Name => "Обеспечение информационной безопасности при дистанционном режиме работы";
        public QuestContainer this[int index] { get => Questions[index]; }

        public List<QuestContainer> Questions { get; set; }

        public int Count => Questions.Count;

        public int Max => 13;

        public RemoteWorkTest()
        {
            Questions = new List<QuestContainer>();
            Build();
        }

        private void Build()
        {
            Add("Определен ли документально перечень работ, которые могут проводиться в дистанционном режиме работы?");
            Add("Проведен ли инструктаж работников осуществляющих взаимодействие с ЭВМ в дистанционном режиме работы?");
            Add("Определен ли перечень технических средств, в том числе портативных вычислительных средств, которые будут предоставлены сотрудникам во время дистанционного режима работы?");
            Add("Определен ли перечень информации и информационных ресурсов, к которым должен предоставляться доступ?");
            Add("Определены ли права и привилегии для сотрудников, во время дистанционного режима работы?");
            Add("Определен ли документально перечень мероприятий по исключению возможности эксплуатации задействованных средств вычислительной техники на время дистанционного режима работы?");
            Add("Составлен ли список допустимых MAC адресов для идентификации средств вычислительной техники при взаимодействии с информационными ресурсами на время дистанционного режима?");
            Add("Реализована ли двухфакторная аутентификация работников при использовании средств вычислительной техники на время дистанционного режима?");
            Add("Определен ли документально перечень информации и информационных ресурсов, доступ к которым осуществляется через канал VPN?");
            Add("Обеспечено ли резервирование необходимого объема памяти для записи данных?");
            Add("Определен ли документально перечень средств антивирусной защиты, необходимых для использования на средствах вычислительной техники во время дистанционного режима работы?");
            Add("Реализована ли защита от установки сотрудниками стороннего программного обеспечения на удаленные средства вычислительной техники?");
            Add("Определено ли неактивное время сотрудника, по истечении которого будет выполнено блокирование сеанса?");
        }

        public void Add(string quest, double estimation = 0, int significanceCoefficient = 10)
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
