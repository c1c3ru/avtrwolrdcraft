namespace PWC.PersistentData;

public class TransformPD
{
	public string parent; //Field offset: 0x10
	public Vector2 position; //Field offset: 0x18
	public bool isFlipped; //Field offset: 0x20

	public TransformPD() { }

	public static void AddData(Dictionary<String, Object> allData, Transform transform) { }

	public static void SetFromData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> objects, Transform transform) { }

	protected static bool TryGetData(Dictionary<String, Object> allData, out TransformPD data) { }

}

