namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCAHandlerWithData : LevelCAHandlerBase, IHasCAData
{
	public LevelCAItemHandlerData Data; //Field offset: 0x80

	public LevelCAHandlerWithData() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual CACategoryType GetCategoryType() { }

	public override LevelCAItemHandlerData GetData() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	protected virtual bool IsAllowedInWaterArea() { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

