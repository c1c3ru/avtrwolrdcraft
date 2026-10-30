namespace Game.Level.ContextualAnimation;

public class LevelCAWindsurfDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	protected LevelDropArea _dropArea; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAWindsurfDropAreaHandler() { }

	public virtual bool CanTargetHoldItems() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

