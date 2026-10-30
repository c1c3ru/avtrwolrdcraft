namespace PWC.Level.Maker;

public abstract class LevelMakerItemWithArea : LevelMakerItem, IMultiplayer_Messageable, IMultiplayer_NetworkIdentityBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<MeshSkew, Boolean> <>9__38_0; //Field offset: 0x8
		public static Func<MeshSkew, Boolean> <>9__39_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <GetTouchingFloorMeshes>b__38_0(MeshSkew x) { }

		internal bool <GetTouchingWallMeshes>b__39_0(MeshSkew x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public Vector2 startingPosition; //Field offset: 0x10

		public <>c__DisplayClass25_0() { }

		internal int <TryDropOnAGoodPlace>b__0(Vector2 lhs, Vector2 rhs) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public LevelMakerItemWithArea <>4__this; //Field offset: 0x10
		public Vector2 toPosition; //Field offset: 0x18

		public <>c__DisplayClass26_0() { }

		internal void <TweenToPosition>b__0(float value) { }

		internal void <TweenToPosition>b__1() { }

	}

	internal class Multiplayer_ItemDropData
	{
		[JsonProperty("target")]
		public string targetSceneGuid; //Field offset: 0x10
		[JsonProperty("pos")]
		public PJVector2 position; //Field offset: 0x18
		[JsonProperty("fromPos")]
		public PJVector2 fromPosition; //Field offset: 0x20
		[JsonProperty("isGoodPos")]
		public bool isInGoodPosition; //Field offset: 0x28
		[JsonProperty("sName")]
		public string sceneName; //Field offset: 0x30

		public Multiplayer_ItemDropData() { }

	}

	[SerializeField]
	protected LevelObjectAreaBase _area; //Field offset: 0x188
	[SerializeField]
	protected GameObject _badPositionIndicator; //Field offset: 0x190
	[SerializeField]
	protected WallAngleType _wallAngleType; //Field offset: 0x198
	private LevelMakerItemWithAreaPD _pdData; //Field offset: 0x1A0
	protected bool _isInGoodPosition; //Field offset: 0x1A8
	private int _floatingTweenId; //Field offset: 0x1AC
	private int _multiplayer_lastSendDropEventFrame; //Field offset: 0x1B0
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x1B4
	[CompilerGenerated]
	private Func<Boolean> OverrideIsGoodForDropTest; //Field offset: 0x1B8

	public event Func<Boolean> OverrideIsGoodForDropTest
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public WallAngleType AngleType
	{
		 get { } //Length: 8
	}

	public LevelObjectAreaBase Area
	{
		 get { } //Length: 8
	}

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	protected LevelMakerItemWithArea() { }

	[CompilerGenerated]
	public void add_OverrideIsGoodForDropTest(Func<Boolean> value) { }

	protected virtual void Awake() { }

	public WallAngleType get_AngleType() { }

	public LevelObjectAreaBase get_Area() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	public override LevelObjectAreaBase GetExtraArea() { }

	public LevelWallArea GetFrontTouchingWallArea(WallAngleType angleType = 0) { }

	public bool GetIsInGoodPositionCachedValue() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected abstract List<Vector2> GetPositionsForGoodPlaceToDropTest() { }

	protected abstract List<LevelObjectAreaBase> GetStaticAreasList() { }

	public List<LevelFloorArea> GetTouchingFloorAreas() { }

	public List<MeshSkew> GetTouchingFloorMeshes() { }

	public List<LevelWallArea> GetTouchingWallAreas(WallAngleType angleType) { }

	public List<MeshSkew> GetTouchingWallMeshes() { }

	public override bool IsAreaFullyInsideASpecificWall(LevelWallArea wallArea) { }

	public bool IsAreaTouchingAnOtherArea(out LevelAreaBase touchingArea) { }

	public override bool IsAreaTouchingBlockArea(out LevelAreaBase touchingBlockArea) { }

	protected override bool IsCurrentPositionGoodForDrop(out LevelAreaBase area) { }

	private bool IsTouchingAreasInList(out LevelAreaBase touchingArea, LevelObjectAreaBase extraArea, bool hasExtraArea, List<LevelObjectAreaBase> areasList, bool ignoreLayer) { }

	protected void Multiplayer_ApplyData(Multiplayer_ItemDropData endDragData) { }

	protected override string Multiplayer_GetKey() { }

	protected override void Multiplayer_ReceiveMessage(MPEventIdentifierData idData, Multiplayer_ItemDropData endDragData) { }

	public override void Multiplayer_SendItemDrop(Vector2 position, string key, bool isInGoodPosition, Nullable<Vector2> fromPosition = null) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	public override void OnEndDropOnGoodPlace(Vector3 position) { }

	private void OnLevelPrePostInit() { }

	protected virtual void OnSyncPosition(Vector2 position) { }

	protected override void OnTryDropOnAGoodPlaceIteration() { }

	private override void PWC.Multiplayer.IMultiplayer_Messageable.Multiplayer_ReceiveMessage(MPEventIdentifierData idData, object objectData) { }

	[CompilerGenerated]
	public void remove_OverrideIsGoodForDropTest(Func<Boolean> value) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	public void SetIsInGoodPosition(bool isInGoodPosition) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	protected virtual bool ShouldUpdateLight() { }

	public override void StartFloating() { }

	public override bool TryDropOnAGoodPlace(out LevelAreaBase area, bool useTween = false, bool useClosestPosition = false) { }

	public override void TryFitToCurrentPosition(bool useTween = true) { }

	protected void TweenToPosition(Vector2 fromPosition, Vector2 toPosition) { }

}

