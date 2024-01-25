using System;
using System.Collections.Generic;
using System.Text;

namespace withersdk.ISB
{
    public static class ISBUtils
    {
        public static double[] ReadString(this string str, char separator)
        {
            List<double> d = new List<double>();
            var spt = str.Split(separator);
            foreach (var s in spt)
            {
                d.Add(double.Parse(s, System.Globalization.CultureInfo.InvariantCulture));
            }
            return d.ToArray();
        }

        public static double CalculateSum(this double[] value, int up, int down = 0)
        {
            double sum = 0;
            while (down < up)
            {
                sum += value[down];
                down++;
            }
            return sum;
        }

        public static double CalculateSum(this double[] value, int down = 0)
        {
            double sum = 0;
            while (down < value.Length)
            {
                sum += value[down];
                down++;
            }
            return sum;
        }
        public static double CalculateSum(this double[] value, double[] multiplyValue, int down = 0)
        {
            double sum = 0;
            while (down < value.Length)
            {
                sum += value[down] * multiplyValue[down];
                down++;
            }
            return sum;
        }

        public static double CalculateSum(this double value, int up, int down = 0)
        {
            double sum = 0;
            while (down < up)
            {
                sum += value;
                down++;
            }
            return sum;
        }
    }
}
