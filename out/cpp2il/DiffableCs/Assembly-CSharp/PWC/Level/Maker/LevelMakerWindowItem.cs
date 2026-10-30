namespace PWC.Level.Maker;

public class LevelMakerWindowItem : LevelMakerWallFlatItem
{
	[SerializeField]
	private GameObject _maskParent; //Field offset: 0x1C8

	public LevelMakerWindowItem() { }

	protected virtual List<Vector2> GetPositionsForGoodPlaceToDropTest() { }

	protected virtual List<LevelObjectAreaBase> GetStaticAreasList() { }

	public virtual bool IsAreaFullyInsideASpecificWall(LevelWallArea wallArea) { }

	public virtual bool IsAreaTouchingBlockArea(out LevelAreaBase touchingBlockArea) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnReadyPostLoad() { }

	protected virtual void OnSyncPosition(Vector2 position) { }

	protected virtual void SetFlipped(bool isFlipped) { }

	protected virtual void SyncSorting() { }

	protected virtual bool TryFitAreaInsideAWall(out LevelWallArea wallArea) { }

	private void UpdateMaskParent(Transform parent) { }

	private void UpdateMaskPosition() { }

}

