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


                // fill the dictionary 
                int i = 0;
                foreach (string person in personsNames)
                {
                    Person personObj = new Person(personsNames[i]);
                    NamesPersonsDict.Add(personsNames[i], personObj);
                    i++;
                }

                // reading data soent and persons
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

                // calculating the average and the total spent 
                List<double> dispences = new List<double>();
                foreach (Person person in NamesPersonsDict.Values)
                {
                    dispences.Add(person.MoneySpent);
                }
                double averageSpent = dispences.Average();
                Console.WriteLine($"the total spent is {dispences.Sum()} ");
                Console.WriteLine($"the average spent by person is {dispences.Average()} ");

                // defining the sender and the receiver of money at the end of the trip 
                List<Person> sendersList = new List<Person>(); 
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
                
                // regulation 
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