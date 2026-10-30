namespace Game.Level.ContextualAnimation;

public class LevelCAMovingWalkwayDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private Sprite _mainThumb; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAMovingWalkwayDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

