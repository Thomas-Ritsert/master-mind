using master_mind.Config;
using master_mind.Interfaces;
using Moq;

namespace mastermind.tests {
    public static class ServiceMockExtensionsMethods {
        public static void MockConfigService (this ServiceMock mocks,
            int codeSize,
            int minValue = 0,
            int maxValue = 0,
            char correctPosition = '+',
            char wrongPosition = '-') {
            var configProviderMock = new Mock<ConfigProvider> ();
            configProviderMock.SetupGet (_ => _.CODE_MIN_VALUE).Returns (minValue);
            configProviderMock.SetupGet (_ => _.CODE_MAX_VALUE).Returns (maxValue);
            configProviderMock.SetupGet (_ => _.CODE_LENGTH).Returns (codeSize);
            configProviderMock.SetupGet (_ => _.CORRECT_POSITION).Returns (correctPosition);
            configProviderMock.SetupGet (_ => _.WRONG_POSITION).Returns (wrongPosition);
            configProviderMock.SetupGet (_ => _.NUMBER_OF_GUESSES).Returns (Constants.GamePlay.NUMBER_OF_GUESSES);
            configProviderMock.SetupGet (_ => _.GAME_OVER_MESSAGE).Returns (Constants.GamePlay.GAME_OVER_MESSAGE);
            configProviderMock.SetupGet (_ => _.VICTORY_MESSAGE).Returns (Constants.GamePlay.VICTORY_MESSAGE);
            configProviderMock.SetupGet (_ => _.PLAY_AGAIN_MESSAGE).Returns (Constants.GamePlay.PLAY_AGAIN_MESSAGE);
            configProviderMock.SetupGet (_ => _.CODE_HINT).Returns (Constants.GamePlay.CODE_HINT);
            configProviderMock.SetupGet (_ => _.PLAYER_ENTRY_NOT_NUMERIC).Returns (Constants.GamePlay.PLAYER_ENTRY_NOT_NUMERIC);
            configProviderMock.SetupGet (_ => _.PLAYER_ENTRY_WRONG_LENGTH).Returns (Constants.GamePlay.PLAYER_ENTRY_WRONG_LENGTH);

            mocks.MockService<IConfigProvider> (configProviderMock.Object);
        }
    }
}