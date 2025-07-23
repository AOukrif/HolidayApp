using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Holidays._0_Models;
using RandomChoser;

namespace Holidays._1__Services
{
    internal class TripServices:ITripServices
    {
        public string sendMoney(Person sender, Person receiver)
        {
            string result;

            if (sender.diffrenceSpent >= receiver.diffrenceSpent)
            {
                result = $"{sender.name} must send {receiver.diffrenceSpent} to  {receiver.name}";
                sender.diffrenceSpent -= receiver.diffrenceSpent;
                receiver.diffrenceSpent = 0;
                return result;

            }
            if (sender.diffrenceSpent < receiver.diffrenceSpent)
            {
                result = $"{sender.name} must send {sender.diffrenceSpent} euro to  {receiver.name}";
                receiver.diffrenceSpent -= sender.diffrenceSpent;
                sender.diffrenceSpent = 0;
                return result;
            }
            return "error ";

        }

        public double getAverageSpent(Trip trip)
        {

            List<double> dispences = new List<double>();
            foreach (Person person in trip.persons.Values)
            {
                dispences.Add(person.moneySpent);
            }
            Console.WriteLine($"the total spent is {dispences.Sum()} ");
            Console.WriteLine($"the average spent by person is {dispences.Average()} ");
            return dispences.Average();


        }

        public void Regulation(List<Person> sendersList, List<Person> receiverList)
        {

            foreach (Person sender in sendersList)
            {
                foreach (Person receiver in receiverList)
                {
                    Console.WriteLine(sendMoney(sender,receiver));

                }
            }
        }

        public void spent(Person person , double coast,Trip trip)
        {
            person.moneySpent += coast;
            trip.totalSpent += coast;
            Console.WriteLine($"you did spent{trip.totalSpent} out of {trip.budget}");
        }

        public  Person RandomPerson(Trip trip) 
        {
            Random random = new Random();
            int randomIndex = random.Next(0, trip.persons.Count);
            return trip.persons.Values.ElementAt(randomIndex);
        }
    }
}
