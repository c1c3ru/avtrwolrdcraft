namespace PWC.PersistentData;

public class PDPrefabReference
{
	public string prefabGuid; //Field offset: 0x10

	public PDPrefabReference() { }

	public PDPrefab GetPDPrefab() { }

	public string GetPDPrefabPath() { }

	public bool IsValid() { }

	public PDPrefab Spawn(Nullable<Vector2> position = null, Transform parent = null) { }

}

