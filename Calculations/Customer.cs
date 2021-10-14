using System;
using System.Collections.Generic;
using System.Text;

namespace Calculations
{
    public class Customer
    {
        public virtual int GetOrdersByName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Hello");
            }
            return 100;
        }
        public int Age => 35;
        public string GetFullName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }
    }

    public class LoyalCustomer : Customer
    {
        public int Discount { get; set; }
        public LoyalCustomer()
        {
            Discount = 10;
        }
        public override int GetOrdersByName(string name)
        {
            return 101;
        }
    }

    public static class CustomerFactory
    {
        public static Customer CreateCustomerInstance(int orderCount)
        {
            if (orderCount <= 100)
            {
                return new Customer();
            } else
            {
                return new LoyalCustomer();
            }
        }
    }
}
