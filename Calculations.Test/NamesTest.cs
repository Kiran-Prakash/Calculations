
using System;
using Xunit;
namespace Calculations.Test
{
    public class NamesTest
    {
        [Fact]
        public void MakeFullNameTest()
        {
            var names = new Names();
            var result = names.MakeFullName("Aref", "Karimi");
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+",result);
        }

        [Fact]
        public void NickName_MustNull()
        {
            var names = new Names();
            names.NickName = "Strong Man";
            Assert.NotNull(names.NickName);
        }

        [Fact]
        public void MakeFullName_AlwaysReturnValue()
        {
            var names = new Names();
            var result = names.MakeFullName("Aref", "Karimi");
            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result));
        }
    }
}
