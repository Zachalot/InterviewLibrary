using LeetCodeSandbox;

namespace LeetCodeSandboxTests
{
    [TestClass]
    public sealed class ReverseVowelsTests
    {
        public ReverseVowelsProblem problem = new ReverseVowelsProblem();

        [TestInitialize]
        public void InitializeTest()
        {
            problem = new ReverseVowelsProblem();
        }
        [TestMethod]
        public void ReverseVowelsTest1()
        {
            string s = "IceCreAm";
            string expected = "AceCreIm";

            string actual = this.problem.ReverseVowels(s);

            Assert.AreEqual(expected, actual);

        }
    }
}
