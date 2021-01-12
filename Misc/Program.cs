using System;
using System.Collections.Generic;

namespace Misc
{
    class Program
    {
        static void Main(string[] args)
        {



                List<Char> unshuffled = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
                Random r = new Random();

                for (int i = unshuffled.Count - 1; i > 0; i--)
                {
                    Console.WriteLine(i);
                    int k = r.Next(i + 1);
                    char temp = unshuffled[i];
                    unshuffled[i] = unshuffled[k];
                    unshuffled[k] = temp;
                }

                Console.WriteLine(String.Join(',', unshuffled));
            }

    }
}
