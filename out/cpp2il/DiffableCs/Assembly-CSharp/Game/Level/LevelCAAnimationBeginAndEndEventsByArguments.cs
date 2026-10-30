namespace Game.Level;

public class LevelCAAnimationBeginAndEndEventsByArguments : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public LevelCAAnimationBeginAndEndEventsByArguments <>4__this; //Field offset: 0x10
		public LevelCAHandlerBase levelCAHandler; //Field offset: 0x18
		public ICATarget target; //Field offset: 0x20
		public LevelCAConfig config; //Field offset: 0x28

		public <>c__DisplayClass10_0() { }

		internal void <OnAnimationPostBeginAction>g__OnInterrupt|0(TrackEntry trackEntry) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public LevelCAAnimationBeginAndEndEventsByArguments <>4__this; //Field offset: 0x10
		public LevelCAHandlerBase levelCAHandler; //Field offset: 0x18
		public ICATarget target; //Field offset: 0x20
		public LevelCAConfig config; //Field offset: 0x28

		public <>c__DisplayClass8_0() { }

		internal void <OnAnimationBeginHandler>b__0(LevelItem levelItem) { }

	}

	internal class EventWithArguments
	{
		[Header("Conditions")]
		[Tooltip("Will disregard if null or empty. Otherwise, will force the Spine Event name to be equal to it.")]
		public string AnimationName; //Field offset: 0x10
		[Tooltip("Will disregard if negative (i.e. -1). Otherwise, will force the index of the track on Spine Event index to be equal to it.")]
		public int AnimationIndex; //Field offset: 0x18
		[Tooltip("If set to any value will only envoke event when the target has the right CAPlayType")]
		public CAPlayType EnsureCAPlayType; //Field offset: 0x1C
		[SerializeField]
		private bool _invokeOnSpecificAvatarOnly; //Field offset: 0x20
		[ConditionalField("_invokeOnSpecificAvatarOnly", True, True, (array) null)]
		[SerializeField]
		private int _avatarID; //Field offset: 0x24
		[Header("Event")]
		[Space]
		public UnityEvent<LevelCAHandlerBase, ICATarget, LevelCAConfig> Event; //Field offset: 0x28

		public EventWithArguments() { }

		public bool TryInvoke(LevelCAHandlerBase levelCAHandler, ICATarget target, LevelCAConfig config) { }

	}

	[Header("CA Handlers To Listen To")]
	[SerializeField]
	protected LevelCAHandlerBase[] _levelCAHandlers; //Field offset: 0x20
	[Header("On Begin Events And Their Arguments")]
	[SerializeField]
	[Space]
	protected EventWithArguments[] _onAnimationBeginEventWithArgs; //Field offset: 0x28
	[Header("On End Events And Their Arguments")]
	[SerializeField]
	[Space]
	protected EventWithArguments[] _onAnimationEndEventWithArgs; //Field offset: 0x30
	[SerializeField]
	protected bool _checkOnInterrupt; //Field offset: 0x38
	private Action<LevelItem> OnBeforeDestroyWhileInGameplay; //Field offset: 0x40

	public LevelCAAnimationBeginAndEndEventsByArguments() { }

	protected override void Awake() { }

	protected override void OnAnimationBeginHandler(LevelCAHandlerBase levelCAHandler, ICATarget target, LevelCAConfig config) { }

	protected override void OnAnimationEndHandler(LevelCAHandlerBase levelCAHandler, ICATarget target, LevelCAConfig config) { }

	private void OnAnimationPostBeginAction(LevelCAHandlerBase levelCAHandler, ICATarget target, LevelCAConfig config, TrackEntry trackEntry) { }

	protected override void OnDestroy() { }

}

