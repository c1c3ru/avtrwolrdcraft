namespace Game.Level.ContextualAnimation;

public class LevelCABackSpriteItemItemHandler : LevelCAItemHandlerWithData
{
	[SerializeField]
	private Sprite _phoneBackSprite; //Field offset: 0x90
	[SerializeField]
	private LevelToggleableSprite _toggleableSprite; //Field offset: 0x98
	private Sprite _currentSprite; //Field offset: 0xA0
	private bool _isBack; //Field offset: 0xA8

	public LevelCABackSpriteItemItemHandler() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void SetSpriteToBack() { }

	private void SetSpriteToFront() { }

}

