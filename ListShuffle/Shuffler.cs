using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListShuffle
{
    public static class Shuffler
    {
        static private IList<string> result { get; set; }

        /// <summary>
        /// Returns a Faro shuffled list.
        /// The initial list is split in half. A new list is created by alternately adding each item from the half-lists to it.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IList<string> FaroShuffle(IList<string> list)
        {
            if (list.Count == 0)
                return list;

            var items = list.Count;

            //First half needs to greater by 1, or equal to the second half for this to work right
            int firstHalfSize;
            if (list.Count % 2 == 0)
                firstHalfSize = list.Count / 2;
            else
                firstHalfSize = list.Count / 2 + 1;

            //Split in two halfs
            IList<string> firstHalf = list.Take(firstHalfSize).ToList();
            IList<string> secondHalf = list.Skip(firstHalfSize).Take(list.Count - firstHalfSize).ToList();



            IList<string> result = new List<string>();

            for (int i = 0, skip = 0; i < items; i = i + 2, skip++)
            {
                var item = firstHalf.Skip(skip).FirstOrDefault();
                if (item != null)
                    result.Add(item);
                item = secondHalf.Skip(skip).FirstOrDefault();
                if (item != null)
                    result.Add(item);
            }

            return result;
        }

        /// <summary>
        /// Returns a Knuth shuffled list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IList<string> KnuthShuffle(IList<string> list)
        {
            if (list.Count == 0)
                return list;

            //Copy the list, as we're gonna swap result in place and return it
            result = list.Select(m => m).ToList();

            Random random = new Random();
            
            for (int i = 0; i < list.Count; i++)
            {
                int strikeIndex = random.Next(list.Count - i);

                result = Swap(result, strikeIndex, list.Count - 1);
            }

            return result;
        }

        /// <summary>
        /// Swaps the elements at the specified indexes and returns the same list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="firstIndex"></param>
        /// <param name="secondIndex"></param>
        /// <returns></returns>
        private static IList<string> Swap(IList<string> list, int firstIndex, int secondIndex)
        {
            var tempElement = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = tempElement;
            return list;
        }

        public static IList<string> RandomShuffle(IList<string> list)
        {
            Random random = new Random();
            int result = random.Next(2);

            if (result == 0)
                return FaroShuffle(list);
            else
                return KnuthShuffle(list);
        }
    }
}