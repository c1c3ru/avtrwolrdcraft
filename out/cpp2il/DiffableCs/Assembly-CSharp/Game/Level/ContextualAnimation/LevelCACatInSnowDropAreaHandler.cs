namespace Game.Level.ContextualAnimation;

public class LevelCACatInSnowDropAreaHandler : LevelCADropAreaHandlerBase
{
	private const string DIG_ANIMATION_NAME = "Dig_Ground_Fast"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80

	public LevelCACatInSnowDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

