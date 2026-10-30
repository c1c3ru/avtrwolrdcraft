namespace PWC.UGC;

public class UGCPresetRegenerationGridFloorHandler : UGCNewPresetGridFloorHandler
{
	internal class UGCPresetRegenerationGridFloorHandlerPD
	{
		public string presetPrefabGuid; //Field offset: 0x10

		public UGCPresetRegenerationGridFloorHandlerPD() { }

	}

	private readonly Dictionary<LevelType, List`1<String>> _entranceSceneGuidsByLevelType; //Field offset: 0x38
	private string _spawnedPresetPrefabGuid; //Field offset: 0x40

	public UGCPresetRegenerationGridFloorHandler() { }

	private void ClearFloor() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	private string GetPresetPrefabGuid() { }

	private bool IsRootItemOnFloor(UGCItemBase item) { }

	protected virtual void OnUGCPostInit() { }

	private void RestoreEntranceSceneGuids() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void TakeEntranceSceneGuids() { }

}

