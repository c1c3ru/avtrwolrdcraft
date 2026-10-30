namespace PWC.Level;

public class LevelLevelSwitcher : StationaryInteractableItem, IPointerClickHandler, IEventSystemHandler, IMultiplayer_IgnoreInputEvents, ILevelMakerDisabledWhileInEditMode
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public ILevelAvatar avatar; //Field offset: 0x10

		public <>c__DisplayClass21_0() { }

		internal bool <OnLevelPrePostInit>b__0(ILevelAvatar x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public LevelItem levelItem; //Field offset: 0x10
		public ILevelAvatar avatar; //Field offset: 0x18
		public Predicate<ILevelAvatar> <>9__1; //Field offset: 0x20

		public <>c__DisplayClass24_0() { }

		internal bool <TryAffectOnEndDrag>b__1(ILevelAvatar x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_1
	{
		public LevelLevelSwitcher switcher; //Field offset: 0x10
		public <>c__DisplayClass24_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass24_1() { }

		internal void <TryAffectOnEndDrag>b__0() { }

	}

	private static int _idInProgress; //Field offset: 0x0
	private const int NO_ID_IN_PROGRESS = -2147483648; //Field offset: 0x0
	public static readonly List<LevelLevelSwitcher> List; //Field offset: 0x8
	[SerializeField]
	private WorldBuildingType _buildingType; //Field offset: 0x3C
	[SerializeField]
	private LevelType _levelType; //Field offset: 0x40
	[SerializeField]
	private int _id; //Field offset: 0x44

	public LevelType LevelType
	{
		 get { } //Length: 8
	}

	private static LevelLevelSwitcher() { }

	public LevelLevelSwitcher() { }

	public void AddAvatar(ILevelAvatar avatar) { }

	protected virtual void Awake() { }

	public override bool CanTravel() { }

	protected static void ClearIdInProgress() { }

	public LevelType get_LevelType() { }

	protected override string GetArrivalBulkDataKey() { }

	protected override string GetDestinationBulkDataKey() { }

	protected static string GetKeyForSceneName(string sceneName) { }

	public override void LoadScene() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	private void OnLevelPrePostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void SetLevelAndBuilding(LevelType levelType, WorldBuildingType buildingType) { }

	private void Start() { }

	public static bool TryAffectOnEndDrag(ILevelAvatar avatar) { }

	protected override bool TryClaimArrival() { }

}

