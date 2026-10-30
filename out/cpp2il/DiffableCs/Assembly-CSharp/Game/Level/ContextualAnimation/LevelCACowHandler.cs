namespace Game.Level.ContextualAnimation;

public class LevelCACowHandler : LevelCAHandlerBase
{
	[SerializeField]
	private CowType _cowType; //Field offset: 0x80
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCACowHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	protected virtual bool IsAllowedInWaterArea() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

