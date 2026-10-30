namespace PWC.Level.ContextualAnimation;

public abstract class LevelCAParentHandlerBase : LevelCAHandlerBase
{

	protected LevelCAParentHandlerBase() { }

	public virtual bool IsForceToSitWhenPossible() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

