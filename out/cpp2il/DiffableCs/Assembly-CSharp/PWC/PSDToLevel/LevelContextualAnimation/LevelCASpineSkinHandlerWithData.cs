namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCASpineSkinHandlerWithData : LevelCASpineSkinHandlerBase, IHasCAData
{
	public LevelCAItemHandlerData Data; //Field offset: 0x98

	public LevelCASpineSkinHandlerWithData() { }

	public virtual bool CanTargetHoldItems() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	private override LevelCAItemHandlerData PWC.LevelContextualAnimation.IHasCAData.GetData() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

