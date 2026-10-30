namespace Game.Level;

public class LevelCleanableArea : LevelConsumerAreaBase, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private UnityEvent OnCleanAction; //Field offset: 0x58
	[SerializeField]
	private string _label; //Field offset: 0x60
	[SerializeField]
	private bool _canWorkOnlyOnce; //Field offset: 0x68
	private bool _canClean; //Field offset: 0x69

	public LevelCleanableArea() { }

	public void Clean(string label) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

