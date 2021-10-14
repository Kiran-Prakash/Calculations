using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace Calculations.Test
{
    public class isOddOrEvenDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 1, true };
            yield return new object[] { 200, false };
        }
    }
}
