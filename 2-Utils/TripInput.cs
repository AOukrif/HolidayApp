using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Holidays._0_Models;

namespace Holidays._2_Utils
{
    internal class TripInput
    {
        public static Trip InitilizeTrip()
        {
            int numberOfPerson;
            string city;
            DateOnly startOfTrip;

            while (true)
            {

                Console.Write($" \t\t Welcom to the holidays App \n\t\t Let's define your trip \n");
                city = ReadCity();




                

                Console.Write($"{city} is a nice city to visite , how many persons would you be ? \n\t\t ->");
                numberOfPerson = int.Parse(Console.ReadLine());
                if (numberOfPerson <= 0)
                {
                    Console.WriteLine("the number of person must be positive");
                    continue;
                }
                break;



            }
            Trip trip = new Trip(city, numberOfPerson);
            return trip;

        }

        public static string ReadCity()
        {
            string input;
            while (true) 
            {
                Console.Write($"\t\t Enter the city for your trip \n\t\t->");
                input= Console.ReadLine().Trim();
                if (!input.All(char.IsLetter) || string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("the city name must contain letters only ");
                    continue;

                }
                break;
            }
            return input;
        }
    }
}
