namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerStandingHandler : LevelCAHandlerBase
{
	private const string TRANSITION_ANIMATION_NAME = "Fall_On_Butt"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80
	private LevelToddler _toddler; //Field offset: 0x88

	public LevelCAToddlerStandingHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

