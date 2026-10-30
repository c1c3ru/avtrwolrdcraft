namespace Game.Level.ContextualAnimation;

public class LevelCAWrenchCaftingDropAreaHandler : LevelCADropAreaHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80

	public LevelCAWrenchCaftingDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

