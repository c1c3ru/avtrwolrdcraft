namespace Unity.Services.Lobbies;

internal class LobbyServiceProvider : IInitializablePackage
{
	private const string k_PackageName = "com.unity.services.lobby"; //Field offset: 0x0

	public LobbyServiceProvider() { }

	public override Task Initialize(CoreRegistry registry) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void Register() { }

}

