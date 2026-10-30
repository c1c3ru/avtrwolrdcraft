namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCAItemHandlerWithData : LevelCAItemHandlerBase, IHasCAData
{
	public LevelCAItemHandlerData Data; //Field offset: 0x88

	public LevelCAItemHandlerWithData() { }

	private void EnsureHand(ICATarget target, string boneName) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public override LevelCAItemHandlerData GetData() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	protected virtual bool IsAllowedInWaterArea() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

