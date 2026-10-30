namespace Game.Level.ContextualAnimation;

public class LevelCADrumsMusicClassroomHandler : LevelCAMusicalInstrumentWithSpecialNamesWithCADataDropAreaHandler
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0xB0
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _idleAnimation; //Field offset: 0xB8
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _transitionAnimationsNames; //Field offset: 0xC0
	[SerializeField]
	private string _label; //Field offset: 0xC8
	[SerializeField]
	private String[] _withSticksAnimations; //Field offset: 0xD0
	[SerializeField]
	private String[] _withoutSticksAnimations; //Field offset: 0xD8
	private bool _isItemsAvailable; //Field offset: 0xE0
	private LevelCharacter _character; //Field offset: 0xE8

	public LevelCADrumsMusicClassroomHandler() { }

	private bool FindConfigFromStrings(String[] animationNames, LevelCAConfig config) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual LevelCAConfig GetCAConfigByAnimationName(string animationName) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

