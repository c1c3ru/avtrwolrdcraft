namespace PWC.Level;

public class LevelSimpleSpawner : LevelSimpleSpawnerBase
{
	[SerializeField]
	protected PDPrefabReference _prefabReference; //Field offset: 0x90

	public LevelSimpleSpawner() { }

	public PDPrefabReference GetPDRefrence() { }

	public virtual LevelSpawn GetPrefabToSpawn() { }

	public void SetPDRefrence(PDPrefabReference reference) { }

}

