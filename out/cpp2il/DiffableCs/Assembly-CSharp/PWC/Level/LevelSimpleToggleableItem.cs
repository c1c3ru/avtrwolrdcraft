namespace PWC.Level;

public class LevelSimpleToggleableItem : LevelItem
{
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x348
	[SerializeField]
	protected string _soundName; //Field offset: 0x350
	[SerializeField]
	protected float _volume; //Field offset: 0x358
	[FormerlySerializedAs("isRandom")]
	[SerializeField]
	private bool _isRandom; //Field offset: 0x35C
	[SerializeField]
	private Sprite[] _sprites; //Field offset: 0x360
	protected int _currentIndex; //Field offset: 0x368

	public LevelSimpleToggleableItem() { }

	protected virtual void Awake() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	protected override void PlaySound() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

