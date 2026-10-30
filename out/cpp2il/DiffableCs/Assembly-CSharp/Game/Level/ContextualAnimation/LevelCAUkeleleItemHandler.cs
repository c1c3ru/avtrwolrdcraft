namespace Game.Level.ContextualAnimation;

public class LevelCAUkeleleItemHandler : LevelCAMusicalInstrumentItemHandlerBase
{
	[SerializeField]
	private Sprite _thumb; //Field offset: 0xD8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xE0

	public LevelCAUkeleleItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	protected virtual string GetSkinName() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

