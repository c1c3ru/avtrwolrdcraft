namespace PWC.InteractionHistory;

public class InteractionHistoryManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<WorldBuildingType, Boolean> <>9__16_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Init>b__16_0(WorldBuildingType x) { }

	}

	private const string KEY = "PWC_World_InteractionHistory"; //Field offset: 0x0
	private static Data _data; //Field offset: 0x0
	public const string UC_SUFFIX = "__NOTREADY"; //Field offset: 0x0
	public const string LAST_FOCUSED_BUILDING_TYPE_KEY = "PWC_World_InteractionHistory_LastFocusedBuildingType"; //Field offset: 0x0
	public const string LAST_ENTRY_FOCUS_BUILD_NUMBER_KEY = "PWC_World_InteractionHistory_LastEntryFocusBuildNumber"; //Field offset: 0x0
	public const string FOCUS_ON_BUILDING_DATA_PATH = "FocusedBuilding/InteractionHistory_FocusOnBuildingData"; //Field offset: 0x0
	[CompilerGenerated]
	private static InteractionHistoryManager <Instance>k__BackingField; //Field offset: 0x8
	private FocusOnBuildingData _focusData; //Field offset: 0x20
	private WorldManager _entryFocusEvaluatedWorld; //Field offset: 0x28
	private bool _didFocusOnEntryPosition; //Field offset: 0x30

	public private static InteractionHistoryManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public InteractionHistoryManager() { }

	private void Awake() { }

	public bool DidFocusOnEntryPosition() { }

	private void EnsureData() { }

	[CompilerGenerated]
	public static InteractionHistoryManager get_Instance() { }

	private static int GetCurrentBuildNumber() { }

	public LevelWorldType GetCurrentWorldTypeToFocus() { }

	public void Init() { }

	public bool IsNeedToFocusOnEntryPosition() { }

	public bool IsNewBuilding(int buildingId) { }

	public void MarkBuildingAsInteracted(int buildingId) { }

	private void OnApplicationPause(bool pause) { }

	public void OnClickHomePlayButton() { }

	private void OnDestroy() { }

	private void OnWorldPostInit() { }

	private void SaveDataIfNeeded() { }

	[CompilerGenerated]
	private static void set_Instance(InteractionHistoryManager value) { }

	public void SetFocusedBuildingType(WorldBuildingType buildingType) { }

	public bool ShouldShowNewIconInHome() { }

	private void Start() { }

	private bool TryFocusOnEntryPosition() { }

	public bool TryGetLastFocusedBuildingType(out WorldBuildingType buildingType) { }

}

