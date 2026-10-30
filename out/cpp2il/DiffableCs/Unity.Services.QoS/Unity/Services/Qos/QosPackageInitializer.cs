namespace Unity.Services.Qos;

internal class QosPackageInitializer : IInitializablePackageV2, IInitializablePackage
{
	private const string k_CloudEnvironmentKey = "com.unity.services.core.cloud-environment"; //Field offset: 0x0
	private const string k_PackageName = "com.unity.services.qos"; //Field offset: 0x0
	private const string k_StagingEnvironment = "staging"; //Field offset: 0x0

	public QosPackageInitializer() { }

	private string GetHost(IProjectConfiguration projectConfiguration) { }

	public override Task Initialize(CoreRegistry registry) { }

	public override Task InitializeInstanceAsync(CoreRegistry registry) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	internal static void InitializeOnLoad() { }

	private IQosService InitializeService(CoreRegistry registry) { }

	public override void Register(CorePackageRegistry registry) { }

	internal void Register(CoreRegistry registry) { }

}

