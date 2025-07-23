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
    internal class InputValidator
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
        public static string[] ReadNames(char separator)
        {
            string names;
            string[] personsNames = null;
            bool valide = false;
            while (!valide)
            {
                Console.WriteLine("\n\t\tEnter the names of the persons in the trip  ");
                Console.Write("\n\t\t->");
                names = Console.ReadLine();
                personsNames = names.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                valide = true;
                foreach (string name in personsNames)
                {
                    string trimedName = name.Trim();

                    if (!trimedName.All(char.IsLetter))
                    {
                        Console.WriteLine("only letter accepted");
                        valide = false;
                        break;

                    }
                }

            }
            return personsNames;
        }
        public static Dictionary<string, Person> InitializePersons()
        {
            string[] personsNames = ReadNames(' ');

            Dictionary<string, Person> NamesPersonsDict = new Dictionary<string, Person>();
            // fill the dictionary 

            foreach (string person in personsNames)
            {
                Person personObj = new Person(person.Trim());
                NamesPersonsDict.Add(person, personObj);
            }
            return NamesPersonsDict;
        }
        public static void ReadDispence(Dictionary<string, Person> NamesPersonsDict)
        {
            bool again = true;
            bool subAgain = true;
            TripServices tripService = new();
            while (again)
            {
                Console.Write("\t\tEnter a name of the person who spent \n\t\t->");
                string name = Console.ReadLine();
                if (!NamesPersonsDict.Keys.Contains(name))
                {
                    Console.WriteLine($"\n\t\tthe {name} person is  not found in the groupe ");
                    continue;
                }
                while (subAgain)
                {
                    Console.Write("\t\t enter the coast -> ");
                    try
                    {
                        double coast = double.Parse(Console.ReadLine());
                        tripService.spent(NamesPersonsDict[name],coast);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\t\t enter a real money coast ");
                        continue;
                    }

                }
                Console.WriteLine("\t\tyou want to add an other spent ? (y/n)");
                string againBis = Console.ReadLine();
                if (againBis == "n") { again = false; }
            }
        }

       
    }
}
