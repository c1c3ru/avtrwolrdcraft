namespace PWC.QA.RTA;

public static class RTAGameUtils
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Button, Boolean> <>9__8_1; //Field offset: 0x8
		public static Func<Boolean> <>9__11_1; //Field offset: 0x10
		public static Func<GameObject, String> <>9__14_0; //Field offset: 0x18
		public static Func<GameObject, String> <>9__14_1; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal string <PerformResourceCheck>b__14_0(GameObject go) { }

		internal string <PerformResourceCheck>b__14_1(GameObject p) { }

		internal bool <TryClickBackButtonAsync>b__8_1(Button b) { }

		internal bool <WaitUntilSceneLoadedAsync_Internal>b__11_1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public String[] sceneNames; //Field offset: 0x10
		public bool checkIfActive; //Field offset: 0x18

		public <>c__DisplayClass11_0() { }

		internal bool <WaitUntilSceneLoadedAsync_Internal>b__0() { }

	}

	[CompilerGenerated]
	private struct <LoadSceneAsync>d__7 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<String> <>t__builder; //Field offset: 0x8
		public string sceneName; //Field offset: 0x20
		private TaskAwaiter<String> <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <ResetWorld>d__13 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		private TaskAwaiter<String> <>u__1; //Field offset: 0x20

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <TryClickBackButtonAsync>d__8 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<String> <>t__builder; //Field offset: 0x8
		public bool waitForWorldScene; //Field offset: 0x20
		private TaskAwaiter<Boolean> <>u__1; //Field offset: 0x28
		private TaskAwaiter<String> <>u__2; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <WaitUntilSceneLoadedAsync_Internal>d__11 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Boolean> <>t__builder; //Field offset: 0x8
		public String[] sceneNames; //Field offset: 0x20
		public bool checkIfActive; //Field offset: 0x28
		private TaskAwaiter<Boolean> <>u__1; //Field offset: 0x30
		private TaskAwaiter <>u__2; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <WaitUntilScenesLoadedAsync>d__10 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<String> <>t__builder; //Field offset: 0x8
		public String[] sceneNames; //Field offset: 0x20
		private string <sceneNamesString>5__2; //Field offset: 0x28
		private TaskAwaiter<Boolean> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <WaitUntilSceneUnloadedAsync>d__9 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<String> <>t__builder; //Field offset: 0x8
		public String[] sceneNames; //Field offset: 0x20
		private string <sceneNamesString>5__2; //Field offset: 0x28
		private TaskAwaiter<Boolean> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private const float TIMEOUT_SEC = 3; //Field offset: 0x0
	private const float SCENE_LOAD_DELAY_SEC = 0,1; //Field offset: 0x0
	private static MonoBehaviour _backButton; //Field offset: 0x0
	private static HashSet<String> _scenesToLoadWithBackButton; //Field offset: 0x8
	private static HashSet<String> _prefabsNamesToIgnoreInResourceCheck; //Field offset: 0x10

	private static RTAGameUtils() { }

	[CompilerGenerated]
	internal static void <ResetWorld>g__DeleteUserData|13_0() { }

	[CompilerGenerated]
	internal static void <ResetWorld>g__DisableFTUE|13_1() { }

	[CompilerGenerated]
	internal static void <ResetWorld>g__DisablePromotionPopUp|13_3() { }

	[CompilerGenerated]
	internal static void <ResetWorld>g__DisableRateUs|13_2() { }

	[CompilerGenerated]
	internal static bool <TryClickBackButtonAsync>g__IsBackButtonSet|8_0() { }

	public static HashSet<String> GetAllWorldTypesSceneNames() { }

	public static string GetCurrentWorldSceneName() { }

	public static bool IsSceneLoaded(IEnumerable<String> sceneNames, bool checkIfActive = true) { }

	[AsyncStateMachine(typeof(<LoadSceneAsync>d__7))]
	public static Task<String> LoadSceneAsync(string sceneName) { }

	public static string PerformResourceCheck(string resourcesPath) { }

	[AsyncStateMachine(typeof(<ResetWorld>d__13))]
	public static Task ResetWorld() { }

	[AsyncStateMachine(typeof(<TryClickBackButtonAsync>d__8))]
	public static Task<String> TryClickBackButtonAsync(bool waitForWorldScene = true) { }

	[AsyncStateMachine(typeof(<WaitUntilSceneLoadedAsync_Internal>d__11))]
	private static Task<Boolean> WaitUntilSceneLoadedAsync_Internal(String[] sceneNames, bool checkIfActive) { }

	[AsyncStateMachine(typeof(<WaitUntilScenesLoadedAsync>d__10))]
	public static Task<String> WaitUntilScenesLoadedAsync(String[] sceneNames) { }

	[AsyncStateMachine(typeof(<WaitUntilSceneUnloadedAsync>d__9))]
	public static Task<String> WaitUntilSceneUnloadedAsync(String[] sceneNames) { }

}

