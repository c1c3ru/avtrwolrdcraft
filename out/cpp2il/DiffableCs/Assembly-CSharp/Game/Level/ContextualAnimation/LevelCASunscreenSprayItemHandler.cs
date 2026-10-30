namespace Game.Level.ContextualAnimation;

public class LevelCASunscreenSprayItemHandler : LevelCAItemHandlerBase
{
	private string REACTION_ANIMATION_NAME; //Field offset: 0x88
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCASunscreenSprayItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

