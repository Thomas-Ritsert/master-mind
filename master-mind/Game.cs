using System;
using dependency_injection;
using master_mind.Interfaces;
using master_mind.Objects;

namespace master_mind {
    public class Game {

        private EntryValidation validator = new EntryValidation ();
        private EntryPositionChecker positionChecker = new EntryPositionChecker ();
        private IConfigProvider config = ServiceProvider.GetService<IConfigProvider> ();
        private IConsoleManager consoleManager = ServiceProvider.GetService<IConsoleManager> ();
        public void Run (SecretCode code) {
            consoleManager.Clear ();
            consoleManager.WriteLine (config.CODE_HINT);
            for (int i = 0; i < config.NUMBER_OF_GUESSES; i++) {
                string playerEntry = consoleManager.ReadLine ();
                string errorMessage = ValidatePlayerEntry (playerEntry);
                if (errorMessage != null) {
                    i--;
                    consoleManager.WriteLine (errorMessage);
                    continue;
                }
                string result = positionChecker.CheckEntry (code, playerEntry);
                if (result.CheckForVictory (config.CODE_LENGTH, config.CORRECT_POSITION)) {
                    consoleManager.WriteLine (config.VICTORY_MESSAGE);
                    return;
                } else {
                    consoleManager.WriteLine (result);
                }
            }
            consoleManager.WriteLine (config.GAME_OVER_MESSAGE);
        }

        private string ValidatePlayerEntry (String entry) {
            if (!validator.ValidateEntryLength (entry)) {
                return config.PLAYER_ENTRY_WRONG_LENGTH;
            }

            if (!validator.ValidateEntryNumericAndInMinMaxBounds (entry)) {
                return config.PLAYER_ENTRY_NOT_NUMERIC;
            }
            return null;
        }
    }
}