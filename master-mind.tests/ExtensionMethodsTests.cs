using master_mind;
using NUnit.Framework;

namespace mastermind.tests {
    public class ExtensionMethodsTests {

        [Test]
        public void CheckForVictory_Positive () {
            string result = "++++";
            Assert.IsTrue (result.CheckForVictory (4, '+'));
        }

        [Test]
        public void CheckForVictory_NegativeCharacter () {
            string result = "++_+";
            Assert.IsFalse (result.CheckForVictory (4, '+'));
        }

        [Test]
        public void CheckForVictory_NegativeLength () {
            string result = "++";
            Assert.IsFalse (result.CheckForVictory (4, '+'));
        }
    }
}