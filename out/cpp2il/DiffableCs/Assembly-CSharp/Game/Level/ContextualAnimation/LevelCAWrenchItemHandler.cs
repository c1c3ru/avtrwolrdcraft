namespace Game.Level.ContextualAnimation;

public class LevelCAWrenchItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private UnityEvent onWrenchFix; //Field offset: 0x88
	private LevelLabelHandler _label; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAWrenchItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

