namespace Game.Level.ContextualAnimation;

public class LevelCACarToddlerSitAreaHandler : LevelCAParentHandlerBase
{
	[SerializeField]
	private Sprite _overrideMainThumb; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCACarToddlerSitAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

