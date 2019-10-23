using master_mind;
using NUnit.Framework;

namespace mastermind.tests {
    public class EntryValidationTests {

        [Test]
        public void ValidateEntryLength_Passing () {
            using (ServiceMock mocks = new ServiceMock ()) {
                mocks.MockConfigService (3);
                EntryValidation validator = new EntryValidation ();
                Assert.IsTrue (validator.ValidateEntryLength ("moo"));
            }
        }

        [Test]
        public void ValidateEntryLength_Failing () {
            using (ServiceMock mocks = new ServiceMock ()) {
                mocks.MockConfigService (3);
                EntryValidation validator = new EntryValidation ();
                Assert.IsFalse (validator.ValidateEntryLength ("bacon"));
            }
        }

        [Test]
        public void ValidateEntryNumericAndInMinMaxBounds_NonNumeric () {
            using (ServiceMock mocks = new ServiceMock ()) {
                mocks.MockConfigService (3, 1, 8);
                EntryValidation validator = new EntryValidation ();
                Assert.IsFalse (validator.ValidateEntryNumericAndInMinMaxBounds ("bacon is the best"));
            }
        }

        [Test]
        public void ValidateEntryNumericAndInMinMaxBounds_BelowMinValue () {
            using (ServiceMock mocks = new ServiceMock ()) {
                mocks.MockConfigService (3, 7, 8);
                EntryValidation validator = new EntryValidation ();
                Assert.IsFalse (validator.ValidateEntryNumericAndInMinMaxBounds ("1"));
            }
        }

        [Test]
        public void ValidateEntryNumericAndInMinMaxBounds_AboveMaxValue () {
            using (ServiceMock mocks = new ServiceMock ()) {
                mocks.MockConfigService (3, 4, 8);
                EntryValidation validator = new EntryValidation ();
                Assert.IsFalse (validator.ValidateEntryNumericAndInMinMaxBounds ("9"));
            }
        }

        [Test]
        public void ValidateEntryNumericAndInMinMaxBounds_ValueJustRight () {
            using (ServiceMock mocks = new ServiceMock ()) {
                mocks.MockConfigService (3, 4, 4);
                EntryValidation validator = new EntryValidation ();
                Assert.IsTrue (validator.ValidateEntryNumericAndInMinMaxBounds ("4"));
            }
        }
    }
}