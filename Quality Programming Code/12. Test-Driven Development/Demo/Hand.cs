using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            if (this.Cards.Count == 0)
            {
                return "Hand is empty!";
            }

            var sb = new StringBuilder();
            foreach (var card in this.Cards)
            {
                sb.AppendLine(card.ToString());
            }

            var result = sb.ToString();
            return result;
        }
    }
}
