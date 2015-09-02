using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            IList<string> list = new List<string>();

            Console.WriteLine("Please provide the items to be shuffled. Type \"done\" to finish.");

            while (!done)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "done")
                    done = true;
                else
                    list.Add(input);
            }

            IList<string> result = Shuffler.RandomShuffle(list);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
