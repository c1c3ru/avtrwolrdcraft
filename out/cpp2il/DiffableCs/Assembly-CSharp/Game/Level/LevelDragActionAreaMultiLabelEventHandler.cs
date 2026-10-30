namespace Game.Level;

public class LevelDragActionAreaMultiLabelEventHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDragActionArea _dragActionArea; //Field offset: 0x20
	[SerializeField]
	private List<String> _labels; //Field offset: 0x28
	[SerializeField]
	private bool _oneTimeEvent; //Field offset: 0x30
	[SerializeField]
	private UnityEvent OnScannedAction; //Field offset: 0x38
	private bool _eventHappened; //Field offset: 0x40

	public LevelDragActionAreaMultiLabelEventHandler() { }

	private void Awake() { }

	private bool CheckItemLabel(GameObject item) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnItemEnter(LevelItem levelItem) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

