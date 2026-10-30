namespace Game.Level;

public class LevelSimpleMultiPrefabSpawnerBalloons : LevelSimpleMultiPrefabSpawner
{
	[SerializeField]
	private int _colorIndex; //Field offset: 0xA0

	public LevelSimpleMultiPrefabSpawnerBalloons() { }

	protected virtual void OnPostSpawn(LevelItem levelItem) { }

}

