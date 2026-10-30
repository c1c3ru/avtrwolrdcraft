namespace Game.Level;

public class LevelSetActiveStateOnLoad : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{

	public LevelSetActiveStateOnLoad() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void SetActive(bool value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

