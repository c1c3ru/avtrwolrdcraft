namespace Game.Level;

public class LevelToggleableUnityEventItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, ILevelMakerDisabledWhileInEditMode
{
	[SerializeField]
	private UnityEvent[] _toggleEvents; //Field offset: 0x20
	[SerializeField]
	private bool _isRandom; //Field offset: 0x28
	[SerializeField]
	private bool _ignorePD; //Field offset: 0x29
	[SerializeField]
	private bool _shouldJumpOnClick; //Field offset: 0x2A
	private int _currentIndex; //Field offset: 0x2C
	private LevelItem _levelItem; //Field offset: 0x30

	public LevelToggleableUnityEventItemHandler() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnItemClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void Toggle() { }

}

