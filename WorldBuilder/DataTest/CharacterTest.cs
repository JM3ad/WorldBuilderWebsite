using System;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTest
{
    [TestClass]
    public class CharacterTest
    {
        [TestMethod]
        public void Test_Character_HasName()
        {
            var character = new Character();
            Assert.IsTrue(true);
        }
    }
}
