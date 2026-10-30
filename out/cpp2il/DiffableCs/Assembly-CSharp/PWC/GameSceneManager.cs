namespace PWC;

public static class GameSceneManager
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public string sceneName; //Field offset: 0x10
		public bool considerMultiplayer; //Field offset: 0x18
		public string mp_nextSceneId; //Field offset: 0x20

		public <>c__DisplayClass28_0() { }

		internal void <LoadScene>b__0() { }

	}

	internal sealed class SceneOverrideDelegate : MulticastDelegate
	{

		public SceneOverrideDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(Scene scene, out string sceneNameOverride, AsyncCallback callback, object object) { }

		public override bool EndInvoke(out string sceneNameOverride, IAsyncResult result) { }

		public override bool Invoke(Scene scene, out string sceneNameOverride) { }

	}

	[CompilerGenerated]
	private static Action OnBeforeSceneLoadStage1Action; //Field offset: 0x0
	public const string PLAYER_PREFS_CURRENT_WORLD_KEY = "GAME_CURRENT_WORLD"; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnBeforeSceneLoadStage2Action; //Field offset: 0x8
	[CompilerGenerated]
	private static Action OnBeforeSceneLoadStage3Action; //Field offset: 0x10
	public static string CurrentSceneSuffix; //Field offset: 0x18
	public static string PreviousSceneName; //Field offset: 0x20
	public static string CurrentlyLoadingSceneName; //Field offset: 0x28
	[CompilerGenerated]
	private static bool <IsSceneChangingInProgress>k__BackingField; //Field offset: 0x30
	public static SceneOverrideDelegate TryOverrideSceneNameAction; //Field offset: 0x38
	[CompilerGenerated]
	private static string <Multiplayer_LoadingSceneNameInProgress>k__BackingField; //Field offset: 0x40
	private static HashSet<String> _availableSceneNames; //Field offset: 0x48

	public static event Action OnBeforeSceneLoadStage1Action
	{
		[CompilerGenerated]
		 add { } //Length: 216
		[CompilerGenerated]
		 remove { } //Length: 216
	}

	public static event Action OnBeforeSceneLoadStage2Action
	{
		[CompilerGenerated]
		 add { } //Length: 220
		[CompilerGenerated]
		 remove { } //Length: 220
	}

	public static event Action OnBeforeSceneLoadStage3Action
	{
		[CompilerGenerated]
		 add { } //Length: 220
		[CompilerGenerated]
		 remove { } //Length: 220
	}

	public private static bool IsSceneChangingInProgress
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	public static string Multiplayer_LoadingSceneNameInProgress
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		 set { } //Length: 96
	}

	private static GameSceneManager() { }

	[CompilerGenerated]
	public static void add_OnBeforeSceneLoadStage1Action(Action value) { }

	[CompilerGenerated]
	public static void add_OnBeforeSceneLoadStage2Action(Action value) { }

	[CompilerGenerated]
	public static void add_OnBeforeSceneLoadStage3Action(Action value) { }

	public static void CancelCurrentSceneChangingProgress() { }

	public static string CreateSceneId(string sceneName, string suffix) { }

	[CompilerGenerated]
	public static bool get_IsSceneChangingInProgress() { }

	[CompilerGenerated]
	public static string get_Multiplayer_LoadingSceneNameInProgress() { }

	public static string GetActiveSceneId() { }

	public static string GetActiveSceneName() { }

	public static string GetCurrentWorldSceneName() { }

	public static string GetSceneIdFromScene(Scene scene) { }

	public static string GetSceneIdFromSceneName(string sceneName) { }

	public static string GetSceneIdOfGameObject(GameObject gameObject) { }

	public static bool IsSceneAvailable(string sceneName) { }

	public static void LoadScene(string sceneName, bool considerMultiplayer = true, string mp_nextSceneId = null) { }

	public static void LoadSceneAndUpdateZoneScene(string sceneName, bool considerMultiplayer = true) { }

	public static void LoadSceneImplement(string sceneName) { }

	private static void OnActiveSceneChanged(Scene scene1, Scene scene2) { }

	public static void ReloadCurrentScene() { }

	[CompilerGenerated]
	public static void remove_OnBeforeSceneLoadStage1Action(Action value) { }

	[CompilerGenerated]
	public static void remove_OnBeforeSceneLoadStage2Action(Action value) { }

	[CompilerGenerated]
	public static void remove_OnBeforeSceneLoadStage3Action(Action value) { }

	[CompilerGenerated]
	private static void set_IsSceneChangingInProgress(bool value) { }

	[CompilerGenerated]
	public static void set_Multiplayer_LoadingSceneNameInProgress(string value) { }

	public static void SetCurrentWorldSceneName(string worldSceneName) { }

}

