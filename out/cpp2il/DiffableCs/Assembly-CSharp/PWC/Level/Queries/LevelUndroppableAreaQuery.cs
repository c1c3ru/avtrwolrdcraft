namespace PWC.Level.Queries;

public static class LevelUndroppableAreaQuery
{

	public static bool CanAffectItemOnDrop(LevelItem levelItem, LevelUndroppableArea undroppableArea, Bounds1D worldXBounds, float yPosition) { }

	public static bool CanAreaAffectItemStrict(LevelItem levelItem, LevelUndroppableArea undroppableArea, Bounds1D worldXBounds, float yPosition) { }

	public static bool IsGameShapeOfItemTouching(LevelItem levelItem, LevelUndroppableArea undroppableArea, GameShape gameShape) { }

	public static bool IsItemHeightFitAreaNeeds(LevelItem levelItem, LevelUndroppableArea undroppableArea) { }

	public static bool IsPointOfItemTouching(LevelItem levelItem, LevelUndroppableArea undroppableArea, Vector2 point) { }

	private static bool IsXBoundsTouching(LevelUndroppableArea undroppableArea, Bounds1D worldXBounds, float yPosition) { }

	public static bool PerformBasicTests(LevelUndroppableArea undroppableArea, LevelItem levelItem, Bounds1D worldXBounds) { }

}

