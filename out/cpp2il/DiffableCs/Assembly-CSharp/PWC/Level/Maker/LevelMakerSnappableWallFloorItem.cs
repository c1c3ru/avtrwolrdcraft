namespace PWC.Level.Maker;

public class LevelMakerSnappableWallFloorItem : LevelMakerSnappableWallFloorItemBase
{

	public LevelMakerSnappableWallFloorItem() { }

	protected virtual SnapType GetSnapType() { }

	protected virtual List<LevelObjectAreaBase> GetStaticAreasList() { }

}

