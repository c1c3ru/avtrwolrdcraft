namespace Game.Level.ContextualAnimation;

public class LevelCASleepingToddlerDropAreaHandler : LevelCADropAreaHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80

	public LevelCASleepingToddlerDropAreaHandler() { }

	public virtual bool CanTargetHoldItems() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsSingleCAInMenu() { }

}

