namespace PWC.Level.Maker;

public interface ILevelMakerSnappableFloorLineObject
{

	public Bounds GetBounds() { }

	public CShape GetWallCShape() { }

	public GameShape GetWallGameShape() { }

	public void SetContentSortingOrder(int sortingOrder) { }

}

