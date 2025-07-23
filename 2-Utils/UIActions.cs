using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Holidays._0_Models;
using Holidays._1__Services;
using RandomChoser;

namespace Holidays._2_Utils
{
    internal class UIActions
    {
        public static int UserChoice()
        {
            int choice = 0;
            List<int> goodChoices = Enumerable.Range(1, 2).ToList();
            while (true)
            {
                Console.WriteLine("\n" +
                    "\tyou want to : \n\n " +
                "\t\t1 - Choose a random person \n\r " +
                "\t\t2 - Calculate the total spent with the tricount ");
                try
                {
                    Console.Write($"\n\t\t->");
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine($"\n\tplease enter a number from the list");
                    continue;
                }
                if (goodChoices.Contains(choice))
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\n\tPlease select only from the available options {string.Join(",", goodChoices)} ");
                }
            }
            return choice;
        }
        
       
        

       
    }
}
