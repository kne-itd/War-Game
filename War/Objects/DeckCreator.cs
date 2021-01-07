using System;
using System.Collections.Generic;

namespace War.Objects
{
    public static class DeckCreator
    {
        public static Queue<Card> CreateCards()
        {
            Queue<Card> cards = new Queue<Card>();
            for (int i = 2; i <= 14; i++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Enqueue(new Card()
                    {
                        Suit = suit,
                        Value = i,
                        DisplayName = GetShortName(i, suit)
                    });
                }
            }
            return Shuffle(cards);
        }

        private static Queue<Card> Shuffle(Queue<Card> cards)
        {
            //List<Card> ListOfCards = cards.ToList(); // Linq
            List<Card> ListOfCards = new List<Card>();
            foreach (var card in cards)
            {
                ListOfCards.Add(card);
            }
            Random rnd = new Random();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int k = rnd.Next(i + 1);
                Card temp = ListOfCards[i];
                ListOfCards[i] = ListOfCards[k];
                ListOfCards[k] = temp;
            }
            Queue<Card> ShuffledCards = new Queue<Card>();
            foreach (var card in ListOfCards)   
            {
                ShuffledCards.Enqueue(card);
            }
            return ShuffledCards;
        }

        private static string GetShortName(int value, Suit suit)
        {
            string output = String.Empty;
            if (value >= 2 && value <= 10)
            {
                output = value.ToString();
            }
            else if (value == 11)   
            {
                output = "J";
            }
            else if (value == 12)
            {
                output = "Q";
            }
            else if (value == 13)
            {
                output = "K";
            }
            else if (value == 14)
            {
                output = "A";
            }

            output += Enum.GetName(typeof(Suit), suit)[0];
            return output;
        }
    }
}
