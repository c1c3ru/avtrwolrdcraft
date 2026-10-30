namespace PWC.Level.Maker;

public static class LevelMakerWallMethods
{

	public static float GetMinYBoundsOfWall(LevelWallArea wallArea) { }

	public static List<Vector2> GetWallPositionsForCurrentCameraView(GameObject gameObject) { }

	public static bool IsAreaFullyInsideAWall(LevelObjectAreaBase area, LevelWallArea wallArea, WallAngleType angleType) { }

	public static bool IsAreaFullyInsideWall(LevelObjectAreaBase area, WallAngleType angleType, out LevelWallArea wall) { }

	public static bool IsAreaXBoundsInsideAWall(LevelObjectAreaBase area, LevelWallArea wallArea) { }

	public static bool IsAreaXBoundsInsideWall(LevelObjectAreaBase area, WallAngleType angleType, out LevelWallArea wall) { }

}

