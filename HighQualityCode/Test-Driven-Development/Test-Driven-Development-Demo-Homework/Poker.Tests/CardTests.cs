using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestToStringAceSpades()
        {
            Card aceSpades = new Card(CardFace.Ace, CardSuit.Spades);
            string expected = "A♠";
            string result = aceSpades.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestToStringTenDiamond()
        {
            Card aceSpades = new Card(CardFace.Ten, CardSuit.Diamonds);
            string expected = "10♦";
            string result = aceSpades.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestToStringSevenClubs()
        {
            Card aceSpades = new Card(CardFace.Seven, CardSuit.Clubs);
            string expected = "7♣";
            string result = aceSpades.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestToStringTwoHearts()
        {
            Card aceSpades = new Card(CardFace.Two, CardSuit.Hearts);
            string expected = "2♥";
            string result = aceSpades.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestToStringJackDiomands()
        {
            Card aceSpades = new Card(CardFace.Jack, CardSuit.Diamonds);
            string expected = "J♦";
            string result = aceSpades.ToString();

            Assert.AreEqual(expected, result);
        }
    }
}
