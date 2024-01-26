using System;
using System.Collections.Generic;
using System.Text;

namespace withersdk.ISB.Tests
{
    public class InformationInfrastructureTest : ITest
    {
        public string Name => "Обеспечение информационной безопасности информационной инфраструктуры";
        public QuestContainer this[int index] { get => Questions[index]; }

        public List<QuestContainer> Questions { get; set; }

        public int Count => Questions.Count;

        public int Max => 10;

        public InformationInfrastructureTest()
        {
            Questions = new List<QuestContainer>();
            Build();
        }

        private void Build()
        {
            Add("Определен ли документально список лиц, у которых есть полномочия на действия с информационной инфраструктурой?");
            Add("Определен ли документально перечень мероприятий по резервированию информационной инфраструктуры?");
            Add("Определен ли документально перечень мер по восстановлению отказавших технических мер обеспечения ИБ информационной инфраструктуры?");
            Add("Определен ли список сотрудников, ответственных за восстановление отказавших технических мер по обеспечению ИБ информационной инфраструктуры?");
            Add("Определен ли документально перечень мер по контролю фактического размещения технических мер по обеспечению ИБ информационной инфраструктуры?");
            Add("Определен ли документально перечень мероприятий по организации и контролю размещения, хранения и обновления ПО информационной инфраструктуры?");
            Add("Определен ли документально перечень мероприятий по контролю состава и целостности ПО информационной инфраструктуры?");
            Add("Определен ли документально перечень мероприятий по фиксации, регистрации и записи событий защиты информации, связанных с результатами контроля целостности и защищенности информационной инфраструктуры?");
            Add("Определен ли документально перечень фактических параметров настроек технических мер защиты информации и компонентов информационной инфраструктуры, предназначенных для размещения технических мер обеспечения ИБ?");
            Add("Осуществляется ли фиксация, регистрация и запись операций по изменению параметров настроек технических мер обеспечения ИБ и информационной инфраструктуры, предназначенных для размещения технических мер обеспечения ИБ?");
        }

        public void Add(string quest, double estimation = 0.5, int significanceCoefficient = 10)
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
