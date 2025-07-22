using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Holidays._0_Models;
using RandomChoser;

namespace Holidays._1__Services
{
    internal interface ITripServices
    {
        public abstract void spent(Person person, double coast , Trip trip);
        public abstract string sendMoney(Person sender, Person receiver);
        public abstract void Regulation(List<Person> sendersList, List<Person> receiverList);
        public abstract double getAverageSpent(Dictionary<string, Person> NamesPersonsDict);


    }
}
