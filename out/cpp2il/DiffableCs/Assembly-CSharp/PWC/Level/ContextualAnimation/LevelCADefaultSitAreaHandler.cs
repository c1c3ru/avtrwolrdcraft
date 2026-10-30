namespace PWC.Level.ContextualAnimation;

public class LevelCADefaultSitAreaHandler : LevelCAParentHandlerBase
{
	protected readonly List<LevelCAConfig> _configs; //Field offset: 0x80
	private bool _isChillingAnimation; //Field offset: 0x88

	public LevelCADefaultSitAreaHandler() { }

	public virtual bool CanTargetHoldItems() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

