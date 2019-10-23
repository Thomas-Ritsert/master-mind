using Faker;
using master_mind;
using master_mind.Config;
using master_mind.Interfaces;
using master_mind.Objects;
using Moq;
using NUnit.Framework;

namespace mastermind.tests {
    public class InitializeGameTests {

        [Test]
        public void TestCodeBounds () {
            using (ServiceMock mocks = new ServiceMock ()) {
                int min = RandomNumber.Next (1, 900);
                int max = min + RandomNumber.Next (9000, 999999);
                int length = 2000;
                mocks.MockConfigService (length, min, max);

                InitializeGame sut = new InitializeGame ();
                SecretCode code = sut.InitializeSecretCode ();
                for (int i = 0; i < length; i++) {
                    Assert.LessOrEqual (code.Values[i], max);
                    Assert.GreaterOrEqual (code.Values[i], min);
                }
            }
        }

        [Test]
        public void TestCodeLength () {
            using (ServiceMock mocks = new ServiceMock ()) {
                int length = Faker.RandomNumber.Next (1, 9999);
                mocks.MockConfigService (length);

                InitializeGame sut = new InitializeGame ();
                SecretCode code = sut.InitializeSecretCode ();
                Assert.AreEqual (length, code.Values.Length);
            }
        }
    }
}