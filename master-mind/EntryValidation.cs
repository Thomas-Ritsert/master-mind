using System;
using dependency_injection;
using master_mind.Interfaces;

namespace master_mind {
    public class EntryValidation {
        private IConfigProvider config = ServiceProvider.GetService<IConfigProvider> ();

        public bool ValidateEntryLength (String entry) {
            if (entry.Length != config.CODE_LENGTH) {
                return false;
            }
            return true;
        }

        public bool ValidateEntryNumericAndInMinMaxBounds (string entry) {
            foreach (char character in entry) {
                var value = Char.GetNumericValue (character);
                if (value < config.CODE_MIN_VALUE || value > config.CODE_MAX_VALUE) {
                    return false;
                }
            }
            return true;
        }
    }
}