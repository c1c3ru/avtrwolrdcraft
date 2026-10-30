namespace Game.Level.ContextualAnimation;

public class LevelCAHandSanitizerDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private LevelToggleableSpriteForDuration _toggleableSprite; //Field offset: 0x80
	[SerializeField]
	private LevelActiveForDurationOnClick _particles; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAHandSanitizerDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

