using System.Linq;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Codewars
{
    public enum Result
    {
        Win,
        Loss,
        Tie
    }

    public class PokerHand
    {
        private List<Card> Cards;
        public PokerHand(string hand)
        {
            Cards =  hand.Split(" ").Select((element, index) => new Card(element)).OrderBy(x => x.Value).ToList();
        }


        public Result CompareWith(PokerHand hand)
        {
            if (GetValue() > hand.GetValue()) {
                return Result.Win;
            }
            if (GetValue() < hand.GetValue()) {
                return Result.Loss;
            }
            if (GetValue() == hand.GetValue())
            {
                if (GetValue() == 0)
                {
                    for (int i = 4; i >= 0; i--)
                    {
                        if (Cards[i].Value < hand.Cards[i].Value)
                        {
                            return Result.Loss;
                        }
                        if (Cards[i].Value > hand.Cards[i].Value)
                        {
                            return Result.Win;
                        }
                    }
                    return Result.Tie;
                }
                if (MaxPairValue() == hand.MaxPairValue()) {
                    for (int i = 4; i >= 0; i--)
                    {
                        if (Cards[i].Value < hand.Cards[i].Value)
                        {
                            return Result.Loss;
                        }
                        if (Cards[i].Value > hand.Cards[i].Value)
                        {
                            return Result.Win;
                        }
                    }
                }
                else
                {
                    if (MaxPairValue() > hand.MaxPairValue())
                    {
                        return Result.Win;
                    }
                    if (MaxPairValue() < hand.MaxPairValue())
                    {
                        return Result.Loss;
                    }
                }
                    return Result.Tie;

            }
            return Result.Tie;
        }

        public int GetValue()
        {
            if (HasFlush() && HasStraight())
            {
                return Cards.Last().Value * 50000;
            }
            if (MaxPairCount() == 4 && !HasFlush())
            {
                return MaxPairValue() * 2000;
            }
            if (HasFullHouse())
            {
                return Cards[4].Value * 300;
            }
            if (HasFlush())
            {
                return Cards.Last().Value * 30;
            }
            if (HasStraight())
            {
                return Cards.Last().Value * 20;
            }
            if (MaxPairCount() == 3)
            {
                return 3;
            }
            if (HasTwoPairs())
            {
                return 2;
            }
            if (HasPair())
            {
                return 1;
            }
            return 0;
        }
        
        public bool HasPair()
        {
            return Cards.GroupBy(c => c.Value).Count() == 4;
        }
        public bool HasTwoPairs()
        {
            return Cards.GroupBy(c => c.Value).Count() == 3;
        }
        public bool HasFlush()
        {
            return Cards.GroupBy(c => c.Suit).Max(group => group.Count()) == 5; 
        }

        public bool HasStraight()
        {
            for (int i = 0; i < 4; i++)
            {
                if (Cards[i].Value+1 != Cards[i+1].Value)
                {
                    return false;
                }
            }
            return true;
        }
        public bool HasFullHouse()
        {
            return CountOccurrence(Cards.First().Value) + CountOccurrence(Cards.Last().Value) == 5;
        }
        public int MaxPairCount()
        {
            return Cards.GroupBy(c => c.Value).Max(group => group.Count());
        }
        public int CountOccurrence(int value)
        {
            return Cards.Where(x => x.Value == value).Count();
        }
        public int MaxPairValue()
        {
            return Cards.GroupBy(x => x.Value)
                        .OrderByDescending(x => x.Count())
                        .First().Key;
        }
        private class Card
        {
            public int Value { get; set; }
            public char Suit { get; set; }

            public Card(string card)
            {
                if (Char.IsNumber(card[0]))
                {
                    Value = (int)char.GetNumericValue(card[0]);
                }
                else
                {
                    switch (card[0])
                    {
                        case 'T':
                            Value = 10;
                            break;
                        case 'J':
                            Value = 11;
                            break;
                        case 'Q':
                            Value = 12;
                            break;
                        case 'K':
                            Value = 13;
                            break;
                        case 'A':
                            Value = 14;
                            break;
                    }
                }
                Suit = card[1];
            }
        }
            public static void TestCase(string text, Result result, String hand1, String hand2)
        {
            PokerHand hand = new PokerHand(hand1);
            PokerHand compareHand = new PokerHand(hand2);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"Compare {hand1} and {hand2} :");
            if (hand.CompareWith(compareHand) == result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("correct");
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(text);
            }
        }
        public static void Main(string[] args)
        {

            TestCase("Highest straight flush wins", Result.Loss, "2H 3H 4H 5H 6H", "KS AS TS QS JS");
               TestCase("Straight flush wins of 4 of a kind", Result.Win, "2H 3H 4H 5H 6H", "AS AD AC AH JD");
               TestCase("Highest 4 of a kind wins", Result.Win, "AS AH 2H AD AC", "JS JD JC JH 3D");
               TestCase("4 Of a kind wins of full house", Result.Loss, "2S AH 2H AS AC", "JS JD JC JH AD");
               TestCase("Full house wins of flush", Result.Win, "2S AH 2H AS AC", "2H 3H 5H 6H 7H");
               TestCase("Highest flush wins", Result.Win, "AS 3S 4S 8S 2S", "2H 3H 5H 6H 7H");
               TestCase("Flush wins of straight", Result.Win, "2H 3H 5H 6H 7H", "2S 3H 4H 5S 6C");
               TestCase("Equal straight is tie", Result.Tie, "2S 3H 4H 5S 6C", "3D 4C 5H 6H 2S");
               TestCase("Straight wins of three of a kind", Result.Win, "2S 3H 4H 5S 6C", "AH AC 5H 6H AS");
               TestCase("3 Of a kind wins of two pair", Result.Loss, "2S 2H 4H 5S 4C", "AH AC 5H 6H AS");
               TestCase("2 Pair wins of pair", Result.Win, "2S 2H 4H 5S 4C", "AH AC 5H 6H 7S");
               TestCase("Highest pair wins", Result.Loss, "6S AD 7H 4S AS", "AH AC 5H 6H 7S");
               TestCase("Pair wins of nothing", Result.Loss, "2S AH 4H 5S KC", "AH AC 5H 6H 7S");
               TestCase("Highest card loses", Result.Loss, "2S 3H 6H 7S 9C", "7H 3C TH 6H 9S");
               TestCase("Highest card wins", Result.Win, "4S 5H 6H TS AC", "3S 5H 6H TS AC");
               TestCase("Equal cards is tie", Result.Tie, "2S AH 4H 5S 6C", "AD 4C 5H 6H 2C");
              TestCase("Straight wins of three of a kind", Result.Win, "2S 3H 4H 5S 6C", "AH AC 5H 6H AS");
              TestCase("2 Pair wins of pair", Result.Win, "2S 2H 4H 5S 4C", "AH AC 5H 6H 7S");
              TestCase("House over flush", Result.Win, "2H 2C 3S 3H 3D", "3S 8S 9S 5S KS");
              TestCase("Higher pair", Result.Win, "KC 4H KS 2H 8D", "QH 8H KD JH 8S");
             TestCase("Higher nothing", Result.Loss, "JH 8S TH AH QH", "TS KS 5S 9S AC");
            TestCase("Higher three of a kind wins", Result.Loss, "7C 7S 3S 7H 5S", "AC KH QH AH AS");
            TestCase("Full House wins of flush", Result.Loss, "JH 8H AH KH QH", "3D 2H 3H 2C 2D");
            Console.ReadKey();

        }
    }

}
