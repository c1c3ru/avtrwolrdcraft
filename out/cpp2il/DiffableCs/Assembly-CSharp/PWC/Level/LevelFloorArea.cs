namespace PWC.Level;

public class LevelFloorArea : LevelDropArea
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public Vector2 point; //Field offset: 0x10

		public <>c__DisplayClass11_0() { }

		internal int <GetPointsOnArea>b__0(Vector2 lhs, Vector2 rhs) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass8_0
	{
		public Bounds worldBounds; //Field offset: 0x0
		public LevelFloorArea floorArea; //Field offset: 0x18
		public LevelItem levelItem; //Field offset: 0x20
		public Vector2 fromPosition; //Field offset: 0x28
		public Vector2 result; //Field offset: 0x30

	}

	public static readonly List<LevelFloorArea> FloorList; //Field offset: 0x0
	private Vector2[] _pointsOnArea; //Field offset: 0xD8

	private static LevelFloorArea() { }

	public LevelFloorArea() { }

	[CompilerGenerated]
	internal static bool <TryGetNearestAllowedPositionOnFloor>g__TryColumn|8_0(float x, ref <>c__DisplayClass8_0 unnamed_param_1) { }

	public virtual bool CanConsumeCharacters() { }

	public static LevelFloorArea GetClosesetFloor(Vector2 point) { }

	private static LevelFloorArea GetFloorDirectlyBelow(Vector2 fromPosition, LevelItem levelItem, out Vector2 landingPosition) { }

	private static LevelFloorArea GetFloorNearestSideways(Vector2 fromPosition, LevelItem levelItem, out Vector2 landingPosition) { }

	public static LevelFloorArea GetFloorToFallStraightDownOn(Vector2 fromPosition, LevelItem levelItem, out Vector2 landingPosition) { }

	public Vector2[] GetPointsOnArea(Nullable<Vector2> sortToPoint = null) { }

	private List<Vector2> GetPointsOnAreaImplement() { }

	private static bool IsLandingPositionAllowed(Vector2 landingPosition, LevelItem levelItem) { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	private static bool TryGetNearestAllowedPositionOnFloor(LevelFloorArea floorArea, Vector2 fromPosition, LevelItem levelItem, out Vector2 landingPosition) { }

}

