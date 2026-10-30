namespace PWC.Level;

public static class LevelUpgradeTracker
{
	internal sealed class FillDisposableOnLevelResetSceneGuidsDelegate : MulticastDelegate
	{

		public FillDisposableOnLevelResetSceneGuidsDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(HashSet<String> sceneGuids, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(HashSet<String> sceneGuids) { }

	}

	private static string _lastApprovedSceneName; //Field offset: 0x0
	private const string RESET_LEVEL_BY_USER = "PWC_ResetLevelByUser_"; //Field offset: 0x0
	[CompilerGenerated]
	private static FillDisposableOnLevelResetSceneGuidsDelegate FillDisposableOnLevelResetSceneGuidsAction; //Field offset: 0x8
	[CompilerGenerated]
	private static FillDisposableOnLevelResetSceneGuidsDelegate FillDisposablePrefabGuidsOnLevelResetAction; //Field offset: 0x10
	[CompilerGenerated]
	private static FillDisposableOnLevelResetSceneGuidsDelegate FillDisposableSkinsOnLevelResetAction; //Field offset: 0x18
	[CompilerGenerated]
	private static Func<Vector3> OverrideBoxPosition; //Field offset: 0x20
	[CompilerGenerated]
	private static Func<Boolean> OverrideKeepItems; //Field offset: 0x28
	[CompilerGenerated]
	private static Action OnBeforeResetCurrentLevelAction; //Field offset: 0x30
	public static bool IsResetting; //Field offset: 0x38
	public static bool SkipResetForCurrentLoad; //Field offset: 0x39

	public static event FillDisposableOnLevelResetSceneGuidsDelegate FillDisposableOnLevelResetSceneGuidsAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public static event FillDisposableOnLevelResetSceneGuidsDelegate FillDisposablePrefabGuidsOnLevelResetAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public static event FillDisposableOnLevelResetSceneGuidsDelegate FillDisposableSkinsOnLevelResetAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public static event Action OnBeforeResetCurrentLevelAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public static event Func<Vector3> OverrideBoxPosition
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Func<Boolean> OverrideKeepItems
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	[CompilerGenerated]
	public static void add_FillDisposableOnLevelResetSceneGuidsAction(FillDisposableOnLevelResetSceneGuidsDelegate value) { }

	[CompilerGenerated]
	public static void add_FillDisposablePrefabGuidsOnLevelResetAction(FillDisposableOnLevelResetSceneGuidsDelegate value) { }

	[CompilerGenerated]
	public static void add_FillDisposableSkinsOnLevelResetAction(FillDisposableOnLevelResetSceneGuidsDelegate value) { }

	[CompilerGenerated]
	public static void add_OnBeforeResetCurrentLevelAction(Action value) { }

	[CompilerGenerated]
	public static void add_OverrideBoxPosition(Func<Vector3> value) { }

	[CompilerGenerated]
	public static void add_OverrideKeepItems(Func<Boolean> value) { }

	public static void ClearTrackingForCurrentScene() { }

	public static void DeleteMarkSceneForResetByUser() { }

	private static string GetBulkDataKeyForLevelReset() { }

	private static string GetResetLevelByUserKey(string sceneName) { }

	private static bool IsLevelItemRootAndNotUnderAvatar(Transform child) { }

	public static void MarkSceneForResetByUser(string sceneName) { }

	[CompilerGenerated]
	public static void remove_FillDisposableOnLevelResetSceneGuidsAction(FillDisposableOnLevelResetSceneGuidsDelegate value) { }

	[CompilerGenerated]
	public static void remove_FillDisposablePrefabGuidsOnLevelResetAction(FillDisposableOnLevelResetSceneGuidsDelegate value) { }

	[CompilerGenerated]
	public static void remove_FillDisposableSkinsOnLevelResetAction(FillDisposableOnLevelResetSceneGuidsDelegate value) { }

	[CompilerGenerated]
	public static void remove_OnBeforeResetCurrentLevelAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OverrideBoxPosition(Func<Vector3> value) { }

	[CompilerGenerated]
	public static void remove_OverrideKeepItems(Func<Boolean> value) { }

	public static void ResetCurrentLevelPD() { }

	public static bool ShouldResetCurrentLevelPD() { }

	public static void TryLoadBulkDataPostLevelReset() { }

}

