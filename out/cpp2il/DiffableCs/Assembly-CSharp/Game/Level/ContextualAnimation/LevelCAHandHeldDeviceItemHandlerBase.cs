namespace Game.Level.ContextualAnimation;

public abstract class LevelCAHandHeldDeviceItemHandlerBase : LevelCAItemHandlerBase
{
	[SerializeField]
	private Sprite _phoneBackSprite; //Field offset: 0x88
	[SerializeField]
	private LevelToggleableSprite _toggleableSprite; //Field offset: 0x90
	private Sprite _currentSprite; //Field offset: 0x98

	protected LevelCAHandHeldDeviceItemHandlerBase() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void SetSpriteToBack() { }

	private void SetSpriteToFront() { }

}

