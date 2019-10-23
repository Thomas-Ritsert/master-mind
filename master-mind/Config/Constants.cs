namespace master_mind.Config {
    public static class Constants {
        public static class Code {
            public const int CODE_LENGTH = 4;
            public const int CODE_MIN_VALUE = 1;
            public const int CODE_MAX_VALUE = 6;
        }

        public static class GamePlay {
            public const int NUMBER_OF_GUESSES = 10;
            public const char WRONG_POSITION = '-';
            public const char CORRECT_POSITION = '+';
            public const string GAME_OVER_MESSAGE = "Sadly you have failed to crack the code.";
            public const string VICTORY_MESSAGE = "Victory! You have cracked the code!";
            public const string PLAY_AGAIN_MESSAGE = "Enter \"y\" to play again or anything else to quit:";
            public static string CODE_HINT = $"The secret code is {Code.CODE_LENGTH} digits long.  Please enter your combination:";
            public static string PLAYER_ENTRY_WRONG_LENGTH = $"Invalid entry. {CODE_HINT}";
            public static string PLAYER_ENTRY_NOT_NUMERIC = $"The secret code consists of only numbers between {Code.CODE_MIN_VALUE} and {Code.CODE_MAX_VALUE}. Please enter your combination:";
        }
    }
}