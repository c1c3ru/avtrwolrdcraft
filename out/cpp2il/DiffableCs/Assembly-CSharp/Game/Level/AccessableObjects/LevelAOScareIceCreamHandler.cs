namespace Game.Level.AccessableObjects;

public class LevelAOScareIceCreamHandler : LevelAOScareItemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x20
	[SerializeField]
	private LevelItem _gift; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onScareAction; //Field offset: 0x30
	private bool _isGiftGiven; //Field offset: 0x38

	public LevelAOScareIceCreamHandler() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual void Scare() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

