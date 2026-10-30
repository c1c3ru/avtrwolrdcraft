namespace Game.Level.ContextualAnimation;

public class LevelCABottomClothingItemHandler : LevelCAItemHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCABottomClothingItemHandler() { }

	private void FixOffset() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual bool TryOverrideMainThumb(out Sprite spite) { }

}

