namespace Game.Level;

public class LevelDestroyableObjectHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private bool _isPoof; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onObjectDestroyed; //Field offset: 0x28
	private bool _isDestroyedForEver; //Field offset: 0x30

	public LevelDestroyableObjectHandler() { }

	public void Destroy(bool shouldDestroyForEver) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

