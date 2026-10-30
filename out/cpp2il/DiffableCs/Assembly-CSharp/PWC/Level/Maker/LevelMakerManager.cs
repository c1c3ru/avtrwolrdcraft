namespace PWC.Level.Maker;

public class LevelMakerManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelMakerItem> <>9__15_1; //Field offset: 0x8
		public static Action <>9__15_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <OnPrefabRuntimeSpawn>b__15_0() { }

		internal bool <OnPrefabRuntimeSpawn>b__15_1(LevelMakerItem item) { }

	}

	private const int MAX_ITEMS = 1500; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<Boolean> OnMakerModeChangedAction; //Field offset: 0x0
	[CompilerGenerated]
	private static LevelMakerManager <Instance>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private bool <IsInMakerMode>k__BackingField; //Field offset: 0x20

	public static event Action<Boolean> OnMakerModeChangedAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public private static LevelMakerManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private bool IsInMakerMode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public LevelMakerManager() { }

	[CompilerGenerated]
	public static void add_OnMakerModeChangedAction(Action<Boolean> value) { }

	private void Awake() { }

	[CompilerGenerated]
	public static LevelMakerManager get_Instance() { }

	[CompilerGenerated]
	public bool get_IsInMakerMode() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnPrefabRuntimeSpawn(PDPrefab instance, bool _) { }

	[CompilerGenerated]
	public static void remove_OnMakerModeChangedAction(Action<Boolean> value) { }

	[CompilerGenerated]
	private static void set_Instance(LevelMakerManager value) { }

	[CompilerGenerated]
	private void set_IsInMakerMode(bool value) { }

	public void SetMakerMode(bool isMakerMode) { }

	public void ToggleMakerMode() { }

	public bool TryGetFirstBadPositionedItem(out LevelMakerItemWithArea resultItem) { }

	public bool TryHandleItemsInBadPosition() { }

}

