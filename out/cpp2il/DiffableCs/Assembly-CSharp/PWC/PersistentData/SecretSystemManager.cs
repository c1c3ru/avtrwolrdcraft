namespace PWC.PersistentData;

public static class SecretSystemManager
{
	[CompilerGenerated]
	private static Action<LevelType, SecretData> OnSecretSolvedAction; //Field offset: 0x0
	private const string SECRETS_TABLE_KEY_PREFIX = "SECRETS_TABLE"; //Field offset: 0x0

	public static event Action<LevelType, SecretData> OnSecretSolvedAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	[CompilerGenerated]
	public static void add_OnSecretSolvedAction(Action<LevelType, SecretData> value) { }

	public static bool CheckIsSolved(LevelType levelType, int secretId, out string extraData) { }

	private static string GetSecretTableKey(LevelType levelType, int id) { }

	[CompilerGenerated]
	public static void remove_OnSecretSolvedAction(Action<LevelType, SecretData> value) { }

	public static void RemoveSolvedSecret(LevelType levelType, int secretId) { }

	public static void UpdateSolvedSecret(LevelType levelType, int secretId, string extraData = "", bool notifyOnResolve = false) { }

}

