namespace Game.Level;

public class LevelDynamicColorSpawner : LevelSimpleSpawner
{
	[SerializeField]
	private LevelMakerCustomizationHandlerBase _colorProvider; //Field offset: 0x98

	public LevelDynamicColorSpawner() { }

	protected virtual void OnSpawn(LevelSpawn levelSpawn) { }

}

