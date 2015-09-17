using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CardToStringShouldWork()
        {
            var card = new Card(CardFace.Ace, CardSuit.Clubs);
            var cardToString = card.ToString();
            Assert.AreEqual("Ace of Clubs", cardToString, "Card.ToString() returns wrong result!");
        }

        [TestMethod]
        public void HandToStringShouldReturnCorrectString()
        {
            var cards = new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
            };

            var hand = new Hand(cards);

            var stringBuilder = new StringBuilder();
            foreach (var card in cards)
            {
                stringBuilder.AppendLine(card.ToString());
            }

            var cardsToString = stringBuilder.ToString();

            Assert.AreEqual(cardsToString, hand.ToString(), "Hand.ToString is not working properly!");
        }

        [TestMethod]
        public void HandToStringShouldReturnCorrectStringForEmptyHand()
        {
            var hand = new Hand(new List<ICard>());
            Assert.AreEqual("Hand is empty!", hand.ToString());
        }

        [TestMethod]
        public void PokerHandCheckerIsValidHandReturnsTrueIfItIs()
        {
            var hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
            });

            var pokerHandChecker = new PokerHandsChecker();

            Assert.IsTrue(pokerHandChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void PokerHandCheckerIsValidHandReturnsFalseWhenTwoSameCardsAreContainedInHand()
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
            });

            var pokerHandChecker = new PokerHandsChecker();

            Assert.IsFalse(pokerHandChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void PokerHandCheckerIsFlushReturnsTrueIfItIs() 
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
            });

            var pokerHandChecker = new PokerHandsChecker();

            Assert.IsTrue(pokerHandChecker.IsFlush(hand));
        }

        [TestMethod]
        public void PokerHandCheckerIsFlushReturnsFalseIfItIsNot()
        {
            var handWithDiamondInBegining = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
            });

            var handWithDiamondInMiddle = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
            });

            var handWithDiamondInEnd = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
            });

            var pokerHandChecker = new PokerHandsChecker();

            Assert.IsFalse(pokerHandChecker.IsFlush(handWithDiamondInBegining));
            Assert.IsFalse(pokerHandChecker.IsFlush(handWithDiamondInMiddle));
            Assert.IsFalse(pokerHandChecker.IsFlush(handWithDiamondInEnd));
        }

        [TestMethod]
        public void PokerHandCheckerIsFourOfAKindReturnsTrueIfThereAreFourOfAKindInAHand()
        {
            var fourOfAKindWithDifferentCardAtEnd = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
            });

            var fourOfAKindSeparatedByDifferentCardInMiddle = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
            });

            var fourOfAKindWithDifferentCardInBegining = new Hand(new List<ICard>() {
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                
            });

            var pokerHandChecker = new PokerHandsChecker();

            Assert.IsTrue(pokerHandChecker.IsFourOfAKind(fourOfAKindWithDifferentCardAtEnd));
            Assert.IsTrue(pokerHandChecker.IsFourOfAKind(fourOfAKindSeparatedByDifferentCardInMiddle));
            Assert.IsTrue(pokerHandChecker.IsFourOfAKind(fourOfAKindWithDifferentCardInBegining));
        }

        [TestMethod]
        public void PokerHandCheckerIsFourOfAKindReturnsFalseIfThereAreNotFourOfAKindInHand()
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
            });

            var pokerHandChecker = new PokerHandsChecker();

            Assert.IsFalse(pokerHandChecker.IsFourOfAKind(hand));
        }
    }
}
