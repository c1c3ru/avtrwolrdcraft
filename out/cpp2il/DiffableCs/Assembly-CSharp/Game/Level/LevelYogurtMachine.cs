namespace Game.Level;

public class LevelYogurtMachine : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelAreaBase> <>9__4_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <SpawnYogurt>b__4_0(LevelAreaBase area) { }

	}

	[SerializeField]
	private LevelSingleItemDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private LevelIceCreamSpawner _spawner; //Field offset: 0x28
	[SerializeField]
	private LevelIceCreamSpawner _multiColorSpawner; //Field offset: 0x30
	[SerializeField]
	private List<Color> _iceCreamColors; //Field offset: 0x38

	public LevelYogurtMachine() { }

	public void SpawnYogurt(int colorIndex) { }

}

