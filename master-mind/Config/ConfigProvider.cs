using master_mind.Interfaces;

namespace master_mind.Config {

    public class ConfigProvider : IConfigProvider {
        public virtual int CODE_LENGTH { get { return Constants.Code.CODE_LENGTH; } }
        public virtual int CODE_MIN_VALUE { get { return Constants.Code.CODE_MIN_VALUE; } }
        public virtual int CODE_MAX_VALUE { get { return Constants.Code.CODE_MAX_VALUE; } }
        public virtual int NUMBER_OF_GUESSES { get { return Constants.GamePlay.NUMBER_OF_GUESSES; } }
        public virtual char WRONG_POSITION { get { return Constants.GamePlay.WRONG_POSITION; } }
        public virtual char CORRECT_POSITION { get { return Constants.GamePlay.CORRECT_POSITION; } }
        public virtual string GAME_OVER_MESSAGE { get { return Constants.GamePlay.GAME_OVER_MESSAGE; } }
        public virtual string VICTORY_MESSAGE { get { return Constants.GamePlay.VICTORY_MESSAGE; } }
        public virtual string PLAY_AGAIN_MESSAGE { get { return Constants.GamePlay.PLAY_AGAIN_MESSAGE; } }
        public virtual string CODE_HINT { get { return Constants.GamePlay.CODE_HINT; } }
        public virtual string PLAYER_ENTRY_WRONG_LENGTH { get { return Constants.GamePlay.PLAYER_ENTRY_WRONG_LENGTH; } }
        public virtual string PLAYER_ENTRY_NOT_NUMERIC { get { return Constants.GamePlay.PLAYER_ENTRY_NOT_NUMERIC; } }
    }
}