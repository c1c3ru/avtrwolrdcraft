namespace PWC.Level.Maker;

public class LevelMakerSnappableWallItem : LevelMakerSnappableWallFloorItemBase
{

	public LevelMakerSnappableWallItem() { }

	protected virtual SnapType GetSnapType() { }

	protected virtual List<LevelObjectAreaBase> GetStaticAreasList() { }

	protected virtual void OnTryDropOnAGoodPlaceIteration() { }

	public virtual bool TryDropOnAGoodPlace(out LevelAreaBase area, bool useTween = false, bool useClosestPosition = false) { }

}

