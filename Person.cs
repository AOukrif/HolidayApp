using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChoser
{
    internal class Person
    {
        public static double totalSpent; 

        public string Name;
        public double MoneySpent=0;
        public double diffrenceSpent = 0;
        public void setName(string name)
        {
            this.Name = name;
        }
        public string getName()
        {
            return Name;
        }
        public Person(string name)
        {
            this.Name = name;
            
        }
        public void spent (double coast)
        {
            this.MoneySpent += coast;
            totalSpent+=coast;
        }
        public string sendMoney(Person receiver)
        {
            string result; 

            if (this.diffrenceSpent >= receiver.diffrenceSpent)
            {
                result = $"{this.Name} must send {receiver.diffrenceSpent} to  {receiver.Name}";
                this.diffrenceSpent -= receiver.diffrenceSpent;
                receiver.diffrenceSpent = 0;
                return result;

            }
            if (this.diffrenceSpent < receiver.diffrenceSpent)
            {
                result = $"{this.Name} must send {this.diffrenceSpent} euro to  {receiver.Name}";
                receiver.diffrenceSpent -= this.diffrenceSpent;
                this.diffrenceSpent = 0;
                return result;
            }
            return "error ";
            
        }
    }
}
