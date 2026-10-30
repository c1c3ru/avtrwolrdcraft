namespace PWC.Level;

[DisallowMultipleComponent]
[RequireComponent(typeof(LevelItem))]
public class LevelTransformableCustomItemHandler : LevelTransformableItemHandlerBase, IHasPersistentData, IRequirePDSceneObject, ILevelMakerUICountExtraPrefab
{
	internal enum ReferenceType
	{
		PrefabGuid = 0,
		Clothing = 1,
	}

	private PDPrefabReference _prefabReference; //Field offset: 0x88
	private string _clothingName; //Field offset: 0x90
	private ReferenceType _type; //Field offset: 0x98
	private SpineType _spineType; //Field offset: 0x9C

	public LevelTransformableCustomItemHandler() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual string GetTransformTargetPrefabName() { }

	private override string PWC.Level.ILevelMakerUICountExtraPrefab.GetExtraPrefabGuid() { }

	public void SetClothingName(string clothingName, SpineType SpineType) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetPrefabReference(PDPrefabReference reference) { }

	private PDPrefab SpawnClothing() { }

	private PDPrefab SpawnItem() { }

	protected virtual bool TrySpawnImplement(out PDPrefab pdPrefabInstance) { }

}

