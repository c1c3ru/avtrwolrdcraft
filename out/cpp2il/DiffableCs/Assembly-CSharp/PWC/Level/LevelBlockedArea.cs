namespace PWC.Level;

public class LevelBlockedArea : LevelConsumerAreaBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public Vector2 currentItemPosition; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18
		public LevelBlockedArea <>4__this; //Field offset: 0x20
		public LevelFloorArea floorArea; //Field offset: 0x28
		public Vector2 destination; //Field offset: 0x30

		public <>c__DisplayClass7_0() { }

		internal void <TryAffect>b__0() { }

		internal void <TryAffect>b__1() { }

		internal float <TryAffect>b__2(LevelDropArea x) { }

	}

	public static readonly List<LevelBlockedArea> List; //Field offset: 0x0
	[SerializeField]
	private CShape _escapeArea; //Field offset: 0x58
	[SerializeField]
	private bool _dontAffectIfItemIsHigher; //Field offset: 0x60

	private static LevelBlockedArea() { }

	public LevelBlockedArea() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	public bool TryAffect(LevelItem levelItem, Nullable<Vector2> checkForPoint = null) { }

	public bool WouldAffectPoint(LevelItem levelItem, Vector2 point) { }

	public bool WouldAffectXBounds(LevelItem levelItem, Bounds1D worldXBounds, float yPosition) { }

}

