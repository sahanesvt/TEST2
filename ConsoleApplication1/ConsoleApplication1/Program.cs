using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* A - Abstraction
             * P - Polymorphism
             * I - Inheritance
             * E - Encapsulation
             */

        }
    }

    public abstract class Customer
    {
        public virtual string FirstName { get; set;}
        public string LastName { get; set;}
        public string Email { get; set;}

        private bool Validate()
        {
            // validation logic
            return true;
        }
        public abstract void DoSomething();

        public virtual bool Save()
        {
            // save logic
            Validate();
            DatabaseSetup();
            return true;
        }
        private bool DataSetup()
        {
            // logic
            return true;
        }
    }

    public sealed class RetailCustomer : Customer{
        public string CreditCard{get; set;}
        public string RetailIdentifier {get; set;}
        public override void DoSomething(){
            throw new NotImplementedException();
        }
        public override bool Save()
        {
            // save to a database
            return true;
        }
    }

    public class OnlineCustomer : Customer
    {
        public string OnlineIdentifier { get; set;}
        public string WebHistory { get; set;}
        public override void DoSomething()
        {
            throw new NotImplementedException();
        }

        public override bool Save()
        {
            // save to a cloud storage
            return true;
        }
    }
}
