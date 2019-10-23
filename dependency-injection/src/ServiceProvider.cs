using System;

namespace dependency_injection {

    public static class ServiceProvider {

        public static void RegisterService (Type type, object service) {
            if (service == null) {
                throw new ArgumentNullException (nameof (service));
            }
            ServiceStore.RegisterService (type, service);
        }

        public static void RegisterService<T> (T service) where T : class {
            if (service == null) {
                throw new ArgumentNullException (nameof (service));
            }
            ServiceStore.RegisterService (typeof (T), service);
        }

        public static T GetService<T> () where T : class {
            object service = ServiceStore.GetService (typeof (T));
            return (T) service;
        }
    }
}