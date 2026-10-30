namespace Game.Level;

public class LevelToggleableUnityEvent : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject, ILevelMakerDisabledWhileInEditMode
{
	[SerializeField]
	private UnityEvent[] _toggleEvents; //Field offset: 0x20
	[SerializeField]
	private bool _isRandom; //Field offset: 0x28
	[SerializeField]
	private bool _ignorePD; //Field offset: 0x29
	[SerializeField]
	private bool _invokeOnPostInit; //Field offset: 0x2A
	private int _currentIndex; //Field offset: 0x2C

	public LevelToggleableUnityEvent() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void Toggle() { }

}

