using System;
using System.Collections.Generic;
using dependency_injection;
using Moq;

namespace mastermind.tests {
    public sealed class ServiceMock : IDisposable {
        private readonly Dictionary<Type, object> previouslyRegisteredProviders = new Dictionary<Type, object> ();

        public void MockService<T> (T instance = null) where T : class {
            Type t = typeof (T);

            if (previouslyRegisteredProviders.ContainsKey (t)) {
                throw new Exception ($"A service of type {t} has already been mocked.");
            }

            object original = ServiceProvider.GetService<T> ();
            if (original != null) {
                previouslyRegisteredProviders.Add (t, original);
            }

            if (instance == null) {
                T serviceMock = new Mock<T> ().Object;
                ServiceProvider.RegisterService (serviceMock);
            }

            ServiceProvider.RegisterService (instance);
        }

        public void Dispose () {
            foreach (KeyValuePair<Type, object> previouslyRegisteredProvider in previouslyRegisteredProviders) {
                ServiceProvider.RegisterService (previouslyRegisteredProvider.Key, previouslyRegisteredProvider.Value);
            }
        }
    }
}