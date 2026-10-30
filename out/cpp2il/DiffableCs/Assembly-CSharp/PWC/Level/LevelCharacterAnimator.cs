namespace PWC.Level;

public class LevelCharacterAnimator
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_0
	{
		public int trackIndex; //Field offset: 0x10
		public LevelCharacterAnimator <>4__this; //Field offset: 0x18
		public string previousAnimationName; //Field offset: 0x20
		public bool loop; //Field offset: 0x28
		public int previousTrackIndex; //Field offset: 0x2C

		public <>c__DisplayClass35_0() { }

		internal void <PlayAnimationAndReturnToPrevious>b__0(TrackEntry x) { }

	}

	internal enum MovementType
	{
		None = 0,
		Stand = 1,
		Walk = 2,
		Run = 3,
	}

	private readonly SkeletonAnimation _skeletonAnimation; //Field offset: 0x10
	private readonly LevelCharacter _character; //Field offset: 0x18
	private HashSet<Int32> _topBonesIndexes; //Field offset: 0x20
	[CompilerGenerated]
	private Func<Boolean> OverridePlayProperIdleAnimationAction; //Field offset: 0x28
	private MovementType _movementType; //Field offset: 0x30
	private bool _forceNormalDragging; //Field offset: 0x34
	private bool _canForceNormalDragging; //Field offset: 0x35
	private Vector2 _positionOnBeginDrag; //Field offset: 0x38
	private Nullable<Vector2> _lastMovementPosition; //Field offset: 0x40
	private bool _isLockedAnimationWhenWalking; //Field offset: 0x4C
	private string _currentAnimationName; //Field offset: 0x50
	private float _walkTrackStartTime; //Field offset: 0x58
	private bool _walkStartLoop; //Field offset: 0x5C
	private LevelCharacterMovementOverrideHandler _movementOverrideHandler; //Field offset: 0x60
	[CompilerGenerated]
	private Action<LevelCharacter, Event> OnStepContact; //Field offset: 0x68
	private bool wasStepContactEventAdded; //Field offset: 0x70
	private TrackEntryEventDelegate _stepEventHandler; //Field offset: 0x78

	public event Action<LevelCharacter, Event> OnStepContact
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Func<Boolean> OverridePlayProperIdleAnimationAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelCharacterAnimator(LevelCharacter character, SkeletonAnimation skeletonAnimation) { }

	[CompilerGenerated]
	private void <EnsureTopBonesIndexes>g__TryAddBoneChildren|42_0(string boneName) { }

	[CompilerGenerated]
	private void <OnMovement>b__27_0(TrackEntry trackEntry, Event spineEvent) { }

	[CompilerGenerated]
	private void <PlayAnimationAndReturnToProperIdle>b__34_0(TrackEntry _) { }

	[CompilerGenerated]
	private LevelCharacterMovementOverrideHandler <UpdateMovementOverrideHandler>g__GetHeldItem|26_0(AvatarHandType handType) { }

	[CompilerGenerated]
	public void add_OnStepContact(Action<LevelCharacter, Event> value) { }

	[CompilerGenerated]
	public void add_OverridePlayProperIdleAnimationAction(Func<Boolean> value) { }

	public TrackEntry AddAnimation(string animationName, bool loop, bool ensureRequiredTextures = false, int trackIndex = 0, bool useTopBonesOnly = false) { }

	private void EnsureTopBonesIndexes() { }

	private LevelItemOnCharacterBase GetCurrentBehaviorItem() { }

	public MovementType GetMovementType() { }

	private bool IsLastFallHigh() { }

	public void OnBeginMovement() { }

	public void OnEndLand() { }

	public void OnEndMovement() { }

	public void OnMovement() { }

	public TrackEntry PlayAnimationAndReturnToPrevious(string animationName, bool ensureRequiredTextures = false, int trackIndex = 0) { }

	public TrackEntry PlayAnimationAndReturnToProperIdle(string animationName, bool ensureRequiredTextures = false, int trackIndex = 0) { }

	public TrackEntry PlayAnimationAndReturnToStandIdle(string animationName, bool ensureRequiredTextures = false, int trackIndex = 0) { }

	public void PlayIdleAnimationOnCharacterInit() { }

	public void PlayProperIdleAnimation() { }

	public TrackEntry PlayStandIdleAnimation() { }

	[CompilerGenerated]
	public void remove_OnStepContact(Action<LevelCharacter, Event> value) { }

	[CompilerGenerated]
	public void remove_OverridePlayProperIdleAnimationAction(Func<Boolean> value) { }

	private TrackEntry SetAddAnimationInternal(string animationName, bool loop, bool ensureRequiredTextures, int trackIndex, bool add, bool useTopBonesOnly = false) { }

	public TrackEntry SetAnimation(string animationName, bool loop = false, bool ensureRequiredTextures = false, int trackIndex = 0, bool useTopBonesOnly = false) { }

	public void SetEmtyAnimation(int trackIndex, float mixDuration = 0) { }

	private bool ShouldPlayFallHighAnimation() { }

	private void UpdateMovementOverrideHandler() { }

}

