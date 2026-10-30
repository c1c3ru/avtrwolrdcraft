namespace PWC.Level.Maker;

public class LevelMakerSnappableFloorItem : LevelMakerSnappableWallFloorItemBase
{

	public LevelMakerSnappableFloorItem() { }

	protected virtual SnapType GetSnapType() { }

	protected virtual List<LevelObjectAreaBase> GetStaticAreasList() { }

}

