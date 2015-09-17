using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Santase.Logic.Cards;

namespace Santase.Logic.Tests
{
    [TestFixture]
    public class SantaseLogicTests
    {
        private const int CardsCount = 24;

        [Test]
        public void CreatingDeckGivesFullNumberOfCards()
        {
            var cardsCount = 24;
            var deck = new Deck();
            Assert.AreEqual(cardsCount, deck.CardsLeft, string.Format("Cards are not {0}", cardsCount));
        }

        [TestCase(1)]
        [TestCase(13)]
        [TestCase(24)]
        public void GetNextCardRemovesCardsAfterBeingCalled(int count)
        {
            var deck = new Deck();
            for (int i = 0; i < count; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(CardsCount - count, deck.CardsLeft, "Cards are not removed properly!");
        }

        [Test]
        [ExpectedException(typeof(InternalGameException))]
        public void GetNextCardShouldThrowExceptionIfGetNextCardIsCalledMoreThanTheNumberOfCardsInDeck()
        {
            var deck = new Deck();
            for (int i = 0; i <= CardsCount; i++)
            {
                deck.GetNextCard();
            }
        }

        [Test]
        public void ChangeTrumpCardChangesItSuccessfully()
        {
            var deck = new Deck();
            var trumpCard = deck.GetTrumpCard;
            deck.ChangeTrumpCard(new Card(CardSuit.Club, CardType.Ace));
            var changedTrumpCard = deck.GetTrumpCard;

            Assert.AreNotEqual(trumpCard, changedTrumpCard, "Trump cards are the same! Rerun test if by chance the original trump card was the same as the new one!");
        }
    }
}
