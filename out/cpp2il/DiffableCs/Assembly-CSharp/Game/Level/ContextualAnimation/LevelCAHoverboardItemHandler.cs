namespace Game.Level.ContextualAnimation;

public class LevelCAHoverboardItemHandler : LevelCASkateboardItemHandler
{
	[SerializeField]
	private Sprite _thumbSprite; //Field offset: 0xC0

	public LevelCAHoverboardItemHandler() { }

	public virtual string GetLockedAnimationName() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public virtual bool TryOverrideConfigThumb(int configIndex, out Sprite sprite) { }

	public virtual bool TryOverrideMainThumb(out Sprite spite) { }

}

