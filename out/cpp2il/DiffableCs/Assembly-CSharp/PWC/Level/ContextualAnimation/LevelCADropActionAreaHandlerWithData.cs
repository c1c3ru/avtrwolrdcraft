namespace PWC.Level.ContextualAnimation;

public class LevelCADropActionAreaHandlerWithData : LevelCAHandlerBase
{
	public LevelCAItemHandlerData Data; //Field offset: 0x80
	private int _index; //Field offset: 0x88

	public LevelCADropActionAreaHandlerWithData() { }

	[CompilerGenerated]
	private bool <IsForceToSitWhenPossible>b__10_0(int i) { }

	public virtual bool CanTargetHoldItems() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public LevelCAItemHandlerData GetData() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsForceToSitWhenPossible() { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

