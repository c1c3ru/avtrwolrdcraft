namespace PWC.World;

public class WorldCar : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Sprite, String> <>9__8_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <Init>b__8_0(Sprite x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public Color color; //Field offset: 0x10
		public WorldCar <>4__this; //Field offset: 0x20

		public <>c__DisplayClass12_0() { }

		internal void <OnBackgroundPlanetClick>b__0(float alphaValue) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public WorldRoadPoint roadPoint; //Field offset: 0x10
		public WorldCar <>4__this; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <DriveTo>b__0() { }

	}

	private enum CarDirection
	{
		None = 0,
		Left = 1,
		Up = 2,
		Right = 3,
		Down = 4,
	}

	[SerializeField]
	private SpriteRenderer _light; //Field offset: 0x20
	private WorldRoadPoint _currentRoadPoint; //Field offset: 0x28
	private SpriteRenderer _spriteRenderer; //Field offset: 0x30
	private Dictionary<String, Sprite> _spirtes; //Field offset: 0x38
	private float _speed; //Field offset: 0x40
	private SortingGroup _sortingGroup; //Field offset: 0x48

	public WorldCar() { }

	private void Awake() { }

	private void DriveTo(WorldRoadPoint roadPoint) { }

	private void FitSpriteToDirection(Vector2 direction) { }

	private CarDirection GetCarDirection(Vector2 direction) { }

	public void Init(WorldRoadPoint roadPoint, int carNumber, int sortingOrder, float speed = 0) { }

	private void OnBackgroundPlanetClick() { }

	private void OnDestroy() { }

}

