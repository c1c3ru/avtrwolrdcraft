namespace Game.Level;

public class LevelAvatarMouthDropArea : LevelSingleCenteredItemDropArea
{
	[SerializeField]
	private bool _shouldAddCAHandlers; //Field offset: 0xD8
	private ILevelAvatar _avatar; //Field offset: 0xE0
	private string _currentItemAnimationName; //Field offset: 0xE8

	public LevelAvatarMouthDropArea() { }

	protected virtual void Awake() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public virtual bool CanItemFallOnSelf(LevelItem levelItem) { }

	public ILevelAvatar GetAvatar() { }

	public virtual Vector2 GetProperPositionToDropOnFromPosition(Vector2 fromPosition, LevelItem levelItem) { }

	public virtual void OnItemBeginDrop(LevelItem levelItem) { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	protected virtual void OnReadyPostLoad() { }

	private void SetAnimationIfNeeded(LevelItemOnAvatarMouthHandlerBase handler) { }

	private void UpdateCAHandlersIfNeeded(LevelItem levelItem) { }

}

