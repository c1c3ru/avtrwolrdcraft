namespace Game.Level.ContextualAnimation;

public class LevelCAOrigamiBoatItemHandler : LevelCAOrigamiItemHandler
{
	private bool _isDetachItem; //Field offset: 0x90
	protected readonly LevelCAConfig _config; //Field offset: 0x98

	public LevelCAOrigamiBoatItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

