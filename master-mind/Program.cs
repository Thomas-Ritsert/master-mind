using System;
using dependency_injection;
using master_mind.Config;
using master_mind.Interfaces;

namespace master_mind {

    class Program {

        static void Main (string[] args) {
            RegisterServices ();
            IConfigProvider config = ServiceProvider.GetService<IConfigProvider> ();
            InitializeGame init = new InitializeGame ();
            Game game = new Game ();
            bool playGame = true;
            do {
                game.Run (init.InitializeSecretCode ());
                Console.WriteLine (config.PLAY_AGAIN_MESSAGE);
                playGame = Console.ReadKey ().KeyChar == 'y';
            } while (playGame);
        }

        private static void ManagePostGame () {

        }

        private static void RegisterServices () {
            ServiceProvider.RegisterService<IConfigProvider> (new ConfigProvider ());
            ServiceProvider.RegisterService<IConsoleManager> (new ConsoleManager ());
        }
    }
}