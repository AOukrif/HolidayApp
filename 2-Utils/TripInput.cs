using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Holidays._0_Models;
using RandomChoser;

namespace Holidays._2_Utils
{
    internal class TripInput
    {
        public static Trip InitilizeTrip()
        {
            Console.Write($" \t\t Welcom to the holidays App \n\n\t\t Let's define your trip \n");
            string city = ReadCity();
            Console.Write($"\n\t\t {city} is a nice city to visite\n\t\t");
            int numberOfPerson = ReadnumberOfPerson();
            Console.Write($"\n\t\t{city} for {numberOfPerson} persons\n\t\t");
            DateOnly tripDay=ReadTripDate();
            double budget = ReadBudget();
            Dictionary<string, Person> persons = PersonInput.InitializePersons(numberOfPerson);
            Trip trip = new Trip(city, numberOfPerson,tripDay, budget, persons);
            Console.WriteLine($"\n\t\t the trip to {city} is well created");
            return trip;

        }

        public static string ReadCity()
        {
            string input;
            while (true) 
            {
                Console.Write($"\n\t\t Enter the city for your trip \n\t\t-> ");
                input= Console.ReadLine()?.Trim();
                if (!input.All(char.IsLetter) || string.IsNullOrEmpty(input) )
                {
                    Console.WriteLine("\n\t\tthe city name must contain letters only ");
                    continue;

                }
                break;
            }
            return input;
        }
        public static int ReadnumberOfPerson() 
        {
            int input=0;
            while (true)
            {
                Console.Write("How many person would you be ? \n\t\t ->");
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    continue;
                }
                if(input <= 0)
                {
                    Console.WriteLine("\n\t\tnumber of person must be positive");
                    continue;
                }
                break;
            }

            return input;
        }
        public static DateOnly ReadTripDate()
        {
            DateOnly input;
            while (true)
            {
                Console.Write("\n\t\t enter the date in format yyyy-mm-dd\n\t\t -> ");
                try
                {
                    input = DateOnly.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                if (input < DateOnly.FromDateTime(DateTime.Today))
                {
                    Console.WriteLine("\n\t\tDate already passed\n\t\t ");
                    continue;
                }
                break;
            }
            
            return input; 
        }
        public static double ReadBudget()
        {
            double input=0;
            while (true)
            {
                Console.Write("\n\t\twhat is you budget ?\n\t\t ->  ");
                input= double.Parse(Console.ReadLine());
                if (input < 0)
                {
                    Console.WriteLine("\n\t\tbudget must be positive\n\t\t");
                    continue;
                }
                break;
            }
            return input; 
        }
    }
}
