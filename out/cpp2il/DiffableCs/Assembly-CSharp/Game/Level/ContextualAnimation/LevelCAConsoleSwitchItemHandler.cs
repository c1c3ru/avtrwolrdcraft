namespace Game.Level.ContextualAnimation;

public class LevelCAConsoleSwitchItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private LevelToggleableSprite _console; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAConsoleSwitchItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

