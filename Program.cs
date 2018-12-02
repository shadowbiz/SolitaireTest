using System;
using System.Collections.Generic;

namespace Solitaite
{
    class Program
    {
        class Card
        {
            public byte Value;
            public byte Color;
            public Card(byte v, byte c)
            {
                Value = v;
                Color = c;
            }

            static string GetColor(int color)
            {
                switch (color)
                {
                    case 0:
                        return "♠";
                    case 1:
                        return "♥";
                    case 2:
                        return "♦";
                    case 3:
                        return "♣";
                    default:
                        return "NULL";
                }
            }

            static string GetValue(int color)
            {
                switch (color)
                {
                    case 0:
                        return " 2";
                    case 1:
                        return " 3";
                    case 2:
                        return " 4";
                    case 3:
                        return " 5";
                    case 4:
                        return " 6";
                    case 5:
                        return " 7";
                    case 6:
                        return " 8";
                    case 7:
                        return " 9";
                    case 8:
                        return "10";
                    case 9:
                        return " J";
                    case 10:
                        return " Q";
                    case 11:
                        return " K";
                    case 12:
                        return " A";
                    default:
                        return "NULL";
                }
            }

            public override string ToString()
            {
                return string.Format("[{0:00} {1:00} ]", GetValue(Value), GetColor(Color));
            }
        }

        static Random _rnd = new Random();

        static void Shuffle(ref List<Card> cards)
        {
            var count = cards.Count;
            for (var i = 0; i != count; ++i)
            {
                var index = _rnd.Next() % count;
                var tmp = cards[i];
                cards[i] = cards[index];
                cards[index] = tmp;
            }
        }

        static void PrintDeck(List<Card> deck)
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (var c in deck)
            {
                Console.Write("{0} \n", c);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var cardDeck = new List<Card>(52);
            var cards = new List<Card>(52);

            int index = 0;
            for (int c = 0; c != 4; ++c)
            {
                for (int v = 0; v != 13; ++v)
                {
                    cardDeck.Add(new Card((byte)v, (byte)c));
                }
            }

            //Shuffle(ref cardDeck);
            index = 0;

            for (int i = 0; i != 2; ++i)
            {
                var card = cardDeck[_rnd.Next() % cardDeck.Count];
                cards.Add(card);
                cardDeck.Remove(card);

                var value = (cardDeck[index].Value);
                var color = (cardDeck[index].Color);
            }

            PrintDeck(cards);

            var remove = new List<Card>();
            while (cardDeck.Count > 0)
            {
                var deckCount = cards.Count - 1;
                var deckIndex = _rnd.Next() % deckCount;
                var deckCard = cards[deckIndex];

                for (var i = 0; i != cardDeck.Count; ++i)
                {
                    var card = cardDeck[i];
                    if ((deckCard.Color == card.Color) ||
                        (deckCard.Value == card.Value))
                    {
                        cards.Insert(deckIndex + 2, card);
                        remove.Add(card);
                        cardDeck.Remove(card);
                        Console.WriteLine("{0} --- {1}", deckCard, card);
                        //Console.ReadKey();
                        //PrintDeck(cards);
                        break;
                    }
                }
            }

            PrintDeck(cards);

            Console.WriteLine("Added {0} to REMOVE", remove.Count);

            index = 0;

            for (var i = remove.Count - 1; i >= 0; --i)
            {
                var c = remove[i];
                var index0 = cards.IndexOf(c);
                var c1 = cards[index0];
                var c2 = cards[index0 - 2];
                if ((c1.Color == c2.Color) ||
                    (c1.Value == c2.Value))
                {
                    Console.WriteLine("{0} --- {1}", c1, c2);
                    //Console.WriteLine("OK ");
                    //Console.ReadKey();
                    cards.Remove(c);
                    index++;
                    
                }
            }
            Console.WriteLine();

            PrintDeck(cards);

            Console.WriteLine("Removed {0} ", index);
            Console.ReadKey();
        }
    }
}
