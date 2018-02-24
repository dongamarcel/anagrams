using System;
using System.Collections.Generic;
using AnagramConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace WSCADAnagramsTest
{
    [TestClass]
    public class AnagramControllerTest
    {
        private AnagramsTextFile anagramsTextFileController;
        private AnagramController anagramController;

        public AnagramControllerTest()
        {
            this.anagramsTextFileController = new AnagramsTextFile(new List<string> { "ZAB", "BAZ", "AZB" }.ToArray());
            this.anagramController = new AnagramController(this.anagramsTextFileController);
        }

        [TestMethod]
        public void SortListTest()
        {
            var sortedList = anagramsTextFileController.GetSortedList();
            Assert.IsTrue(sortedList.ToArray()[0].Value.Equals("ABZ"));
            Assert.IsTrue(sortedList.ToArray()[0].Key.Equals(0));
        }

        [TestMethod]
        public void GetUnmodifiedListTest()
        {
            var unmodifiedList = anagramsTextFileController.GetUnmodifiedList();
            Assert.IsTrue(unmodifiedList[0].Equals("ZAB"));
        }

        [TestMethod]
        public void GetAnagrams()
        {
            Assert.IsTrue(this.anagramController.GetAnagrams().IndexOf("ZAB").Equals(0));
        }
    }
}
