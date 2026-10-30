namespace PWC.Level.Queries;

public static class LevelDropAreaQuery
{

	private static bool CanItemFallOnDropArea(LevelDropArea dropArea, LevelItem levelItem, Bounds1D itemXBounds, Vector2 point) { }

	public static bool CanItemHeightFitInsideDropArea(LevelItem levelItem, LevelDropArea dropArea) { }

	public static bool CanItemWidthFitInsideDropArea(LevelItem levelItem, LevelDropArea dropArea) { }

	public static LevelDropArea GetDropAreaToFallOn(LevelItem levelItem, Vector2 position, out Vector2 hitPointToUse, List<LevelDropArea> dropAreas = null, bool shouldAlwaysConsiderRaycastStartInsideShape = false) { }

	public static bool IsDroppableUnderItem(LevelItem levelItem, LevelDropArea dropArea, Vector2 position, Bounds1D itemXBounds, GameShapeBase touchGameShape, out bool isTouchingOnly, LevelConsumerAreaBase overrideConsumerAreaForTest = null) { }

	private static bool IsEntityBlockingDropArea(ILevelEntity levelEntity, LevelDropArea dropArea, Vector2 position) { }

	public static bool PerformBasicTests(LevelDropArea dropArea, LevelItem levelItem, Bounds1D areaXWorldBounds, Bounds1D itemXWorldBounds) { }

	public static bool TryGetPointToFallOn(Vector2 fromPosition, LevelDropArea dropArea, out Vector2 resultPoint) { }

	private static bool TryGetPrefferedOrientationType(LevelItem levelItem, LevelDropArea dropArea, out ItemOrientationType orientationType) { }

}

