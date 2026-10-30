namespace Game.Level;

public class LevelBlockWallWithActiveItem : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private GameObject _item; //Field offset: 0x20
	[SerializeField]
	private GameObject _wallArea; //Field offset: 0x28
	[SerializeField]
	private GameObject _blockedWallArea; //Field offset: 0x30
	private bool _needToCheckItems; //Field offset: 0x38

	public LevelBlockWallWithActiveItem() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnLevelPrePostInit() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

