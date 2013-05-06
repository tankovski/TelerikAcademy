using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class PokerHandsCheckerTests
    {
        [TestMethod]
        public void TestIsValidHand()
        {
            Hand hand = new Hand(new List<ICard>{
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades)});

            bool expected = true;
            PokerHandsChecker checker = new PokerHandsChecker();
            bool actual = checker.IsValidHand(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsValidHandWithFourCards()
        {
            Hand hand = new Hand(new List<ICard>{
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades)});

            bool expected = false;
            PokerHandsChecker checker = new PokerHandsChecker();
            bool actual = checker.IsValidHand(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsValidHandWithTwoEqualCards()
        {
            Hand hand = new Hand(new List<ICard>{
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades)});

            bool expected = false;
            PokerHandsChecker checker = new PokerHandsChecker();
            bool actual = checker.IsValidHand(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsFlush()
        {
            Hand hand = new Hand(new List<ICard>{
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades)});

            bool expected = true;
            PokerHandsChecker checker = new PokerHandsChecker();
            bool actual = checker.IsFlush(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsFlushWithOneDiferentColor()
        {
            Hand hand = new Hand(new List<ICard>{
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades)});

            bool expected = false;
            PokerHandsChecker checker = new PokerHandsChecker();
            bool actual = checker.IsFlush(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsFlushWithFiveConsecutiveCards()
        {
            Hand hand = new Hand(new List<ICard>{
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades)});

            bool expected = false;
            PokerHandsChecker checker = new PokerHandsChecker();
            bool actual = checker.IsFlush(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsFourOfAKind()
        {
            Hand hand = new Hand(new List<ICard>{
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Spades)});

            bool expected = true;
            PokerHandsChecker checker = new PokerHandsChecker();
            bool actual = checker.IsFourOfAKind(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsFourOfAKindWithNotFourEqualCards()
        {
            Hand hand = new Hand(new List<ICard>{
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Spades)});

            bool expected = false;
            PokerHandsChecker checker = new PokerHandsChecker();
            bool actual = checker.IsFourOfAKind(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsFourOfAKindWithNotValidHand()
        {
            Hand hand = new Hand(new List<ICard>{
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades)});

            bool expected = false;
            PokerHandsChecker checker = new PokerHandsChecker();
            bool actual = checker.IsFourOfAKind(hand);

            Assert.AreEqual(expected, actual);
        }
    }
}
