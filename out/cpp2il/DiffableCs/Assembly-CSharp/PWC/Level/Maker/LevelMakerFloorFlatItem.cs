namespace PWC.Level.Maker;

public class LevelMakerFloorFlatItem : LevelMakerFlatItemBase
{

	public LevelMakerFloorFlatItem() { }

	protected virtual int GetDefaultSortingOrder() { }

	protected virtual List<Vector2> GetPositionsForGoodPlaceToDropTest() { }

	protected virtual List<LevelObjectAreaBase> GetStaticAreasList() { }

	protected virtual bool IsCurrentPositionGoodForDrop(out LevelAreaBase area) { }

}

