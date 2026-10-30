namespace Game.Level;

public class LevelSpineObjectEventHelper : MonoBehaviour
{
	private struct AnimationEvent
	{
		public string EventName; //Field offset: 0x0
		public UnityEvent OnAnimationEvent; //Field offset: 0x8

	}

	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	[SerializeField]
	private GameSoundPlayer _gameSoundPlayer; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onAnimationBegin; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onAnimationEnd; //Field offset: 0x38
	[SerializeField]
	private bool _eventsOnSpecificAnimations; //Field offset: 0x40
	[SerializeField]
	private List<String> _animationNamesForEvents; //Field offset: 0x48
	[SerializeField]
	private List<AnimationEvent> _onAnimationEvents; //Field offset: 0x50

	public LevelSpineObjectEventHelper() { }

	private void Awake() { }

	public void ContinueCurrentAnimation() { }

	private void OnAnimationBegin(TrackEntry trackEntry) { }

	private void OnAnimationEnd(TrackEntry trackEntry) { }

	private void OnAnimationEvent(TrackEntry trackEntry, Event spineEvent) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public void PauseCurrentAnimation() { }

	public void PlayAnimation(string animationName) { }

	private void PlayAnimation(string animationName, bool loop) { }

	public void PlayLoopAnimation(string animationName) { }

	private void TrackEntry_End(TrackEntry trackEntry) { }

}

