using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Test
{
    [Collection("Customer")]
    public class CustomerTests
    {
        private readonly CustomerFixture _customerFixture;
        public CustomerTests(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }
        [Fact]
        public void CheckLegiForDiscount()
        {
            var customer = _customerFixture.Cust;
            Assert.InRange(customer.Age, 25, 30);
        }

        [Fact]
        public void GetOrdersByNameNotNull()
        {
            var customer = _customerFixture.Cust;
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GetOrdersByName(""));
            Assert.Equal("Hello", exceptionDetails.Message);
        }

        [Fact]
        public void LoyalCustomerForOrderG100()
        {
            var customer = CustomerFactory.CreateCustomerInstance(102);
            var loyalCustomer = Assert.IsType<LoyalCustomer>(customer);
            Assert.Equal(10, loyalCustomer.Discount);
        }
    }
}
