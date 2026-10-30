namespace Game.Level;

public class OneTimeEvent : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private UnityEvent _oneTimeEvent; //Field offset: 0x20
	private bool _hasFiredEvent; //Field offset: 0x28

	public OneTimeEvent() { }

	public void FireEvent() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

