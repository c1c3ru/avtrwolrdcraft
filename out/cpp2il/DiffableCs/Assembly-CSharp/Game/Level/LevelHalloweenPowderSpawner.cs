namespace Game.Level;

public class LevelHalloweenPowderSpawner : LevelSimpleSpawner
{
	[SerializeField]
	private LevelChangeColorOnClick _toggleableColor; //Field offset: 0x98
	[SerializeField]
	private PDPrefabReference[] _spawns; //Field offset: 0xA0

	public LevelHalloweenPowderSpawner() { }

	public virtual LevelSpawn GetPrefabToSpawn() { }

	protected virtual void OnPostSpawn(LevelItem levelItem) { }

}

