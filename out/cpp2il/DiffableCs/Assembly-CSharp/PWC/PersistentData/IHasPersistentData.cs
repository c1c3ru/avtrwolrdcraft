namespace PWC.PersistentData;

public interface IHasPersistentData : IRequirePDSceneObject
{

	public Dictionary<String, Object> GetPersistentData() { }

	public void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

