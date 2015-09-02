using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ListShuffle;
using System.Collections;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class ShuffleTests
    {
        // default list
        IList<string> defaultList = new List<string>()
            {
                "apple",
                "blackberry",
                "cherry",
                "dragonfruit",
                "grapefruit",
                "kumquat",
                "mango",
                "nectarine",
                "persimon",
                "raspberry",
                "raspberry",
                "a",
                "e",
                "i",
                "o",
                "u",
            };

        [TestMethod]
        public void CanFaroShuffle()
        {
            IList<string> result = Shuffler.FaroShuffle(defaultList);

            Assert.AreNotEqual(true, Enumerable.SequenceEqual(defaultList, result));
        }

        [TestMethod]
        public void ContinuousFaroShuffleReturnsInitialList()
        {
            // Shuffling 52 items 8 times should get us the same order as the initial list

            IList<string> input = new List<string>();

            for (int i = 0; i < 52; i++)
            {
                input.Add(i.ToString());
            }

            IList<string> result = new List<string>();

            for (int i = 0; i < 8; i++)
            {
                if (i == 0)
                    result = Shuffler.FaroShuffle(input);
                else
                    result = Shuffler.FaroShuffle(result);
            }

            Assert.AreEqual(true, Enumerable.SequenceEqual(input, result));
        }

        [TestMethod]
        public void CanKnuthShuffle()
        {
            IList<string> result = Shuffler.KnuthShuffle(defaultList);

            Assert.AreNotEqual(true, Enumerable.SequenceEqual(defaultList, result));
        }
    }
}
