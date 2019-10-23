using System;
using System.Collections.Generic;

namespace dependency_injection {
    internal static class ServiceStore {
        private static readonly Dictionary<Type, object> services = new Dictionary<Type, object> ();

        public static void RegisterService (Type type, object service) {
            services[type] = service;
        }

        public static object GetService (Type type) {
            if (type == null) {
                throw new ArgumentNullException (nameof (type));
            }
            object service;
            if (services.TryGetValue (type, out service)) {
                return service;
            }
            return null;
        }
    }
}