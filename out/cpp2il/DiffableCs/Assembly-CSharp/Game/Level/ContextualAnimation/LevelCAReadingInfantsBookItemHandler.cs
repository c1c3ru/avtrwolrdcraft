namespace Game.Level.ContextualAnimation;

public class LevelCAReadingInfantsBookItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private Sprite _thumb; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAReadingInfantsBookItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

