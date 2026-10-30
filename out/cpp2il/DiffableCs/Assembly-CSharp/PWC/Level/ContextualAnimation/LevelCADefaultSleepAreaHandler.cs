namespace PWC.Level.ContextualAnimation;

public class LevelCADefaultSleepAreaHandler : LevelCAParentHandlerBase, IHasPersistentData, IRequirePDSceneObject
{
	internal enum AnimationState
	{
		Lay = 0,
		Sleep = 1,
		Sit = 2,
	}

	[CompilerGenerated]
	private AnimationState <CurrentAnimationState>k__BackingField; //Field offset: 0x80
	private LevelCharacter _currentCharacter; //Field offset: 0x88
	private bool _haveInitialAnimation; //Field offset: 0x90
	private string _initialAnimationName; //Field offset: 0x98
	private bool _initialAnimationLoop; //Field offset: 0xA0
	private TrackEntry _transitionAnimationTrack; //Field offset: 0xA8
	private bool _isInTransitionAnimation; //Field offset: 0xB0
	private readonly List<LevelCAConfig> _layConfigs; //Field offset: 0xB8
	private readonly List<LevelCAConfig> _sleepConfigs; //Field offset: 0xC0
	private readonly List<LevelCAConfig> _sitConfigs; //Field offset: 0xC8

	public private AnimationState CurrentAnimationState
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public LevelCADefaultSleepAreaHandler() { }

	[CompilerGenerated]
	private bool <OnAddedToTarget>b__14_0(LevelCAConfig c) { }

	[CompilerGenerated]
	private bool <OnInitialAnimationEnd>b__15_0(LevelCAConfig c) { }

	public virtual bool CanTargetHoldItems() { }

	[CompilerGenerated]
	public AnimationState get_CurrentAnimationState() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	private void OnInitialAnimationEnd(TrackEntry trackEntry) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	[CompilerGenerated]
	private void set_CurrentAnimationState(AnimationState value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetTransitionMode(bool value) { }

}

