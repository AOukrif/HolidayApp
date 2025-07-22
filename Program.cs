// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using Holidays._1__Services;
using Holidays._2_Utils;
using RandomChoser;

class Program
{
    public static void Main()
    {
        int choice = InputValidator.UserChoice();

        Dictionary<string, Person> NamesPersonsDict = InputValidator.Initialize();

        switch (choice)
        {
            case 1:
                bool again = true;
                bool subAgain = true;
                while (again)
                {
                    Random random = new Random();
                    int randomIndex = random.Next(0,NamesPersonsDict.Count);
                    Console.WriteLine($"\n\t\tThe chosen is {NamesPersonsDict.Keys.ElementAt(randomIndex)}");
                    while (subAgain)
                    {
                        Console.Write($"\t\tDo you want to choose again ? (y/n) \n\t\t->  ");
                        string againInput = Console.ReadLine().ToLower();
                        if (againInput == "y" || againInput == "n")
                        {
                            if (againInput == "y") { break; subAgain = false; }
                            else { again = false; subAgain = false; }
                        }
                        else
                        {
                            Console.Write("\n\t\tplease chose only y/n \n");
                            continue;
                        }
                    }
                    continue;
                }
                break;

            case 2:
                InputValidator.ReadDispence(NamesPersonsDict);
                TripServices tripServices = new TripServices();
                double averageSpent = tripServices.getAverageSpent(NamesPersonsDict);

                // defining the sender and the receiver of money at the end of the trip 
                List<Person> sendersList = new List<Person>(); 
                List<Person> receiverList = new List<Person>();
                foreach (Person person in NamesPersonsDict.Values)
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