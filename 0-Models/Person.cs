using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Holidays._2_Utils;

namespace RandomChoser
{
    public class Person
    {
        
        private string _name;
        private double _moneySpent = 0;
        public double diffrenceSpent;

        
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
      
        public Person(string name)
        {
            this.name = name;

        }
        
    }
}
