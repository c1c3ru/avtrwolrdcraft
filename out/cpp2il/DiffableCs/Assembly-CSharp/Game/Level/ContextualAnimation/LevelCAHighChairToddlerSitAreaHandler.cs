namespace Game.Level.ContextualAnimation;

public class LevelCAHighChairToddlerSitAreaHandler : LevelCAParentHandlerBase
{
	[SerializeField]
	private LevelDropArea _trayDropArea; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAHighChairToddlerSitAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual string GetSpacialTrackAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

