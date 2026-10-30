namespace Unity.Services.Wire.Internal;

internal class WireServiceProvider : IInitializablePackageV2, IInitializablePackage
{
	[CompilerGenerated]
	private struct <InitializeComponent>d__6 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public CoreRegistry registry; //Field offset: 0x20
		public WireServiceProvider <>4__this; //Field offset: 0x28
		private Client <client>5__2; //Field offset: 0x30
		private TaskAwaiter <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private const string k_CloudEnvironmentKey = "com.unity.services.core.cloud-environment"; //Field offset: 0x0
	private const string k_StagingEnvironment = "staging"; //Field offset: 0x0

	public WireServiceProvider() { }

	internal Configuration GetConfiguration(IAccessToken token, IProjectConfiguration projectCfg) { }

	public override Task Initialize(CoreRegistry registry) { }

	[AsyncStateMachine(typeof(<InitializeComponent>d__6))]
	private Task InitializeComponent(CoreRegistry registry) { }

	public override Task InitializeInstanceAsync(CoreRegistry registry) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void InitializeOnLoad() { }

	public override void Register(CorePackageRegistry registry) { }

}

