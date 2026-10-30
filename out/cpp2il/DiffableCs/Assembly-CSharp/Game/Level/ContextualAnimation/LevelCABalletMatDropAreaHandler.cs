namespace Game.Level.ContextualAnimation;

public class LevelCABalletMatDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private Sprite _sprite; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCABalletMatDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool TryOverrideMainThumb(out Sprite spite) { }

}

