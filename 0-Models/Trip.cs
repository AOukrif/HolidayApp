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
        private string _city;
        private int _numbeOfPerson = 1;
        private Person[] persons;
        private  double _totalSpent=0;
        private  double _averageSpent=0;
        public DateOnly startingDate;
        public double budget; 
        
        public string city { get ;set;}
        public double numbeOfPerson { get; set; }
        public  double totalSpent
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
        public  double averageSpent
        {
            get => _averageSpent;
            set
            {
                _averageSpent = totalSpent / numbeOfPerson;
                
            }
        }
        
        public Trip(string city ,  int numberOfPerson)
        {
            
            numbeOfPerson = numberOfPerson;

            persons = new Person[numberOfPerson];
            
        }
    }
}
