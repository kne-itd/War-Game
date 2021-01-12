using System;
using System.Collections.Generic;

namespace War.Objects
{
    public class Game
    {
        private Player Player1;
        private Player Player2;
        private int TurnCount;

        public Game(string player1name, string player2name)
        {
            Player1 = new Player(player1name);
            Player2 = new Player(player2name);

            var cards = DeckCreator.CreateCards();

            var deck = Player1.Deal(cards);

            Player2.Deck = deck;
        }

        public bool IsEndOfGame()
        {
            if (Player1.Deck.Count < 1)
            {
                Console.WriteLine(Player1.Name + " is out of cards! " + Player2.Name + " WINS!");
                Console.WriteLine(Player2.Name + " now has " + Player2.Deck.Count + " cards");
                Console.WriteLine("Turns: " + TurnCount );
                return true;
            }
            else if (Player2.Deck.Count < 1)
            {
                Console.WriteLine(Player2.Name + " is out of cards! " + Player1.Name + " WINS!");
                Console.WriteLine(Player1.Name + " now has " + Player1.Deck.Count + " cards");
                Console.WriteLine("Turns: " + TurnCount);
                return true;
            }
            else if (TurnCount > 1000)
            {
                Console.WriteLine("Infinite game! Let's call the whole thing off!");
                Console.WriteLine(TurnCount + " turns");
                return true;
            }
            
            return false;
        }

        public void PlayTurn()
        {
            Queue<Card> Pool = new Queue<Card>();

            //Step 1: Each player flips a card
            var player1Card = Player1.Deck.Dequeue();
            var player2Card = Player2.Deck.Dequeue();

            Pool.Enqueue(player1Card);
            Pool.Enqueue(player2Card);

            Console.WriteLine(Player1.Name + " plays " + player1Card.DisplayName + "," +
                Player2.Name + " plays " + player2Card.DisplayName);

            // Step 2: If the cards have the same value, we have a war!
            // We continue to have a war as long as the flipped cards
            // have the same value

            while (player1Card.Value == player2Card.Value)
            {
                Console.WriteLine("WAR!");

                // If either player doesn't have enough cards for the war, they lose
                if (Player1.Deck.Count < 4)
                {
                    Player1.Deck.Clear();
                    return;
                }
                if (Player2.Deck.Count < 4)
                {
                    Player2.Deck.Clear();
                    return;
                }

                //Add three "face-down" cards from each player to a common pool
                Pool.Enqueue(Player1.Deck.Dequeue());
                Pool.Enqueue(Player1.Deck.Dequeue());
                Pool.Enqueue(Player1.Deck.Dequeue());
                Pool.Enqueue(Player2.Deck.Dequeue());
                Pool.Enqueue(Player2.Deck.Dequeue());
                Pool.Enqueue(Player2.Deck.Dequeue());

                //Pop the fourth card from each player's deck
                player1Card = Player1.Deck.Dequeue();
                player2Card = Player2.Deck.Dequeue();

                Console.WriteLine(Player1.Name + " plays " + player1Card.DisplayName + " in the war," +
                Player2.Name + " plays " + player2Card.DisplayName + " in the war");

                Pool.Enqueue(player1Card);
                Pool.Enqueue(player2Card);                
            }

            //Add the won cards to the winning player's deck, 
            //and display which player won that hand.  
            //This uses our custom extension method from earlier.

            if (player1Card.Value > player2Card.Value)
            {
                Player1.Deck.Enqueue(Pool);
                Console.WriteLine(Player1.Name + " takes the hand!");
            }
            else
            {
                Player2.Deck.Enqueue(Pool);
                Console.WriteLine(Player2.Name + " takes the hand!");
            }

            TurnCount++;
        }
    }
}
