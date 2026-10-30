namespace PWC.PersistentData;

public class PDPrefabPDSnapshot
{
	internal class SceneObjectData
	{
		public string sceneGuid; //Field offset: 0x10
		public List<String> persistentDataList; //Field offset: 0x18

		public SceneObjectData() { }

	}

	public string prefabGuid; //Field offset: 0x10
	public List<SceneObjectData> sceneObjectsData; //Field offset: 0x18

	public PDPrefabPDSnapshot() { }

	public void ApplySnapshot(PDPrefab pdPrefab) { }

	public static PDPrefabPDSnapshot CreateSnapshot(PDPrefab pDPrefab) { }

}

