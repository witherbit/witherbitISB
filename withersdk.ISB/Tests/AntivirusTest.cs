using System;
using System.Collections.Generic;
using System.Text;

namespace withersdk.ISB.Tests
{
    public class AntivirusTest : ITest
    {
        public string Name => "Обеспечение информационной безопасности средствами антивирусной защиты";
        public QuestContainer this[int index] { get => Questions[index]; }

        public List<QuestContainer> Questions { get; set; }

        public int Count => Questions.Count;

        public int Max => 12;

        public AntivirusTest()
        {
            Questions = new List<QuestContainer>();
            Build();
        }

        private void Build()
        {
            Add("Применяются ли на всех автоматизированных рабочих местах организации, если иное не предусмотрено технологическим процессом, средства антивирусной защиты?");
            Add("Определены ли, выполняются ли, регистрируются ли и контролируются ли в организации процедуры установки и регулярного обновления средств антивирусной защиты (версий и баз данных) на автоматизированных рабочих местах?");
            Add("Организовано ли функционирование постоянной антивирусной защиты в автоматическом режиме и автоматический режим установки обновлений антивирусного программного обеспечения и его баз данных?");
            Add("Проводится ли антивирусная проверка съемных носителей информации перед их подключением к средствам вычислительной техники, задействованным в рамках осуществления технологических процессов, на специально выделенном автономном средстве вычислительной техники?");
            Add("Разработаны ли и введены ли в действие инструкции и рекомендации по антивирусной защите, учитывающие особенности технологических процессов?");
            Add("Организована ли в организации антивирусная фильтрация всего трафика электронного почтового обмена?");
            Add("Организована ли в организации эшелонированная централизованная система антивирусной защиты, предусматривающая использование средств антивирусной защиты различных производителей на: - рабочих станциях; - серверном оборудовании, в том числе серверах электронной почты; - технических средствах межсетевого экранирования?");
            Add("Определены ли, выполняются ли, регистрируются ли и контролируются ли процедуры предварительной проверки устанавливаемого или изменяемого программного обеспечения на отсутствие вирусов?");
            Add("Выполняется ли после установки или изменения программного обеспечения антивирусная проверка?");
            Add("Определены ли, выполняются ли, регистрируются ли и контролируются ли процедуры, выполняемые в случае обнаружения компьютерных вирусов, в которых, в частности, необходимо зафиксировать: - необходимые меры по отражению и устранению последствий вирусной атаки; - порядок официального информирования руководства; - порядок приостановления при необходимости работы (на период устранения последствий вирусной атаки)?");
            Add("Определены ли, выполняются ли и регистрируются ли процедуры контроля за отключением и обновлением антивирусных средств на всех технических средствах?");
            Add("Возложена ли обязанность по выполнению предписанных мер антивирусной защиты на каждого работника организации, имеющего доступ к ЭВМ, а ответственность за выполнение требований по антивирусной защите - на руководителей функциональных подразделений организации?");
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
