namespace Unity.Services.Relay;

internal class RelayServiceProvider : IInitializablePackage
{

	public RelayServiceProvider() { }

	public override Task Initialize(CoreRegistry registry) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void Register() { }

}

