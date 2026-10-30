namespace PWC.Level;

public class LevelCookableSpawner : LevelSimpleSpawner
{
	[SerializeField]
	private LevelCookableItemHandler _cookableItemHandler; //Field offset: 0x98
	[CompilerGenerated]
	private Action<LevelSpawn> onSpawnAction; //Field offset: 0xA0

	public event Action<LevelSpawn> onSpawnAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelCookableSpawner() { }

	[CompilerGenerated]
	public void add_onSpawnAction(Action<LevelSpawn> value) { }

	protected virtual bool CanSpawn() { }

	protected virtual void OnSpawn(LevelSpawn levelSpawn) { }

	[CompilerGenerated]
	public void remove_onSpawnAction(Action<LevelSpawn> value) { }

}

