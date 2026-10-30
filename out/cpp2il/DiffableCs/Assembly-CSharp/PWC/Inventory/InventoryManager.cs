namespace PWC.Inventory;

public class InventoryManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public InventoryManager <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <Start>d__16(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	public const string FILE_NAME = "PWCInventory"; //Field offset: 0x0
	public static readonly bool IsInventoryActive; //Field offset: 0x0
	[CompilerGenerated]
	private static InventoryManager <Instance>k__BackingField; //Field offset: 0x8
	[SerializeField]
	private InventoryBuildData _buildData; //Field offset: 0x20
	private InventoryData _currentData; //Field offset: 0x28
	private readonly HashSet<String> _actualItemsPrefabGuids; //Field offset: 0x30
	[CompilerGenerated]
	private InventoryItemsTracker <ItemsTracker>k__BackingField; //Field offset: 0x38

	public InventoryData CurrentData
	{
		 get { } //Length: 8
	}

	public private static InventoryManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	public private InventoryItemsTracker ItemsTracker
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private static InventoryManager() { }

	public InventoryManager() { }

	public void AddAchievement(string achievementId) { }

	public void AddFlag(string flag, int count) { }

	public void AddPrefabGuid(string prefabGuid) { }

	private void Awake() { }

	public bool CanUserUseInventory() { }

	public bool ContainsAchievement(string achievementId) { }

	public bool ContainsFlag(string flag) { }

	public bool ContainsFlagType(InventoryFlagType flagType) { }

	public bool ContainsPrefabGuid(string prefabGuid) { }

	private void EnsureData() { }

	public InventoryData get_CurrentData() { }

	[CompilerGenerated]
	public static InventoryManager get_Instance() { }

	[CompilerGenerated]
	public InventoryItemsTracker get_ItemsTracker() { }

	public InventoryBuildData GetBuildData() { }

	public int GetFlagCount(InventoryFlagType flagType) { }

	public int GetFlagCount(string flag) { }

	private void Init() { }

	public bool IsInventoryRequired(string prefabGuid) { }

	public void LoadData() { }

	public void LogData() { }

	public void Multiplayer_ClearData() { }

	public void Multiplayer_SetData(InventoryData data) { }

	private void OnDestroy() { }

	private void OnGameProgressLoadedFromCloud() { }

	private void OnLevelPrePostInit() { }

	private void OnPreSaveProgress(Scene scene) { }

	private void OnResetWorldData() { }

	public bool PackHasItems(string prefabGuid) { }

	private void SaveDataIfNeeded() { }

	[CompilerGenerated]
	private static void set_Instance(InventoryManager value) { }

	[CompilerGenerated]
	private void set_ItemsTracker(InventoryItemsTracker value) { }

	public void SetCurrentData(InventoryData inventoryData) { }

	[IteratorStateMachine(typeof(<Start>d__16))]
	private IEnumerator Start() { }

	private void SyncPrefabGuidsCollection() { }

	public bool TryGetPackItems(string prefabGuid, out HashSet<String>& items) { }

	private void TryMigrateOldData() { }

}

