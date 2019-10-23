namespace master_mind.Interfaces {
    public interface IGamePlayConfig {
        int NUMBER_OF_GUESSES { get; }
        char WRONG_POSITION { get; }
        char CORRECT_POSITION { get; }
        string GAME_OVER_MESSAGE { get; }
        string VICTORY_MESSAGE { get; }
        string PLAY_AGAIN_MESSAGE { get; }
        string CODE_HINT { get; }
        string PLAYER_ENTRY_WRONG_LENGTH { get; }
        string PLAYER_ENTRY_NOT_NUMERIC { get; }
    }
}