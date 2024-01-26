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
            
            controller.Testers.Add(Tester.DeserializeFromFile(@"C:\Witherbit\Testers\Artem_aa270182_0572_4f94_bbe6_10d1d6059f40.dat"));
            controller.Testers.Add(Tester.DeserializeFromFile(@"C:\Witherbit\Testers\TestW_db416f1a_83ec_41d5_8533_6603117f7289.dat"));

            string dep = controller.GetDepartments()[0];

            WriteTableSC(controller, 0, dep);
            WriteTableSC(controller, 1, dep);
            WriteTableSC(controller, 2, dep);
            WriteTableSC(controller, 3, dep);

            WriteTableE(controller, 0, 0, dep);
            WriteTableE(controller, 0, 1, dep);
            WriteTableE(controller, 0, 2, dep);
            WriteTableE(controller, 0, 3, dep);

            WriteTableE(controller, 1, 0, dep);
            WriteTableE(controller, 1, 1, dep);
            WriteTableE(controller, 1, 2, dep);
            WriteTableE(controller, 1, 3, dep);

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
