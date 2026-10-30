namespace Game.Level;

public class LevelCharactersFilter : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private int _interval; //Field offset: 0x20
	[SerializeField]
	private int _minCount; //Field offset: 0x24
	[SerializeField]
	private int _maxCount; //Field offset: 0x28
	[SerializeField]
	private LevelCharacter[] _characters; //Field offset: 0x30
	private long _dateTimeTicks; //Field offset: 0x38
	private Boolean[] _remainCharactersMap; //Field offset: 0x40

	public LevelCharactersFilter() { }

	private void Awake() { }

	private void CreateNewState() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPrePostInit() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

