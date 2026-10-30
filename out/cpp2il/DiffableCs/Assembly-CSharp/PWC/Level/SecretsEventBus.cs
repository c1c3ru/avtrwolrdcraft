namespace PWC.Level;

public static class SecretsEventBus
{
	public static Action<String, Int32[]> SecretSolvedAction; //Field offset: 0x0
	public static Action<String> SecretUnsolvedAction; //Field offset: 0x8

	public static void SolveSecret(string label, Int32[] numbersInSequence) { }

	public static void UnsolveSecret(string label) { }

}

