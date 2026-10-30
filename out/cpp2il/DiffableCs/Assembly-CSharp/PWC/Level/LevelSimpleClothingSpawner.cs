namespace PWC.Level;

public class LevelSimpleClothingSpawner : LevelSimpleSpawnerBase
{
	[SerializeField]
	private string _skinName; //Field offset: 0x90

	public LevelSimpleClothingSpawner() { }

	public virtual LevelSpawn GetPrefabToSpawn() { }

	protected virtual void OnSpawn(LevelSpawn levelSpawn) { }

}

