using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Holidays._0_Models;
using Holidays._1__Services;
using RandomChoser;

namespace Holidays._2_Utils
{
    internal class PersonInput
    {
        public static Dictionary<string, Person> InitializePersons(int numbeOfPerson)
        {
            
            string[] personsNames = ReadNames(' ' , numbeOfPerson);

            Dictionary<string, Person> NamesPersonsDict = new Dictionary<string, Person>();
            // fill the dictionary 

            foreach (string person in personsNames)
            {
                Person personObj = new Person(person.Trim());
                NamesPersonsDict.Add(person, personObj);
            }
            
            return NamesPersonsDict;
        }

        public static string[] ReadNames(char separator , int numberOfPerson)
        {
            string names;
            string[] personsNames = new string[numberOfPerson];
            bool valide = false;
            while (!valide)
            {
                Console.WriteLine("\n\t\tEnter the names of the persons in the trip  ");
                Console.Write("\n\t\t->");
                names = Console.ReadLine();
                try
                {
                    personsNames = names.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                }
                catch(Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    continue;
                }
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

        public static void ReadDispence(Trip trip)
        {
            TripServices tripService = new();
            string name = ReadName(tripService, trip);
            ReadCost(tripService, trip, name);
            while (true)
            {
                Console.WriteLine("\t\tyou want to add an other spent ? (y/n) \n\t\t -> ");
                string again = Console.ReadLine()?.ToLower().Trim();
                if(again == "y")
                {
                    name = ReadName(tripService, trip);
                    ReadCost(tripService, trip, name);
                    continue;
                }
                if (again == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("only y or n allowed ");
                    continue;
                }
                
            }
        }

        public static string ReadName(TripServices tripService , Trip trip) 
        {
            string name;
            while (true)
            {
                Console.Write("\t\tEnter a name of the person who spent \n\t\t->");
                name = Console.ReadLine();
                if (!trip.persons.Keys.Contains(name))
                {
                    Console.WriteLine($"\n\t\tthe {name} person is  not found in the groupe ");
                    continue;
                }
                else { break; }
            }
            return name;
        }

        public static void ReadCost(TripServices tripService, Trip trip, string name)
        {
            while (true)
            {
                Console.Write("\t\t enter the coast \n\t\t -> ");
                try
                {
                    double coast = double.Parse(Console.ReadLine());
                    tripService.spent(trip.persons[name], coast, trip);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\t\t enter a real money coast , {e.Message} ");
                    continue;
                }
                break;

            }
                
        }

    }
}
