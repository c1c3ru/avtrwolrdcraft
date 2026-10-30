namespace PWC.Level.Maker.Customization;

public class LevelMakerFurnitureSpawnItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	private string _spawnerGlobalGUID; //Field offset: 0x20

	public string SpawnerGlobalGUID
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelMakerFurnitureSpawnItemHandler() { }

	public string get_SpawnerGlobalGUID() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void ReturnItem() { }

	public void set_SpawnerGlobalGUID(string value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

