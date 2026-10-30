namespace Game.Level.ContextualAnimation;

public class LevelCAProjectorScreenDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private LevelDoor _screen; //Field offset: 0x80
	[SerializeField]
	private LevelToggleableSprite _projector; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAProjectorScreenDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	private bool IsProjectorOn() { }

	private bool IsScreenOpen() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	protected virtual void OnLevelPostInit() { }

}

