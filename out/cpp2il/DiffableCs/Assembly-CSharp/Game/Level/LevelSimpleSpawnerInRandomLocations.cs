namespace Game.Level;

public class LevelSimpleSpawnerInRandomLocations : LevelSimpleSpawner
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public LevelItem levelItem; //Field offset: 0x10

		public <>c__DisplayClass3_0() { }

		internal void <OnSpawn>b__0() { }

	}

	[SerializeField]
	private bool _overriddeBasicDrop; //Field offset: 0x98
	[SerializeField]
	protected Transform[] _locationsToSpawn; //Field offset: 0xA0

	public LevelSimpleSpawnerInRandomLocations() { }

	protected virtual void OnSpawn(LevelSpawn levelSpawn) { }

	public virtual void SpawnOnClick() { }

}

