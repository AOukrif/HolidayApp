using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChoser;

namespace Holidays._0_Models
{
    internal class Trip
    {
        public string city { get; set; }
        public int numbeOfPerson { get; set; }
        public Dictionary<string, Person> persons { get; set; }
        public DateOnly startingDate { get; set; }
        public double budget { get; set; }

        public double totalSpent { get; set; }
        private double averageSpent
        {
            get
            {
                return totalSpent / numbeOfPerson;
            }
            set{}
        }

        public Trip(string city ,  int numberOfPerson, DateOnly date , double budget , Dictionary<string, Person> persons)
        {
            
            this.numbeOfPerson = numberOfPerson;
            this.startingDate = date;
            this.budget = budget;
            this.persons = persons;


        }
    }
}
