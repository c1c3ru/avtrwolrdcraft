namespace Game.Level.ContextualAnimation;

public abstract class LevelCACatTreatToyBaseDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private SkeletonAnimation _treatToy; //Field offset: 0x80
	[SerializeField]
	private LevelSimpleSpawner _spawner; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	protected LevelCACatTreatToyBaseDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public abstract string GetDropAreaSide() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public void OnClick(BaseEventData eventData) { }

	private void OnTreatToyEvent(TrackEntry trackEntry, Event e) { }

}

