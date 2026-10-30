namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCAItemWithSkinHandlerWithData : LevelCAItemWithSkinHandlerBase, IHasCAData
{
	public LevelCAItemHandlerData Data; //Field offset: 0xB0

	public LevelCAItemWithSkinHandlerWithData() { }

	private void EnsureHand(ICATarget target) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public override LevelCAItemHandlerData GetData() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual int GetPriority() { }

	protected virtual string GetSkinName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

