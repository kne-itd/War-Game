using System;
using System.Collections;
using System.Collections.Generic;

namespace WarLibrary
{
    public class FisherYatesShuffler
    {
        private void _shuffle<T>(List<T> collection)
        {
            Random Rnd = new Random();
            for(int i = collection.Count - 1; i > 0; i--)
            {
                int k = Rnd.Next(i + 1);
                T temp = collection[i];
                collection[i] = collection[k];
                collection[k] = temp;
            }
        }
        public ICollection<T> Shuffle<T>(ICollection<T> collection)
        {
            List<T> output = new List<T>(collection);
            _shuffle(output);
            return output;
        }


        public Queue<T> Shuffle<T>(Queue<T> collection)
        {
            List<T> ListOfObjects = new List<T>(collection);
            _shuffle(ListOfObjects);
            Queue<T> output = new Queue<T>(ListOfObjects);

            return output;
        }
    }
}
