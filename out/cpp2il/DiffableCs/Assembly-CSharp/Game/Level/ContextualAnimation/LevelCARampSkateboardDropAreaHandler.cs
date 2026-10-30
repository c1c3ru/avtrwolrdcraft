namespace Game.Level.ContextualAnimation;

public class LevelCARampSkateboardDropAreaHandler : LevelCARampDropAreaHandlerBase
{
	private const string MOUNT_ANIMATION_NAME = "Skateboard_Cycle_Mount"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCARampSkateboardDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	protected virtual string GetMountAnimationName() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

}

