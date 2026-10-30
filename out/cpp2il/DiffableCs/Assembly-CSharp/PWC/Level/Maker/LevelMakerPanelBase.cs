namespace PWC.Level.Maker;

public abstract class LevelMakerPanelBase : LevelMakerFlatItemBase
{
	public const float MIN_FLOOR_SIZE = 2; //Field offset: 0x0
	[SerializeField]
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x1C0
	protected CShape _cshape; //Field offset: 0x1C8
	private MeshSkew _leftMesh; //Field offset: 0x1D0
	private MeshSkew _rightMesh; //Field offset: 0x1D8
	private float _totalWidth; //Field offset: 0x1E0
	protected float _lastFreezeYposition; //Field offset: 0x1E4

	public MeshSkew LeftMesh
	{
		 get { } //Length: 8
		 set { } //Length: 16
	}

	public MeshSkew RightMesh
	{
		 get { } //Length: 8
		 set { } //Length: 16
	}

	public float TotalWidth
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	protected LevelMakerPanelBase() { }

	protected virtual void Awake() { }

	public MeshSkew get_LeftMesh() { }

	public MeshSkew get_RightMesh() { }

	public float get_TotalWidth() { }

	protected abstract List<Vector2> GetDefaultPositionsForCurrentCameraView() { }

	protected virtual int GetDefaultSortingOrder() { }

	private float GetHeightOfFloor(MeshSkew floor) { }

	public static MeshSkew GetLeftFloor(MeshSkew floorA, MeshSkew floorB) { }

	private float GetMiddleHeightOfFloor(MeshSkew floor) { }

	protected virtual List<Vector2> GetPositionsForGoodPlaceToDropTest() { }

	public static MeshSkew GetRightFloor(MeshSkew floorA, MeshSkew floorB) { }

	protected virtual bool IsCurrentPositionGoodForDrop(out LevelAreaBase area) { }

	protected virtual bool IsFlippedStateBoundToPositionInLevel() { }

	public static void MergeFloors(MeshSkew floorA, MeshSkew floorB) { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	public virtual void OnEndDropOnGoodPlace(Vector3 position) { }

	protected virtual void OnReadyPostLoad() { }

	protected virtual void OnTryDropOnAGoodPlaceIteration() { }

	public void set_LeftMesh(MeshSkew value) { }

	public void set_RightMesh(MeshSkew value) { }

	public void set_TotalWidth(float value) { }

	public virtual bool TryDropOnAGoodPlace(out LevelAreaBase area, bool useTween = false, bool useClosestPosition = false) { }

	private bool TryUpdateMeshes(Vector2 position, float totalWidth, MeshSkew meshSkew1, MeshSkew meshSkew2) { }

	protected void UpdateSizeAndDirection(float Length, bool updateCollider) { }

}

