namespace Unity.Services.Authentication.PlayerAccounts;

internal class PlayerAccountsPackageInitializer : IInitializablePackageV2, IInitializablePackage
{

	public PlayerAccountsPackageInitializer() { }

	public override Task Initialize(CoreRegistry registry) { }

	public override Task InitializeInstanceAsync(CoreRegistry registry) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void InitializeOnLoad() { }

	private PlayerAccountServiceInternal InitializeService(CoreRegistry registry) { }

	public override void Register(CorePackageRegistry registry) { }

}

