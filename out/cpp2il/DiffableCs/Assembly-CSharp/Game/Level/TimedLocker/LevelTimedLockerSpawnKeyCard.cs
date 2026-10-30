namespace Game.Level.TimedLocker;

public class LevelTimedLockerSpawnKeyCard : LevelSpawnOnLevelPostInit
{
	[SerializeField]
	protected LevelSpawner _spawner; //Field offset: 0x68

	public LevelTimedLockerSpawnKeyCard() { }

	public virtual void SpawnOnInit() { }

}

