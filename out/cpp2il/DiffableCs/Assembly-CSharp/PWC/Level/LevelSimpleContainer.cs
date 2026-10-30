namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelSimpleContainer : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected LevelDoor _door; //Field offset: 0x20
	[SerializeField]
	protected GameObject _content; //Field offset: 0x28

	public LevelSimpleContainer() { }

	protected override void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected override void OnDestroy() { }

	protected override void OnDoorStateChange(bool isOpen) { }

	protected override void OnLevelPostInit() { }

	private void SetNoLivingBeingIfNeeded(LevelDropArea dropArea) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void Start() { }

}

