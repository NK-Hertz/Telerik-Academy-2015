using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            for (int i = 0, len = hand.Cards.Count; i < len; i++)
            {
                var currentCard = hand.Cards[i];
                for (int j = i + 1; j < len; j++)
                {
                    var nextCard = hand.Cards[j];
                    var currentCardIsContainedInHandMoreThanOnce = currentCard.Face == nextCard.Face &&
                            currentCard.Suit == nextCard.Suit;
                    if (currentCardIsContainedInHandMoreThanOnce)
                    {
                        return false;
                    }     
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            var countOfCardsOfAKind = 1;
            for (int card = 0, len = hand.Cards.Count - 3; card < len; card++)
            {
                for (int nextCard = card + 1, leng = hand.Cards.Count; nextCard < leng; nextCard++)
                {
                    var cardsHaveSameFace = hand.Cards[card].Face == hand.Cards[nextCard].Face;
                    if (cardsHaveSameFace)
                    {
                        countOfCardsOfAKind += 1;
                    }
                }

                if (countOfCardsOfAKind == 4)
                {
                    return true;
                }

                countOfCardsOfAKind = 1;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            for (int i = 0, len = hand.Cards.Count - 1; i < len; i++)
            {
                var cardsAreFromSameSuit = hand.Cards[i].Suit == hand.Cards[i + 1].Suit;
                if (!cardsAreFromSameSuit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
