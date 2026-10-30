namespace PWC.UGC;

public interface IUGCGridItemOwner : IUGCEntity
{

	public bool CanHoldFlatFloorItems() { }

	public bool CanHoldGridItems() { }

	public Transform GetParentForFlatItems() { }

	public Transform GetParentForGridItems() { }

	public ValueTuple<Vector2, Vector2> GetProjected2DMinMax() { }

	public int GetSortingOrder() { }

	public CShape GetTopCShape() { }

	public float GetZBottom() { }

	public float GetZTop() { }

}

