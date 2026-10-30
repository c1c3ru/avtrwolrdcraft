namespace PWC.Level.Maker;

public abstract class LevelMakerSnappableWallFloorItemBase : LevelMakerItemWithArea, IMultiplayer_PrepareForDrag
{
	[SerializeField]
	protected LevelObjectAreaBase _wallArea; //Field offset: 0x1C0
	protected LevelMakerSnappableItemHandler _snappableItemHandler; //Field offset: 0x1C8

	protected LevelMakerSnappableWallFloorItemBase() { }

	protected virtual void Awake() { }

	public virtual LevelObjectAreaBase GetExtraArea() { }

	protected virtual List<Vector2> GetPositionsForGoodPlaceToDropTest() { }

	public List<LevelMakerSnappableFloorLine> GetSelfFloorLines() { }

	protected abstract SnapType GetSnapType() { }

	public virtual bool IsAreaFullyInsideASpecificWall(LevelWallArea wallArea) { }

	private bool IsAreaFullyInsideFloor() { }

	protected override bool IsAreaFullyInsideWall() { }

	protected virtual bool IsCurrentPositionGoodForDrop(out LevelAreaBase area) { }

	protected virtual bool IsFlippedStateBoundToPositionInLevel() { }

	protected virtual bool IsOnStaticWall() { }

	protected virtual string Multiplayer_GetKey() { }

	public virtual void Multiplayer_OnTransformChange() { }

	protected virtual void Multiplayer_ReceiveMessage(MPEventIdentifierData idData, Multiplayer_ItemDropData endDragData) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	private override void PWC.Multiplayer.IMultiplayer_PrepareForDrag.Multiplayer_PrepareForDrag() { }

	public void SetCanSnapOnSyncPosition(bool canSnap) { }

	public void SnapToWall() { }

}

