using System;
using dependency_injection;
using master_mind.Interfaces;
using master_mind.Objects;

namespace master_mind {
    public class InitializeGame {
        private static Random randomizer = new Random ();
        private IConfigProvider config = ServiceProvider.GetService<IConfigProvider> ();
        public SecretCode InitializeSecretCode () => new SecretCode (GenerateCode ());

        private int[] GenerateCode () {
            int[] values = new int[config.CODE_LENGTH];
            for (int i = 0; i < config.CODE_LENGTH; i++) {
                values[i] = randomizer.Next (config.CODE_MIN_VALUE, config.CODE_MAX_VALUE);
            }
            return values;
        }
    }
}