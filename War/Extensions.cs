using System;
using System.Collections.Generic;
using War.Objects;

namespace War
{
    public static class Extensions
    {
        //The first parameter of the method specifies the type that the method operates on;
        //it must be preceded with the this modifier.
        //In the calling code, add a using directive to specify the namespace
        //that contains the extension method class. Call the methods as if they were instance methods on the type.

       public static void Enqueue(this Queue<Card> cards, Queue<Card> newCards)
        {
            foreach (var card in newCards)
            {
                cards.Enqueue(card);
            }
        }
    }
}
