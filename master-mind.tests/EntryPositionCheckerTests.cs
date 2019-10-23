using master_mind;
using master_mind.Objects;
using NUnit.Framework;

namespace mastermind.tests {
    public class EntryPositionCheckerTests {

        private SecretCode code = new SecretCode (new int[] { 1, 2, 3, 4 });

        [Test]
        public void EntryInCode_Positive () {
            using (ServiceMock mocks = new ServiceMock ()) {
                EntryPositionChecker entryChecker = Setup (mocks);
                Assert.IsTrue (entryChecker.EntryInCode (code, 1));
                Assert.IsTrue (entryChecker.EntryInCode (code, 2));
                Assert.IsTrue (entryChecker.EntryInCode (code, 3));
                Assert.IsTrue (entryChecker.EntryInCode (code, 4));
            }
        }

        [Test]
        public void EntryInCode_Negative () {
            using (ServiceMock mocks = new ServiceMock ()) {
                EntryPositionChecker entryChecker = Setup (mocks);
                Assert.IsFalse (entryChecker.EntryInCode (code, 55));
                Assert.IsFalse (entryChecker.EntryInCode (code, 6));
                Assert.IsFalse (entryChecker.EntryInCode (code, 700));
                Assert.IsFalse (entryChecker.EntryInCode (code, 8));
            }
        }

        [TestCase ("1234", "++++")]
        [TestCase ("1236", "+++")]
        [TestCase ("1266", "++")]
        [TestCase ("1666", "+")]
        [TestCase ("1634", "+++")]
        [TestCase ("1664", "++")]
        [TestCase ("6234", "+++")]
        public void CheckEntry_CorrectPositions (string entry, string expectedResult) {
            string result = RunTest (entry);
            Assert.AreEqual (expectedResult, result);
        }

        [TestCase ("3341", "----")]
        [TestCase ("7111", "---")]
        [TestCase ("7711", "--")]
        [TestCase ("7377", "-")]
        [TestCase ("2347", "---")]
        [TestCase ("7723", "--")]
        [TestCase ("7113", "---")]
        public void CheckEntry_WrongPositions (string entry, string expectedResult) {
            string result = RunTest (entry);
            Assert.AreEqual (expectedResult, result);
        }

        private string RunTest (string entry) {
            using (ServiceMock mocks = new ServiceMock ()) {
                EntryPositionChecker entryChecker = Setup (mocks);
                return entryChecker.CheckEntry (code, entry);
            }
        }

        private EntryPositionChecker Setup (ServiceMock mocks) {
            mocks.MockConfigService (4, 1, 4);
            return new EntryPositionChecker ();
        }
    }
}