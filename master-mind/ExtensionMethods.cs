using System.Linq;

namespace master_mind {
    public static class ExtensionMethods {
        public static bool CheckForVictory (this string result, int codeLength, char correctPossitionCharacter) {
            return result.Length == codeLength && result.All (character => character == correctPossitionCharacter);
        }
    }
}