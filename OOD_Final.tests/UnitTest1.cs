using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using s00200671_RonnieConlon_OOD_Final;

namespace OOD_Final.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Game_DecreasePrice1()
        {
            // Test positive result

            // ARRANGE
            Game g1 = new Game() { Price = 50 };
            decimal AmountToDecrease = 20;
            decimal ExpectedResult = 30;

            // ACT
            g1.DecreasePrice(AmountToDecrease);

            // ASSERT
            Assert.AreEqual(g1.Price, ExpectedResult);
        }

        [TestMethod]
        public void Game_DecreasePrice2()
        {
            // Test negative result (Can't be below 0)

            // ARRANGE
            Game g1 = new Game() { Price = 50 };
            decimal AmountToDecrease = 100;
            decimal ExpectedResult = 50;

            // ACT
            g1.DecreasePrice(AmountToDecrease);

            // ASSERT
            Assert.AreEqual(g1.Price, ExpectedResult);
        }
    }
}
