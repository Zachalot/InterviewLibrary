using LeetCodeSandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSandboxTests
{
    [TestClass]
    public class IncreasingTripletTests
    {
        [TestMethod]
        public void IncreasingTripletTest()
        {
            int[] testInput = new int[3] { 5, 1, 6 };

            IncreasingTriplet callMe = new IncreasingTriplet();
            var output = callMe.IncreasingTripletSolve(testInput);

            Assert.AreEqual(false, output);
        }
    }
}
