using System;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            bool isValid = true;
            if (hand.Cards.Count != 5)
            {
                isValid = false;
            }
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face && hand.Cards[i].Suit == hand.Cards[j].Suit)
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            bool isHandValid = IsValidHand(hand);
            byte count = 1;
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = i+1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        count++;
                    }
                }
                if (count == 4)
                {
                    break;
                }
                count = 0;
            }

            bool isFourCardsFromTheSameKind = false;
            if (isHandValid == true && count == 4)
            {
                isFourCardsFromTheSameKind = true;
            }

            return isFourCardsFromTheSameKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            bool isHandValid = IsValidHand(hand);
            bool isAllCardsTheSameColor = IsAllCardsTheSameColor(hand);
            bool isAllCardsConsecutive = IsAllCardsConsecutive(hand);
           
            bool isFlush = false;
            if (isHandValid==true && isAllCardsTheSameColor==true &&
                isAllCardsConsecutive==false)
            {
                isFlush = true;
            }

            return isFlush;
        }

        private static bool IsAllCardsConsecutive(IHand hand)
        {
            bool isAllCardsConsecutive = true;
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if ((int)hand.Cards[i].Face != (int)hand.Cards[i + 1].Face + 1)
                {
                    isAllCardsConsecutive = false;
                    break;
                }
            }
            return isAllCardsConsecutive;
        }

        private static bool IsAllCardsTheSameColor(IHand hand)
        {
            bool isAllCardsTheSameColor = true;

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                if (hand.Cards[i].Suit != hand.Cards[i + 1].Suit)
                {
                    isAllCardsTheSameColor = false;
                    break;
                }
            }

            return isAllCardsTheSameColor;
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
