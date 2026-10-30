namespace Game.Level;

public class LevelSpineSpawner : LevelSimpleSpawner
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x98
	[SerializeField]
	private string _spawnAnimation; //Field offset: 0xA0
	[SerializeField]
	private string _idleAnimation; //Field offset: 0xA8

	public LevelSpineSpawner() { }

	public virtual LevelSpawn GetPrefabToSpawn() { }

}

