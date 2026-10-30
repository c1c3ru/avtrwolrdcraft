namespace Game.Level;

public class LevelMusicRecord : LevelItem, IInteractableItem, IMultiplayer_NetworkIdentityBase
{
	[SerializeField]
	private Sprite _openMode; //Field offset: 0x348
	[SerializeField]
	private Sprite _closeMode; //Field offset: 0x350
	[SerializeField]
	private Sprite _recordOnPlayerSprite; //Field offset: 0x358
	[SerializeField]
	private string _clipName; //Field offset: 0x360
	private SpriteRenderer _spriteRenderer; //Field offset: 0x368
	private bool _isOpen; //Field offset: 0x370

	public string ClipName
	{
		 get { } //Length: 8
	}

	public Sprite RecordOnPlayerSprite
	{
		 get { } //Length: 8
	}

	public LevelMusicRecord() { }

	protected virtual void Awake() { }

	public string get_ClipName() { }

	public Sprite get_RecordOnPlayerSprite() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	private string Multiplayer_GetKey() { }

	protected virtual void OnLevelPostInit() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropInteraction.IInteractableItem.Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public virtual bool TryDropInteraction(ILevelConsumer consumer, out MPEventIdentifierData mpData) { }

}

