using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ListShuffle;

namespace Tests
{
    [TestClass]
    public class ShuffleTests
    {

        [TestMethod]
        public void CanFarroShuffle()
        {
            ICollection<string> input = new List<string>()
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

            ICollection<string> result = ShuffleHelper.FarroShuffle(input);

            Assert.AreNotEqual(input, result);
        }
    }
}
