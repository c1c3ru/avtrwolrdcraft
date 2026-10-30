namespace Game.Level;

public class LevelReactionOfAvatarsOnCAAnimationHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public string animationName; //Field offset: 0x10

		public <>c__DisplayClass32_0() { }

		internal bool <FindReactionIfExist>b__0(ReactionAnimationData x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass38_0
	{
		public Vector3 holderPosition; //Field offset: 0x10
		public LevelReactionOfAvatarsOnCAAnimationHandler <>4__this; //Field offset: 0x20
		public ReactionAnimationData reactionAnimationdata; //Field offset: 0x28

		public <>c__DisplayClass38_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass38_1
	{
		public ILevelAvatar avatar; //Field offset: 0x10
		public <>c__DisplayClass38_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass38_1() { }

		internal void <PlayAnimationOnRelevantAvatars>b__0(TrackEntry x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass38_2
	{
		public LevelItem avatarItem; //Field offset: 0x10
		public bool isReactionLooped; //Field offset: 0x18
		public <>c__DisplayClass38_1 CS$<>8__locals2; //Field offset: 0x20

		public <>c__DisplayClass38_2() { }

		internal void <PlayAnimationOnRelevantAvatars>b__1(TrackEntry x) { }

		internal void <PlayAnimationOnRelevantAvatars>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass41_0
	{
		public SpineType spineType; //Field offset: 0x10
		public LevelReactionOfAvatarsOnCAAnimationHandler <>4__this; //Field offset: 0x18

		public <>c__DisplayClass41_0() { }

		internal bool <TryGetRandomAvatarInRadius>b__0(ILevelAvatar x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass42_0
	{
		public int specificReactionAvatarID; //Field offset: 0x10
		public LevelReactionOfAvatarsOnCAAnimationHandler <>4__this; //Field offset: 0x18

		public <>c__DisplayClass42_0() { }

		internal bool <TryGetSpecificAvatarInRadius>b__0(ILevelAvatar x) { }

	}

	[SerializeField]
	private float _radius; //Field offset: 0x20
	[SerializeField]
	private float _fromDistance; //Field offset: 0x24
	[SerializeField]
	private bool _onlySittingAvatars; //Field offset: 0x28
	[SerializeField]
	private LevelCAReactionsData _reactionData; //Field offset: 0x30
	[SerializeField]
	private LevelCAHandlerBase _cAHandlerBase; //Field offset: 0x38
	[SerializeField]
	[Tooltip("Only set a reference here if you need another avatar to react with an animation on a specific drop area")]
	private LevelDropArea _refDropArea; //Field offset: 0x40
	[SerializeField]
	private LevelType _requiredLevel; //Field offset: 0x48
	[SerializeField]
	private LevelSitArea _refSitArea; //Field offset: 0x50
	[SerializeField]
	[Tooltip("Same filter as _refDropArea, but matched by the drop area's LevelLabelHandler instead of by reference. Use this when the handler lives on a runtime spawned prefab, which cannot hold a scene reference. Takes precedence over _refDropArea / _refSitArea when set.")]
	private string _refDropAreaLabel; //Field offset: 0x58
	[SerializeField]
	private int _minReactingAvatarsCount; //Field offset: 0x60
	[SerializeField]
	private bool _requireSpecificInitiatingAvatar; //Field offset: 0x64
	[ConditionalField("_requireSpecificInitiatingAvatar", True, True, (array) null)]
	[SerializeField]
	private int _requiredInitiatingAvatarID; //Field offset: 0x68
	public UnityEvent<ILevelAvatar> eventOnAvatarsInRadius; //Field offset: 0x70
	public UnityEvent<ILevelAvatar> eventOnReactionBegin; //Field offset: 0x78
	public UnityEvent<ILevelAvatar> eventOnReactionEnd; //Field offset: 0x80
	public UnityEvent<ILevelAvatar> OnFindRandomAvatarInRadiusAction; //Field offset: 0x88
	public UnityEvent<ILevelAvatar> OnFindClosestAvatarInRadiusAction; //Field offset: 0x90
	public UnityEvent OnMinReactingAvatarCountReached; //Field offset: 0x98
	[SerializeField]
	private float _xCenter; //Field offset: 0xA0
	[SerializeField]
	private float _yCenter; //Field offset: 0xA4
	[SerializeField]
	private bool _isEnsureAvatarSpineType; //Field offset: 0xA8
	private Dictionary<Int32, Int32> _tweenIdDict; //Field offset: 0xB0
	private List<ILevelAvatar> _effectedAvatars; //Field offset: 0xB8
	private ILevelAvatar _initiatingAvatar; //Field offset: 0xC0

	public LevelCAReactionsData reactionsData
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	private void _cAHandlerBase_OnAnimationBeginAction(LevelCAHandlerBase handler, ICATarget target, LevelCAConfig config) { }

	private void _cAHandlerBase_OnAnimationEndAction(LevelCAHandlerBase handler, ICATarget target, LevelCAConfig config) { }

	private void _cAHandlerBase_OnAnimationEventAction(LevelCAHandlerBase handler, ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public LevelReactionOfAvatarsOnCAAnimationHandler() { }

	private void Awake() { }

	private ReactionAnimationData FindReactionIfExist(string animationName) { }

	public LevelCAReactionsData get_reactionsData() { }

	private bool IsAvatarClose(ILevelAvatar avatar) { }

	private bool IsAvatarCloseAndOnCorrectDropArea(ILevelAvatar avatar) { }

	private bool IsAvatarOnCorrectDropArea(ILevelAvatar avatar) { }

	private bool IsAvatarOnLabeledDropArea(ILevelAvatar avatar) { }

	private void OnCompleteFullCycle(TrackEntry trackEntry, ILevelAvatar avatar, ILevelAvatar initiatingAvatar, string initiatingAnimationName, bool isReactionLooped) { }

	private void OnDestroy() { }

	private void OnInterruptOrEnd(TrackEntry trackEntry, ILevelAvatar avatar, ILevelAvatar initiatingAvatar) { }

	public void PlayAnimationOnClosestAvatar_DropAreaCA(string animationName) { }

	public void PlayAnimationOnClosestAvatar_ItemCA(string animationName) { }

	private void PlayAnimationOnRelevantAvatars(ReactionAnimationData reactionAnimationdata) { }

	private void ReturnToIdle(ILevelAvatar avatar) { }

	public void SearchForAvatarsToInvoke() { }

	public void set_reactionsData(LevelCAReactionsData value) { }

	public void SetCAHandlerBase(LevelCAHandlerBase levelCAHandler) { }

	public void SetCircleCenterLocalPosition(float x, float y) { }

	public void SetRadius(float radius) { }

	private bool ShouldFireEvents() { }

	private bool TryGetAvatarsInRadius(SpineType spineType, out List<ILevelAvatar>& effectedAvatars) { }

	private bool TryGetAvatarsOnDropArea(SpineType spineType, LevelConsumerAreaBase dropArea, out List<ILevelAvatar>& effectedAvatars) { }

	protected bool TryGetClosestCharacter(SpineType spineType, out ILevelAvatar effectedAvatar, float minDistance = 100000, float fromDistance = 0) { }

	private bool TryGetRandomAvatarInRadius(SpineType spineType, out ILevelAvatar effectedAvatar) { }

	private bool TryGetSpecificAvatarInRadius(int specificReactionAvatarID, out ILevelAvatar effectedAvatar) { }

}

