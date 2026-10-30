namespace Game.Level;

public class LevelNoteLinesSimpleSpawner : LevelSimpleSpawner, IHasPersistentData, IRequirePDSceneObject
{
	private int _counter; //Field offset: 0x98

	public LevelNoteLinesSimpleSpawner() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPostSpawn(LevelItem levelItem) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

