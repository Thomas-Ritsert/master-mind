using System;

namespace dependency_injection {
    public class ServiceException : Exception {
        public ServiceException () { }

        public ServiceException (string message) : base (message) { }

        public ServiceException (string message, Exception inner) : base (message, inner) { }
    }
}