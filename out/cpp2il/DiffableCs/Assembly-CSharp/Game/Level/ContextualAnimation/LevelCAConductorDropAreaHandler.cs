namespace Game.Level.ContextualAnimation;

public class LevelCAConductorDropAreaHandler : LevelCADropAreaHandlerWithData
{
	[SerializeField]
	private List<String> _animationNames; //Field offset: 0x98
	[SerializeField]
	private bool _isAvatarOnDropAreaOnly; //Field offset: 0xA0
	[ConditionalField("_isAvatarOnDropAreaOnly", True, True, (array) null)]
	[SerializeField]
	private LevelDropArea _avatarsOnDropAreaOnly; //Field offset: 0xA8
	[SerializeField]
	private bool _doNotStopAnimationsOnOthers; //Field offset: 0xB0
	private int _currentAnimationPlayingIndex; //Field offset: 0xB4

	public LevelCAConductorDropAreaHandler() { }

	private bool AnimationNameExists(LevelCAConfig config, out int index) { }

	protected virtual void Awake() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	private void SetAnimationOnOther(IHaveAnimationSearch specialAnimationNames, LevelCharacter character, bool isActive) { }

}

