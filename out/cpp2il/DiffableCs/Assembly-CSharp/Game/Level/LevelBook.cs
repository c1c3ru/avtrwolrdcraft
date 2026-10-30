namespace Game.Level;

public class LevelBook : LevelItem
{
	[SerializeField]
	protected Sprite _closedSprite; //Field offset: 0x348
	[SerializeField]
	protected Sprite _openSprite; //Field offset: 0x350
	[SerializeField]
	protected string _soundName; //Field offset: 0x358
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x360

	public LevelBook() { }

	protected virtual void Awake() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	public virtual void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

}

