// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using RandomChoser;

class Program
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
            catch(FormatException e)
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
                Console.Clear ();
                Console.WriteLine($"\n\tPlease select only from the available options {string.Join(",",goodChoices)} ");
            }
        }
        return choice;
    }
    
    public static void Main()
    {
        int choice = UserChoice();
        Dictionary<string, Person> NamesPersonsDict = Person.Initialize();

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
                Person.ReadDispence(NamesPersonsDict);
                double averageSpent = Person.getAverageSpent(NamesPersonsDict);

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
                Person.Regulation(sendersList, receiverList);
                break; 
        }
    }
}