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

        [TestMethod]
        public void CanFarroShuffle()
        {
            IList<string> input = new List<string>()
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

            IList<string> result = ShuffleHelper.FarroShuffle(input);

            Assert.AreNotEqual(true, Enumerable.SequenceEqual(input, result));
        }

        [TestMethod]
        public void ContinuousFarroShuffleReturnsInitialList()
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
                    result = ShuffleHelper.FarroShuffle(input);
                else
                    result = ShuffleHelper.FarroShuffle(result);
            }

            Assert.AreEqual(true, Enumerable.SequenceEqual(input, result));
        }
    }
}
