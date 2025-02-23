using LeetCodeSandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashMaps;

namespace LeetCodeSandboxTests
{
    [TestClass]
    public class CloseStringsTests
    {
        [TestMethod]
        public void CloseStringsTest1()
        {
            string word1 = "cabbba";
            string word2 = "abbccc";

            CloseStrings callMe = new CloseStrings();
            var output = callMe.CloseStringsExecute(word1, word2);

            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void CloseStringsTest2()
        {
            string word1 = "cabbbaz";
            string word2 = "abbccc";

            CloseStrings callMe = new CloseStrings();
            var output = callMe.CloseStringsExecute(word1, word2);

            Assert.AreEqual(false, output);
        }

        [TestMethod]
        public void CloseStringsTest3()
        {
            string word1 = "cabbbab";
            string word2 = "abbccca";

            CloseStrings callMe = new CloseStrings();
            var output = callMe.CloseStringsExecute(word1, word2);

            Assert.AreEqual(false, output);
        }
    }
}
