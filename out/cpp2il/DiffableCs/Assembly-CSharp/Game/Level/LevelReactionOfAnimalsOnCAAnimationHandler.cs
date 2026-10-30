namespace Game.Level;

public class LevelReactionOfAnimalsOnCAAnimationHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_0
	{
		public string animationName; //Field offset: 0x10

		public <>c__DisplayClass31_0() { }

		internal bool <FindReactionIfExist>b__0(ReactionAnimationData x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass36_0
	{
		public Vector3 holderPosition; //Field offset: 0x10
		public LevelReactionOfAnimalsOnCAAnimationHandler <>4__this; //Field offset: 0x20
		public ReactionAnimationData reactionAnimationdata; //Field offset: 0x28

		public <>c__DisplayClass36_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass36_1
	{
		public LevelAnimal animal; //Field offset: 0x10
		public <>c__DisplayClass36_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass36_1() { }

		internal void <PlayAnimationOnRelevantAnimals>b__0(TrackEntry x) { }

		internal void <PlayAnimationOnRelevantAnimals>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass36_2
	{
		public bool isReactionLooped; //Field offset: 0x10
		public <>c__DisplayClass36_1 CS$<>8__locals2; //Field offset: 0x18

		public <>c__DisplayClass36_2() { }

		internal void <PlayAnimationOnRelevantAnimals>b__1(TrackEntry x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass40_0
	{
		public SpineType spineType; //Field offset: 0x10
		public LevelReactionOfAnimalsOnCAAnimationHandler <>4__this; //Field offset: 0x18

		public <>c__DisplayClass40_0() { }

		internal bool <TryGetRandomAnimalInRadius>b__0(LevelAnimal x) { }

	}

	[CompilerGenerated]
	private sealed class <GetAllAnimals>d__39 : IEnumerable<LevelAnimal>, IEnumerable, IEnumerator<LevelAnimal>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private LevelAnimal <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private Enumerator<LevelItem> <>7__wrap1; //Field offset: 0x28

		private override LevelAnimal System.Collections.Generic.IEnumerator<PWC.Level.LevelAnimal>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <GetAllAnimals>d__39(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<LevelAnimal> System.Collections.Generic.IEnumerable<PWC.Level.LevelAnimal>.GetEnumerator() { }

		[DebuggerHidden]
		private override LevelAnimal System.Collections.Generic.IEnumerator<PWC.Level.LevelAnimal>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[SerializeField]
	private float _radius; //Field offset: 0x20
	[SerializeField]
	private float _fromDistance; //Field offset: 0x24
	[SerializeField]
	private bool _onlySittingAnimals; //Field offset: 0x28
	[SerializeField]
	private LevelCAReactionsData _reactionData; //Field offset: 0x30
	[SerializeField]
	private LevelCAHandlerBase _cAHandlerBase; //Field offset: 0x38
	[SerializeField]
	[Tooltip("Only set a reference here if you need another animal to react with an animation on a specific drop area")]
	private LevelDropArea _refDropArea; //Field offset: 0x40
	[SerializeField]
	private LevelType _requiredLevel; //Field offset: 0x48
	[SerializeField]
	private LevelSitArea _refSitArea; //Field offset: 0x50
	[SerializeField]
	private int _minReactingAnimalsCount; //Field offset: 0x58
	[SerializeField]
	private bool _requireSpecificInitiatingAvatar; //Field offset: 0x5C
	[ConditionalField("_requireSpecificInitiatingAvatar", True, True, (array) null)]
	[SerializeField]
	private int _requiredInitiatingAvatarID; //Field offset: 0x60
	public UnityEvent<LevelAnimal> eventOnAnimalsInRadius; //Field offset: 0x68
	public UnityEvent<LevelAnimal> eventOnReactionBegin; //Field offset: 0x70
	public UnityEvent<LevelAnimal> eventOnReactionEnd; //Field offset: 0x78
	public UnityEvent<LevelAnimal> OnFindRandomAnimalInRadiusAction; //Field offset: 0x80
	public UnityEvent<LevelAnimal> OnFindClosestAnimalInRadiusAction; //Field offset: 0x88
	public UnityEvent OnMinReactingAnimalCountReached; //Field offset: 0x90
	[SerializeField]
	private float _xCenter; //Field offset: 0x98
	[SerializeField]
	private float _yCenter; //Field offset: 0x9C
	[SerializeField]
	private bool _isEnsureAnimalSpineType; //Field offset: 0xA0
	private Dictionary<Int32, Int32> _tweenIdDict; //Field offset: 0xA8
	private ILevelAvatar _initiatingAvatar; //Field offset: 0xB0

	public LevelCAReactionsData reactionsData
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	private void _cAHandlerBase_OnAnimationBeginAction(LevelCAHandlerBase handler, ICATarget target, LevelCAConfig config) { }

	private void _cAHandlerBase_OnAnimationEndAction(LevelCAHandlerBase handler, ICATarget target, LevelCAConfig config) { }

	private void _cAHandlerBase_OnAnimationEventAction(LevelCAHandlerBase handler, ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public LevelReactionOfAnimalsOnCAAnimationHandler() { }

	private void Awake() { }

	private ReactionAnimationData FindReactionIfExist(string animationName) { }

	public LevelCAReactionsData get_reactionsData() { }

	[IteratorStateMachine(typeof(<GetAllAnimals>d__39))]
	private IEnumerable<LevelAnimal> GetAllAnimals() { }

	private bool IsAnimalClose(LevelAnimal animal) { }

	private bool IsAnimalCloseAndOnCorrectDropArea(LevelAnimal animal) { }

	private bool IsAnimalOnCorrectDropArea(LevelAnimal animal) { }

	private bool IsInitiatingAvatar(LevelAnimal animal) { }

	private void OnCompleteFullCycle(TrackEntry trackEntry, LevelAnimal animal, ILevelAvatar initiatingAvatar, string initiatingAnimationName, bool isReactionLooped) { }

	private void OnDestroy() { }

	private void OnInterruptOrEnd(TrackEntry trackEntry, LevelAnimal animal, ILevelAvatar initiatingAvatar) { }

	public void PlayAnimationOnClosestAnimal_DropAreaCA(string animationName) { }

	public void PlayAnimationOnClosestAnimal_ItemCA(string animationName) { }

	private void PlayAnimationOnRelevantAnimals(ReactionAnimationData reactionAnimationdata) { }

	private void ReturnToIdle(LevelAnimal animal) { }

	public void SearchForAnimalsToInvoke() { }

	public void set_reactionsData(LevelCAReactionsData value) { }

	public void SetCAHandlerBase(LevelCAHandlerBase levelCAHandler) { }

	public void SetCircleCenterLocalPosition(float x, float y) { }

	public void SetRadius(float radius) { }

	private bool ShouldFireEvents() { }

	private bool TryGetAnimalsInRadius(SpineType spineType, out List<LevelAnimal>& effectedAnimals) { }

	private bool TryGetAnimalsOnDropArea(LevelConsumerAreaBase dropArea, out List<LevelAnimal>& effectedAnimals) { }

	private bool TryGetClosestAnimal(SpineType spineType, out LevelAnimal effectedAnimal, float minDistance = 100000, float fromDistance = 0) { }

	private bool TryGetRandomAnimalInRadius(SpineType spineType, out LevelAnimal effectedAnimal) { }

}

