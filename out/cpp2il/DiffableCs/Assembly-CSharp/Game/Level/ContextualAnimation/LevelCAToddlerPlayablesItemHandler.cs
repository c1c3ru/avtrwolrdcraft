namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerPlayablesItemHandler : LevelCAItemHandlerBase
{
	private static readonly List<LevelCAConfig> _configs; //Field offset: 0x0
	private static readonly List<LevelCAConfig> _configsWithKnife; //Field offset: 0x8
	protected LevelToddler _toddler; //Field offset: 0x88
	private bool _playableIsKnife; //Field offset: 0x90

	private static LevelCAToddlerPlayablesItemHandler() { }

	public LevelCAToddlerPlayablesItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetAnimationSuffix() { }

	public virtual string GetFolderName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

