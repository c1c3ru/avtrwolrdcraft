namespace PWC.Level;

public class LevelToggleableItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x20
	[SerializeField]
	protected string _soundName; //Field offset: 0x28
	[SerializeField]
	protected float _volume; //Field offset: 0x30
	[FormerlySerializedAs("isRandom")]
	[SerializeField]
	private bool _isRandom; //Field offset: 0x34
	[SerializeField]
	private Sprite[] _sprites; //Field offset: 0x38
	protected int _currentIndex; //Field offset: 0x40
	private LevelItem _levelItem; //Field offset: 0x48

	public LevelToggleableItemHandler() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnItemClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	protected override void PlaySound() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

