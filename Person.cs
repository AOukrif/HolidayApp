using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RandomChoser
{
    public class Person
    {
        private static double _totalSpent;
        private string _name;
        private double _moneySpent = 0;
        public double diffrenceSpent;

        public static double totalSpent
        {
            get => _totalSpent;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("total spent can't be negative");
                    throw new Exception("total spent can't be negative");
                }
                else { _totalSpent = value; }
            }
        }
        public string name
        {
            get => _name;
            
            set
            {
                _name = value; 
            }
        }
        
        public double moneySpent
        {
            get => _moneySpent;
            set
            {
                if (value < 0) { Console.WriteLine("Money spent value can't be negative "); }
                else { _moneySpent = value; }
            }
        }

        
        // ctor and methodes 
        public Person(string name)
        {
            this.name = name;

        }
        public void spent (double coast)
        {
            this.moneySpent += coast;
            _totalSpent+=coast;
        }
        public string sendMoney(Person receiver)
        {
            string result; 

            if (this.diffrenceSpent >= receiver.diffrenceSpent)
            {
                result = $"{this.name} must send {receiver.diffrenceSpent} to  {receiver.name}";
                this.diffrenceSpent -= receiver.diffrenceSpent;
                receiver.diffrenceSpent = 0;
                return result;

            }
            if (this.diffrenceSpent < receiver.diffrenceSpent)
            {
                result = $"{this.name} must send {this.diffrenceSpent} euro to  {receiver.name}";
                receiver.diffrenceSpent -= this.diffrenceSpent;
                this.diffrenceSpent = 0;
                return result;
            }
            return "error ";
            
        }

        public static string[] ReadNames(char separator ) 
        {
            string names;
            string[] personsNames=null;
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

        public static Dictionary<string, Person> Initialize()
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
                        NamesPersonsDict[name].spent(coast);
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

        public static double getAverageSpent(Dictionary<string, Person> NamesPersonsDict)
        {
             
            List<double> dispences = new List<double>();
            foreach (Person person in NamesPersonsDict.Values)
            {
                dispences.Add(person.moneySpent);
            }
            Console.WriteLine($"the total spent is {dispences.Sum()} ");
            Console.WriteLine($"the average spent by person is {dispences.Average()} ");
            return dispences.Average();
            

        }
        public static void Regulation(List<Person> sendersList , List<Person> receiverList)
        {
            
            foreach (Person sender in sendersList)
            {
                foreach (Person receiver in receiverList)
                {
                    Console.WriteLine(sender.sendMoney(receiver));

                }
            }
        }
    }
}
