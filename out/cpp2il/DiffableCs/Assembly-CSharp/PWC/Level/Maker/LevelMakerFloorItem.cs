namespace PWC.Level.Maker;

public class LevelMakerFloorItem : LevelMakerItemWithArea
{

	public LevelMakerFloorItem() { }

	protected virtual List<Vector2> GetPositionsForGoodPlaceToDropTest() { }

	protected virtual List<LevelObjectAreaBase> GetStaticAreasList() { }

	protected virtual bool IsCurrentPositionGoodForDrop(out LevelAreaBase area) { }

}

