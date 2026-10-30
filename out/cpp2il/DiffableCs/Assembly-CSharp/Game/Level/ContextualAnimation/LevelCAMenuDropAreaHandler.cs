namespace Game.Level.ContextualAnimation;

public class LevelCAMenuDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private Sprite _thumb; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAMenuDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

