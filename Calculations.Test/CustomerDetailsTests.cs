using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Test
{
    [Collection("Customer")]
    public class CustomerDetailsTests
    {
        private readonly CustomerFixture _customerFixture;
        public CustomerDetailsTests(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }
        [Fact]
        public void GetFullName_GivenFullAndLastName_ReturnsFullName()
        {
            var customer = _customerFixture.Cust;
            Assert.Equal("Aref Karimi", customer.GetFullName("Aref", "Karimi"));
        }
    }
}
