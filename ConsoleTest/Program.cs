using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using withersdk.ISB;
using withersdk.ISB.Department;
using withersdk.ISB.Tables;
using withersdk.ISB.Tests;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EstimationController controller = new EstimationController();
            
            controller.Testers.Add(Tester.Build("1", "org1"));
            controller.Testers.Add(Tester.Build("2", "org1"));

            EnterSignificanceCoefficient(controller.Testers[0], "5 8 6 7 9 9 6 8 7 8 8 7 5", "org1");
            EnterSignificanceCoefficient(controller.Testers[1], "9 9 6 8 8 7 7 9 6 8 7 6 6", "org1");

            EnterSignificanceCoefficient(controller.Testers[0], "9 7 8 6 8 9 6 5 4 7 8 8", "org1", 1);
            EnterSignificanceCoefficient(controller.Testers[1], "9 8 9 6 7 8 6 6 5 9 6 7", "org1", 1);

            EnterSignificanceCoefficient(controller.Testers[0], "6 7 6 9 8 5 7 7 7 7 6 6 6", "org1", 2);
            EnterSignificanceCoefficient(controller.Testers[1], "9 6 9 5 7 7 6 9 5 8 4 6 7", "org1", 2);

            EnterSignificanceCoefficient(controller.Testers[0], "7 6 9 6 7 9 8 8 9 9", "org1", 3);
            EnterSignificanceCoefficient(controller.Testers[1], "8 7 8 7 6 8 9 8 9 8", "org1", 3);

            EnterEstimation(controller.Testers[0], "1 1 1 0.5 1 0.75 1 1 1 1 0.25 1 1", "org1");
            EnterEstimation(controller.Testers[1], "1 0.5 0.75 0.25 1 1 1 1 0.5 1 1 1 1", "org1");

            EnterEstimation(controller.Testers[0], "1 1 0.25 1 0.5 1 0.75 1 1 0.5 0.75 1", "org1", 1);
            EnterEstimation(controller.Testers[1], "1 1 0.5 1 1 1 0.25 0.5 1 1 1 0.5", "org1", 1);

            EnterEstimation(controller.Testers[0], "1 1 1 0 1 0.75 1 0.75 1 0.5 1 0.5 1", "org1", 2);
            EnterEstimation(controller.Testers[1], "1 1 0.5 1 1 0.5 1 1 1 0.25 1 1 1", "org1", 2);

            EnterEstimation(controller.Testers[0], "1 1 1 0.5 1 0.25 0.5 1 1 1", "org1", 3);
            EnterEstimation(controller.Testers[1], "1 1 0.5 1 1 0.75 1 0.5 1 1", "org1", 3);

            WriteTableSC(controller, 0, "org1");
            WriteTableSC(controller, 1, "org1");
            WriteTableSC(controller, 2, "org1");
            WriteTableSC(controller, 3, "org1");

            WriteTableE(controller, 0, 0, "org1");
            WriteTableE(controller, 0, 1, "org1");
            WriteTableE(controller, 0, 2, "org1");
            WriteTableE(controller, 0, 3, "org1");

            WriteTableE(controller, 1, 0, "org1");
            WriteTableE(controller, 1, 1, "org1");
            WriteTableE(controller, 1, 2, "org1");
            WriteTableE(controller, 1, 3, "org1");

            Console.WriteLine($"Total score: {Math.Round(controller.GetEstimation("org1"), 3)}");

            Console.ReadLine();
        }

        static void EnterSignificanceCoefficient(Tester tester, string value, string departmentName, int testIndex = 0)
        {
            var numbers = value.ReadString(' ');
            for(int i = 0; i < tester[departmentName][testIndex].Max; i++)
            {
                tester[departmentName][testIndex].Questions[i].SignificanceCoefficient = (int)numbers[i];
            }
        }

        static void EnterEstimation(Tester tester, string value, string departmentName, int testIndex = 0)
        {
            var numbers = value.ReadString(' ');
            for (int i = 0; i < tester[departmentName][testIndex].Max; i++)
            {
                tester[departmentName][testIndex].Questions[i].Estimation = numbers[i];
            }
        }

        static void WriteTableSC(EstimationController controller, int testIndex, string departmentName)
        {
            Console.WriteLine($"{controller.GetTests(departmentName)[testIndex].Name}:");
            var table1 = new SignificanceCoefficientTable(controller, testIndex, departmentName);
            for (int i = 0; i < table1.Table.GetLength(0); i++)
            {
                if(i != table1.Table.GetLength(0) - 1)
                {
                    Console.Write($"Tstr {i + 1}\t| ");
                }
                else
                    Console.Write("General\t| ");
                for (int j = 0; j < table1.Table.GetLength(1); j++)
                {
                    Console.Write($"{Math.Round(table1.Table[i, j], 3)} \t");
                }
                Console.WriteLine();
            }
            //Console.WriteLine();
        }

        static void WriteTableE(EstimationController controller, int testerIndex, int testIndex, string departmentName)
        {
            Console.WriteLine($"Tester {controller.Testers[testerIndex].Name} at {controller.GetTests(departmentName)[testIndex].Name}");
            var table2 = new EstimationTable(controller, controller.Testers[testerIndex], testIndex, departmentName);
            for (int i = 0; i < table2.Table.GetLength(0); i++)
            {
                if(i == 0)
                {
                    Console.Write("Estimation\t| ");
                }
                else if (i == 1)
                {
                    Console.Write("Coefficient\t| ");
                }
                else if (i == 2)
                {
                    Console.Write("d_Coefficient\t| ");
                }
                else if (i == 3)
                {
                    Console.Write("g_Coefficient\t| ");
                }
                else if (i == 4)
                {
                    Console.Write("d_Estimation\t| ");
                }
                for (int j = 0; j < table2.Table.GetLength(1); j++)
                {
                    Console.Write($"{Math.Round(table2.Table[i, j], 3)} \t");
                    if (i == table2.Table.GetLength(0) - 1)
                    {
                        break;
                    }
                }
                Console.WriteLine();
            }
            //Console.WriteLine();
        }
    }
}
