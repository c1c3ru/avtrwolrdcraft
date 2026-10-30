namespace Game.Level;

public class LevelCAAnimationSpineEventEventsByArguments : MonoBehaviour
{
	internal class EventWithArguments
	{
		[Header("Conditions")]
		[Tooltip("Will disregard if null or empty. Otherwise, will force the Spine Event name to be equal to it.")]
		public string SpineEventName; //Field offset: 0x10
		[Tooltip("Will disregard if negative (i.e. -1). Otherwise, will force the index of the track on Spine Event index to be equal to it.")]
		public int TrackIndex; //Field offset: 0x18
		[Tooltip("Will disregard if negative (i.e. -1). Otherwise, will force the index of the animation to be equal to it.")]
		public int AnimationIndex; //Field offset: 0x1C
		[Header("Event")]
		[Space]
		public UnityEvent<LevelCAHandlerBase, ICATarget, TrackEntry, Event> Event; //Field offset: 0x20

		public EventWithArguments() { }

		public bool TryInvoke(LevelCAHandlerBase levelCAHandler, ICATarget target, TrackEntry track, Event spineEvent, LevelCAConfig config) { }

	}

	[Header("CA Handlers To Listen To")]
	[SerializeField]
	protected LevelCAHandlerBase[] _levelCAHandlers; //Field offset: 0x20
	[Header("Spine Events By Arguments")]
	[SerializeField]
	[Space]
	protected EventWithArguments[] _spineAnimationEvents; //Field offset: 0x28
	private readonly Dictionary<LevelCAHandlerBase, LevelCAConfig> _currentConfigByHandler; //Field offset: 0x30

	public LevelCAAnimationSpineEventEventsByArguments() { }

	protected override void Awake() { }

	private void OnAnimationBeginHandler(LevelCAHandlerBase levelCAHandler, ICATarget target, LevelCAConfig config) { }

	private void OnAnimationEndHandler(LevelCAHandlerBase levelCAHandler, ICATarget target, LevelCAConfig config) { }

	protected override void OnAnimationEventHandler(LevelCAHandlerBase levelCAHandler, ICATarget target, TrackEntry track, Event spineEvent) { }

	protected override void OnDestroy() { }

}

