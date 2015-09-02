using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListShuffle;

namespace ListShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = GetList().Shuffle();

            DisplayResult(result);

            Console.ReadKey();
        }

        static IList<string> GetList()
        {
            Console.WriteLine("Please provide the items to be shuffled. Type \"done\" to finish.");

            IList<string> list = new List<string>();
            bool done = false;

            while (!done)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "done")
                    done = true;
                else
                    list.Add(input);
            }
            return list;
        }

        static void DisplayResult(IList<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
