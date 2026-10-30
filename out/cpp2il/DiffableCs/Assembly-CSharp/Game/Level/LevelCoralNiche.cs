namespace Game.Level;

public class LevelCoralNiche : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDropArea _coralNicheDropArea; //Field offset: 0x20
	[SerializeField]
	private LevelItem[] _gifts; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onCoralPlacedEvent; //Field offset: 0x30
	private bool _isGiftTaken; //Field offset: 0x38

	public LevelCoralNiche() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem item) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

