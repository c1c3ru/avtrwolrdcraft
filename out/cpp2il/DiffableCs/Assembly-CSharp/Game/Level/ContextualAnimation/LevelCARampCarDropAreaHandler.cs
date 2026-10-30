namespace Game.Level.ContextualAnimation;

public class LevelCARampCarDropAreaHandler : LevelCARampDropAreaHandlerBase
{
	private const string MOUNT_ANIMATION_NAME = "Start_Ride"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCARampCarDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	protected virtual string GetMountAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

