namespace Game.Level.ContextualAnimation;

public class LevelCALadderDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private Sprite _overrideThumb; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCALadderDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

