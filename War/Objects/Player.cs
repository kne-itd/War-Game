using System;
using System.Collections.Generic;

namespace War.Objects
{
    public class Player
    {
        public string Name { get; set; }
        public Queue<Card> Deck { get; set; }

        public Player()
        {

        }
        public Player(string name)
        {
            Name = name;
        }
        public Queue<Card> Deal(Queue<Card> cards)
        {
            Queue<Card> Player1Cards = new Queue<Card>();
            Queue<Card> Player2Cards = new Queue<Card>();

            int Counter = 2;
            while (cards.Count > 0)
            {
                if (Counter % 2 == 0)
                {
                    Player2Cards.Enqueue(cards.Dequeue());
                }
                else
                {
                    Player1Cards.Enqueue(cards.Dequeue());
                }
                Counter++;
            }
            Deck = Player1Cards;
            return Player2Cards;
        }
    }
}
