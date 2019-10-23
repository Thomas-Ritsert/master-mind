using dependency_injection;
using master_mind.Config;
using NUnit.Framework;

[SetUpFixture]
public class PreTestSetup {

    [OneTimeSetUp]
    public void RunBeforeAnyTests () {
        ServiceProvider.RegisterService (new ConfigProvider ());
    }
}