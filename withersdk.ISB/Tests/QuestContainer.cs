using System;
using System.Collections.Generic;
using System.Text;

namespace withersdk.ISB.Tests
{
    [Serializable]
    public class QuestContainer
    {
        public string Quest { get; set; }
        public double Estimation { get; set; }
        public int SignificanceCoefficient { get; set; }
    }
}
