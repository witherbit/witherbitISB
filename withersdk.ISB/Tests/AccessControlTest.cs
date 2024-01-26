using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace withersdk.ISB.Tests
{
    public class AccessControlTest : ITest
    {
        public string Name => "Обеспечение информационной безопасности при управлении доступом и регистрации";
        public QuestContainer this[int index] { get => Questions[index]; }

        public List<QuestContainer> Questions { get; set; }

        public int Count => Questions.Count;

        public int Max => 13;

        public AccessControlTest()
        {
            Questions = new List<QuestContainer>();
            Build();
        }

        private void Build()
        {
            Add("Определен ли документально перечень информационных активов (их типов) объекта и зафиксированы ли документально права доступа работников объекта к данным активам?");
            Add("Определен ли документально перечень защитных мер от НСД?");
            Add("Определены ли, выполняются ли, регистрируются ли и контролируются ли правила и процедуры идентификации, аутентификации, авторизации субъектов доступа, в том числе внешних субъектов доступа, которые не являются работниками организации?");
            Add("Определены ли, выполняются ли, регистрируются ли и контролируются ли правила и процедуры выявления и блокирования неуспешных попыток доступа?");
            Add("Определены ли, выполняются ли, регистрируются ли и контролируются ли правила и процедуры выявления и блокирования несанкционированного перемещения (копирования) информации, в том числе баз данных, файловых ресурсов, виртуальных машин?");
            Add("Используются ли для проведения процедур мониторинга ИБ и анализа данных о действиях и операциях специализированные программные и (или) технические средства?");
            Add("Определены ли, выполняются ли, регистрируются ли и контролируются ли правила и процедуры блокирования сеанса доступа после установленного времени бездействия или по запросу субъекта доступа, требующего выполнения процедур повторной аутентификации и авторизации для продолжения работы?");
            Add("Определены ли действия и операции, подлежащие регистрации?");
            Add("Определены ли сроки хранения действий и операций, подлежащих регистрации?");
            Add("Обеспечено ли резервирование необходимого объема памяти для записи данных?");
            Add("Определен ли, выполняется ли, регистрируется ли и контролируется ли порядок доступа к объектам среды информационных активов, в том числе в помещения, в которых размещаются объекты среды информационных активов?");
            Add("Определен ли, выполняется ли и контролируется ли в организации порядок использования съемных носителей информации?");
            Add("Предоставляется ли доступ к данным о действиях и операциях только с целью выполнения служебных обязанностей?");
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
