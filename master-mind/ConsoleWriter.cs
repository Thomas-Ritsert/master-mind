using System;
using master_mind.Interfaces;

namespace master_mind {
    public class ConsoleManager : IConsoleManager {
        public void Clear () {
            Console.Clear ();
        }

        public string ReadLine () {
            return Console.ReadLine ();
        }

        public void WriteLine (string content) {
            Console.WriteLine (content);
        }
    }
}