namespace PWC;

public static class MeshSkewUtils
{
	internal enum SplitDirection
	{
		Horizontal = 0,
		Vertical = 1,
		Both = 2,
		HorizontalWithDeg = 3,
	}


	public static bool IsGoodPlaceForSplit(MeshSkew originalSkew, Vector3 cutPoint) { }

	private static bool TryCreateFloor(MeshSkew originalSkew, bool isRight, Vector3 cutPoint, out MeshSkew floorCreated) { }

	public static bool TrySplitMesh(MeshSkew original, Vector3 worldSplitPoint, out MeshSkew leftMesh, out MeshSkew rightMesh, SplitDirection splitDirection = 0) { }

}

