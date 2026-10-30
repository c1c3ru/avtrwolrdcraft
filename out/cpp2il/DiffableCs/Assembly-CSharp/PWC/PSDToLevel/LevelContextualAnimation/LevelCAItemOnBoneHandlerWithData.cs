namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCAItemOnBoneHandlerWithData : LevelCAItemOnBoneHandlerBase, IHasCAData
{
	public LevelCAItemHandlerData Data; //Field offset: 0x98

	public LevelCAItemOnBoneHandlerWithData() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	private override LevelCAItemHandlerData PWC.LevelContextualAnimation.IHasCAData.GetData() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

