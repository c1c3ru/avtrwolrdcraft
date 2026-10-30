namespace PWC.Level.ContextualAnimation;

public abstract class LevelCADropAreaHandlerBase : LevelCAParentHandlerBase
{

	protected LevelCADropAreaHandlerBase() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

