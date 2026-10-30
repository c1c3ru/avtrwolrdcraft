namespace Game.Level;

public class LevelBoxedFurnitureSpawn : LevelTransformableItemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private SpriteRenderer _iconLogoSpriteRenderer; //Field offset: 0x98
	[SerializeField]
	private bool _isIconNeedUpdate; //Field offset: 0xA0
	private string _furnitureTypeNumber; //Field offset: 0xA8
	private string _spawnerGlobalGUID; //Field offset: 0xB0
	public string PDPrefabGUID; //Field offset: 0xB8

	public string SpawnerGlobalGUID
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelBoxedFurnitureSpawn() { }

	protected virtual bool CanBeClicked() { }

	public string get_SpawnerGlobalGUID() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void LoadFurnitureTypeIconSprite() { }

	public void set_SpawnerGlobalGUID(string value) { }

	public void SetFurnitureType(string _furnitureTypeIndex) { }

	public void SetPDPrefabReference(PDPrefabReference prefabReference) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	protected virtual bool TrySpawnImplement(out PDPrefab pdPrefabInstance) { }

}

