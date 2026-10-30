namespace Unity.Services.Authentication;

internal class AuthenticationPackageInitializer : IInitializablePackageV2, IInitializablePackage
{
	private const string k_CloudEnvironmentKey = "com.unity.services.core.cloud-environment"; //Field offset: 0x0
	private const string k_StagingEnvironment = "staging"; //Field offset: 0x0
	private const string k_DefaultProfile = "default"; //Field offset: 0x0
	private const string k_EditorModeArg = "-editor-mode"; //Field offset: 0x0
	private const string k_NameArg = "-name"; //Field offset: 0x0

	public AuthenticationPackageInitializer() { }

	private string GetPlayerAuthHost(IProjectConfiguration projectConfiguration) { }

	private string GetPlayerNamesHost(IProjectConfiguration projectConfiguration) { }

	private string GetProfile(IProjectConfiguration projectConfiguration) { }

	public override Task Initialize(CoreRegistry registry) { }

	public override Task InitializeInstanceAsync(CoreRegistry registry) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void InitializeOnLoad() { }

	private AuthenticationServiceInternal InitializeService(CoreRegistry registry) { }

	public override void Register(CorePackageRegistry registry) { }

}

