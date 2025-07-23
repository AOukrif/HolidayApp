// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using Holidays._0_Models;
using Holidays._1__Services;
using Holidays._2_Utils;
using RandomChoser;

class Program
{
    public static void Main()
    {
        Trip trip = TripInput.InitilizeTrip();
        int choice = UIActions.UserChoice();

        TripServices tripService = new TripServices();
        switch (choice)
        {
            case 1:
                Person chosen = tripService.RandomPerson(trip);
                Console.WriteLine($"\n\t\tThe chosen is {chosen.name}");
                
                while (true)
                {
                    Console.Write($"\t\tDo you want to choose again ? (y/n) \n\t\t->  ");
                    string againInput = Console.ReadLine()?.ToLower();
                    if (againInput == "y" || againInput == "n")
                    {
                        if (againInput == "y") {
                            chosen = tripService.RandomPerson(trip);
                            Console.WriteLine($"\n\t\tThe chosen is {chosen.name}");
                            continue;
                        }
                        else { break; }
                    }
                    else
                    {
                        Console.Write("\n\t\tplease chose only y/n \n");
                        continue;
                    }
                }
                break;

            case 2:
                PersonInput.ReadDispence(trip);
                TripServices tripServices = new TripServices();
                double averageSpent = tripServices.getAverageSpent(trip);
                List<Person> sendersList = new List<Person>(); 
                List<Person> receiverList = new List<Person>();
                foreach (Person person in trip.persons.Values)
                {
                    person.diffrenceSpent = person.moneySpent - averageSpent;
                    if (person.diffrenceSpent > 0) { receiverList.Add(person); }
                    if (person.diffrenceSpent < 0)
                    {
                        person.diffrenceSpent = -1 * person.diffrenceSpent;
                        sendersList.Add(person);
                    }
                }
                tripServices.Regulation(sendersList, receiverList);
                break; 
        }
    }
}