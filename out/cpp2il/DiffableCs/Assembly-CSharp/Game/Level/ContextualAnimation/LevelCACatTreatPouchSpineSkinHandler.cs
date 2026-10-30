namespace Game.Level.ContextualAnimation;

public class LevelCACatTreatPouchSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCACatTreatPouchSpineSkinHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

