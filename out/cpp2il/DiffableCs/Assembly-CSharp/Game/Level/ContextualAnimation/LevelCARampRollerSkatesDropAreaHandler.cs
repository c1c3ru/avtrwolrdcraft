namespace Game.Level.ContextualAnimation;

public class LevelCARampRollerSkatesDropAreaHandler : LevelCARampDropAreaHandlerBase
{
	private const string MOUNT_ANIMATION_NAME = "Kick_Off"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCARampRollerSkatesDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	protected virtual string GetMountAnimationName() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

