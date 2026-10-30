namespace PWC.Level;

public class LevelDropAreaEventOnAvatarAnimationHandler : MonoBehaviour, ILevelSpawnDuringGameplay
{
	private class AnimationEventEntry
	{
		[SerializeField]
		public string fullAnimationName; //Field offset: 0x10
		[SerializeField]
		public UnityEvent OnAnimationBeginAction; //Field offset: 0x18
		[SerializeField]
		public UnityEvent OnAnimationEndAction; //Field offset: 0x20

		public AnimationEventEntry() { }

	}

	[SerializeField]
	private List<AnimationEventEntry> _animationEvents; //Field offset: 0x20
	[SerializeField]
	private bool _invokeEndActionOnPickUp; //Field offset: 0x28
	private LevelDropArea _dropArea; //Field offset: 0x30
	private ICATarget _cachedTarget; //Field offset: 0x38
	private readonly List<Int32> _playingAnimationIndexes; //Field offset: 0x40
	private readonly List<Int32> _flushBuffer; //Field offset: 0x48

	public LevelDropAreaEventOnAvatarAnimationHandler() { }

	private void Awake() { }

	private void CacheCurrentTarget() { }

	private void InvokePendingEndActions() { }

	private void OnAnimationBeginStatic(ICATarget target, LevelCAConfig config, string fullAnimationName) { }

	private void OnAnimationEndStatic(ICATarget target, LevelCAConfig config, string fullAnimationName) { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

	private void SetCachedTarget(ICATarget target) { }

}

