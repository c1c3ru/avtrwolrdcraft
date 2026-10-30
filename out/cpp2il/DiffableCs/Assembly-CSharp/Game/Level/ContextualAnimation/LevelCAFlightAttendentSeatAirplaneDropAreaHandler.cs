namespace Game.Level.ContextualAnimation;

public class LevelCAFlightAttendentSeatAirplaneDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private LevelSitArea _sitArea; //Field offset: 0x80
	private bool _isBeltOn; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAFlightAttendentSeatAirplaneDropAreaHandler() { }

	private void AddBelt(LevelCharacter character) { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void OnAvatarPickUp(LevelAvatarRestAreaBase sitArea, ILevelAvatar avatar) { }

	protected virtual void OnDestroy() { }

	private void RemoveBelt(LevelCharacter character) { }

}

