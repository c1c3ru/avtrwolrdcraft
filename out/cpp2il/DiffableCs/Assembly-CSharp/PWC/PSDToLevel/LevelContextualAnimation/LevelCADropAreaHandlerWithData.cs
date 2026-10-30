namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCADropAreaHandlerWithData : LevelCADropAreaHandlerBase, IHasCAData
{
	public LevelCAItemHandlerData Data; //Field offset: 0x80
	private List<LevelCAConfig> _allCAConfings; //Field offset: 0x88
	private int _index; //Field offset: 0x90

	public LevelCADropAreaHandlerWithData() { }

	[CompilerGenerated]
	private bool <IsForceToSitWhenPossible>b__10_0(int i) { }

	public virtual bool CanTargetHoldItems() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public override LevelCAItemHandlerData GetData() { }

	public virtual string GetFolderName() { }

	public virtual string GetForcedToSitAnimation(ICATarget target) { }

	public virtual string GetLockedAnimationName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	protected virtual bool IsAllowedInWaterArea() { }

	public virtual bool IsForceToSitWhenPossible() { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

