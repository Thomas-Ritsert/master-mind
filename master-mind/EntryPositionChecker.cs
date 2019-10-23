using System;
using dependency_injection;
using master_mind.Interfaces;
using master_mind.Objects;

namespace master_mind {
    public class EntryPositionChecker {

        private IConfigProvider config = ServiceProvider.GetService<IConfigProvider> ();

        public string CheckEntry (SecretCode code, string entry) {
            string result = string.Empty;
            for (int i = 0; i < code.Values.Length; i++) {
                double entryValue = Char.GetNumericValue (entry[i]);
                if (code.Values[i] == entryValue) {
                    result += config.CORRECT_POSITION;
                } else {
                    result += EntryInCode (code, entryValue) ? config.WRONG_POSITION.ToString () : string.Empty;
                }
            }
            return result;
        }

        public bool EntryInCode (SecretCode code, double entry) {
            return Array.Exists (code.Values, value => value == entry);
        }
    }
}