namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelSimpleSpawnerItem : LevelItem
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public LevelItem levelItem; //Field offset: 0x10

		public <>c__DisplayClass7_0() { }

		internal void <OnSpawn>b__0() { }

	}

	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x348
	[SerializeField]
	private LevelSpawn _prefab; //Field offset: 0x350
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x358
	[Range(1, 15)]
	[SerializeField]
	private int _maxInstances; //Field offset: 0x360
	[SerializeField]
	private bool _useFifo; //Field offset: 0x364
	[SerializeField]
	private bool _isJump; //Field offset: 0x365

	public LevelSimpleSpawnerItem() { }

	protected override LevelSpawn GetPrefab() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	protected override void OnSpawn(LevelItem levelItem) { }

}

