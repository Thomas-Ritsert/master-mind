using System;
using NUnit.Framework;

namespace dependency_injection.test {
    public class ServiceProvider_Tests {

        [Test]
        public void RegisterServiceThrowsArgumentNullException () {
            Assert.Throws (typeof (ArgumentNullException), () => ServiceProvider.RegisterService (typeof (ServiceException), null));
            Assert.Throws (typeof (ArgumentNullException), () => ServiceProvider.RegisterService<ServiceException> (null));
        }

        [Test]
        public void CanRetrieveRegisteredService () {
            var exception = new ServiceException (Faker.Lorem.Paragraph ());
            ServiceProvider.RegisterService (exception);
            var returnedException = ServiceProvider.GetService<ServiceException> ();
            Assert.AreEqual (exception, returnedException);
        }
    }
}