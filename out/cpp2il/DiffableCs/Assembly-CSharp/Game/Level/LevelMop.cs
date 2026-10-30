namespace Game.Level;

public class LevelMop : LevelSimpleDragActionItemBase
{
	[SerializeField]
	private Sprite _heldSprite; //Field offset: 0x358
	[SerializeField]
	private Sprite _placedSprite; //Field offset: 0x360
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x368
	private SpriteRenderer _spriteRenderer; //Field offset: 0x370

	public LevelMop() { }

	protected virtual void Awake() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer) { }

}

