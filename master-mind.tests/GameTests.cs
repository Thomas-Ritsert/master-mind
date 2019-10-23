using System.Collections.Generic;
using master_mind;
using master_mind.Config;
using master_mind.Interfaces;
using master_mind.Objects;
using Moq;
using NUnit.Framework;

namespace mastermind.tests {
    public class GameTests {
        private SecretCode code = new SecretCode (new int[] { 1, 2, 3, 4 });

        [Test]
        public void RunClearsConsole_HappyPath () {
            using (ServiceMock mocks = new ServiceMock ()) {
                mocks.MockConfigService (4, 1, 6);
                var consoleMock = new Mock<IConsoleManager> ();
                consoleMock.Setup (p => p.Clear ()).Verifiable ();
                consoleMock.Setup (p => p.ReadLine ()).Returns ("1234");
                mocks.MockService<IConsoleManager> (consoleMock.Object);

                Game game = new Game ();
                game.Run (code);
                consoleMock.Verify (foo => foo.Clear ());
                consoleMock.Verify (foo => foo.WriteLine (Constants.GamePlay.CODE_HINT));
                consoleMock.Verify (foo => foo.WriteLine (Constants.GamePlay.VICTORY_MESSAGE));
            }
        }

        [Test]
        public void RunClearsConsole_InputValidationHookedUp () {
            using (ServiceMock mocks = new ServiceMock ()) {
                mocks.MockConfigService (4, 1, 6);
                var consoleMock = new Mock<IConsoleManager> ();
                consoleMock.Setup (p => p.Clear ()).Verifiable ();
                consoleMock.Setup (p => p.ReadLine ()).Returns (new Queue<string> (new [] {
                    "Bacon",
                    "9999",
                    "1234"
                }).Dequeue);
                mocks.MockService<IConsoleManager> (consoleMock.Object);

                Game game = new Game ();
                game.Run (code);
                consoleMock.Verify (foo => foo.Clear ());
                consoleMock.Verify (foo => foo.WriteLine (Constants.GamePlay.CODE_HINT));
                consoleMock.Verify (foo => foo.WriteLine (Constants.GamePlay.PLAYER_ENTRY_WRONG_LENGTH));
                consoleMock.Verify (foo => foo.WriteLine (Constants.GamePlay.PLAYER_ENTRY_NOT_NUMERIC));
                consoleMock.Verify (foo => foo.WriteLine (Constants.GamePlay.VICTORY_MESSAGE));
            }
        }

        [Test]
        public void RunClearsConsole_PoitionEntryHookedUp () {
            using (ServiceMock mocks = new ServiceMock ()) {
                mocks.MockConfigService (4, 1, 6);
                var consoleMock = new Mock<IConsoleManager> ();
                consoleMock.Setup (p => p.Clear ()).Verifiable ();
                consoleMock.Setup (p => p.ReadLine ()).Returns (new Queue<string> (new [] {
                    "1253",
                    "1355",
                    "1235",
                    "1234"
                }).Dequeue);
                mocks.MockService<IConsoleManager> (consoleMock.Object);

                Game game = new Game ();
                game.Run (code);
                consoleMock.Verify (foo => foo.Clear ());
                consoleMock.Verify (foo => foo.WriteLine (Constants.GamePlay.CODE_HINT));
                consoleMock.Verify (foo => foo.WriteLine ("++-"));
                consoleMock.Verify (foo => foo.WriteLine ("+-"));
                consoleMock.Verify (foo => foo.WriteLine ("+++"));
                consoleMock.Verify (foo => foo.WriteLine (Constants.GamePlay.VICTORY_MESSAGE));
            }
        }
    }
}