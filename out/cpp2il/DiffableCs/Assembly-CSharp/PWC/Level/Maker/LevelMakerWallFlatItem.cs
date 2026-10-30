namespace PWC.Level.Maker;

public class LevelMakerWallFlatItem : LevelMakerFlatItemBase
{
	private List<LevelMakerSnappableFloorLine> _myFloorLinesList; //Field offset: 0x1C0

	public LevelMakerWallFlatItem() { }

	protected virtual void Awake() { }

	protected virtual List<Vector2> GetPositionsForGoodPlaceToDropTest() { }

	public List<LevelMakerSnappableFloorLine> GetSelfFloorLines() { }

	protected virtual List<LevelObjectAreaBase> GetStaticAreasList() { }

	protected virtual bool IsCurrentPositionGoodForDrop(out LevelAreaBase area) { }

	protected virtual bool IsFlippedStateBoundToPositionInLevel() { }

	protected virtual void OnReadyPostLoad() { }

	protected virtual void OnSyncPosition(Vector2 position) { }

	protected virtual void OnTryDropOnAGoodPlaceIteration() { }

	protected override void SyncSorting() { }

	protected override bool TryFitAreaInsideAWall(out LevelWallArea wallArea) { }

}

