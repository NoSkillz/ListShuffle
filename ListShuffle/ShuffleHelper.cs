using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListShuffle
{
    public static class ShuffleHelper
    {
        public static ICollection<string> FarroShuffle(ICollection<string> list)
        {
            if (list.Count == 0)
                throw new InvalidOperationException();

            var items = list.Count;

            //First half needs to greater by 1, or equal to the second half for this to work right
            int firstHalfSize;
            if (list.Count % 2 == 0)
                firstHalfSize = list.Count / 2;
            else
                firstHalfSize = list.Count / 2 + 1;

            //Split in two halfs
            ICollection<string> firstHalf = list.Take(firstHalfSize).ToList();
            ICollection<string> secondHalf = list.Skip(firstHalfSize).Take(list.Count - firstHalfSize).ToList();



            ICollection<string> shuffledList = new List<string>();

            for (int i = 0, skip = 0; i < items; i = i + 2, skip++)
            {
                var item = firstHalf.Skip(skip).FirstOrDefault();
                if (item != null)
                    shuffledList.Add(item);
                item = secondHalf.Skip(skip).FirstOrDefault();
                if (item != null)
                    shuffledList.Add(item);
            }

            return shuffledList;
        }
    }
}
