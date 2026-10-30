namespace Game.Level.ContextualAnimation;

public class LevelCATurtleHandler : LevelCAHandlerBase
{
	[SerializeField]
	private TurtleType _turtleType; //Field offset: 0x80
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCATurtleHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	protected virtual bool IsAllowedInWaterArea() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

