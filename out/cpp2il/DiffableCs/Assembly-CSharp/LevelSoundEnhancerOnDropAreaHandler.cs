//Type is in global namespace

public class LevelSoundEnhancerOnDropAreaHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private float _newDistanceFactor; //Field offset: 0x28
	[SerializeField]
	private bool _isDataSaved; //Field offset: 0x2C
	private Dictionary<GameSoundPlayer, Single> _registeredSoundPlayers; //Field offset: 0x30

	public LevelSoundEnhancerOnDropAreaHandler() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnAllHierarchyChildrenDropAreaItemEndDropAction(LevelDropArea area, LevelItem item) { }

	private void OnAllHierarchyChildrenDropAreaItemPickUpAction(LevelDropArea area, LevelItem item) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void SetDistance(float value) { }

	public void SetIncreaseDistanceFactor(float value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

