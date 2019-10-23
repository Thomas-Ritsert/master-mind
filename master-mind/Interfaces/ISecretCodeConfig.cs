namespace master_mind.Interfaces {
    public interface ISecretCodeConfig {
        int CODE_LENGTH { get; }
        int CODE_MIN_VALUE { get; }
        int CODE_MAX_VALUE { get; }
    }
}