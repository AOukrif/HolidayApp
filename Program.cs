// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using RandomChoser;

class Program
{
    public static void Main()
    {
        Console.WriteLine("you want to : \n " +
            "1 - Random person choice \n " +
            "2 - Calculate total spent with the tricount ");
        int choice = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the names of the persons in the trip  ");
        string names = Console.ReadLine();
        string[] personsNames = names.Split(' ');

        switch (choice)
        {
            case 1:
                Random random = new Random();
                int randomIndex = random.Next(0, personsNames.Length);
                Console.WriteLine($" The chosen is {personsNames[randomIndex]} ");
                break;

            case 2:
                Dictionary<string, Person> NamesPersonsDict = new Dictionary<string, Person>();
                int i = 0;
                foreach (string person in personsNames)
                {
                    Person personObj = new Person(personsNames[i]);
                    NamesPersonsDict.Add(personsNames[i], personObj);
                    i++;

                }
                bool again = true;
                while (again)
                {
                    Console.WriteLine("enter a name spent");
                    string name = Console.ReadLine();
                    Console.WriteLine(" enter the coast ");
                    double coast = double.Parse(Console.ReadLine());
                    try
                    {
                        NamesPersonsDict[name].spent(coast);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("please entre a person name from the list");
                        continue;
                    }
                    Console.WriteLine(" you want to add an other spent ? (y/n)");
                    string againBis = Console.ReadLine();
                    if (againBis == "n") { again = false; }
                }
                Console.WriteLine($"the total spent is {Person.totalSpent} ");
                double averageSpent = Person.totalSpent / NamesPersonsDict.Count;

                List<Person> sendersList = new List<Person>(); // only person with diffrence != 0
                List<Person> receiverList = new List<Person>();

                foreach (Person person in NamesPersonsDict.Values)
                {
                    person.diffrenceSpent = person.MoneySpent - averageSpent;
                    if (person.diffrenceSpent > 0) { receiverList.Add(person); }
                    if (person.diffrenceSpent < 0)
                    {
                        person.diffrenceSpent = -1 * person.diffrenceSpent;
                        sendersList.Add(person);
                    }
                }
                
                foreach (Person sender in sendersList)
                {
                    foreach (Person receiver in receiverList)
                    {
                        Console.WriteLine(sender.sendMoney(receiver));

                    }
                }
                break; 
                

                
        }
    }
}