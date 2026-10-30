namespace PWC.Level.BasketballSystem;

public class LevelBSBasketballItemHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass39_0
	{
		public LevelBSBasketballItemHandler <>4__this; //Field offset: 0x10
		public LevelCharacter receiverCharacter; //Field offset: 0x18
		public Vector2 source; //Field offset: 0x20
		public Vector2 destination; //Field offset: 0x28
		public float arcFactor; //Field offset: 0x30

		public <>c__DisplayClass39_0() { }

		internal void <PassFromCurrentHolder>b__0() { }

		internal void <PassFromCurrentHolder>b__1(float t) { }

		internal void <PassFromCurrentHolder>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass41_0
	{
		public LevelBSBasketballItemHandler <>4__this; //Field offset: 0x10
		public Vector2 source; //Field offset: 0x18
		public Vector2 destination; //Field offset: 0x20
		public float arcFactor; //Field offset: 0x28
		public TargetType targetType; //Field offset: 0x2C
		public Vector2 scorePoint; //Field offset: 0x30
		public bool isRecursiveCall; //Field offset: 0x38
		public Vector2 lastPostition; //Field offset: 0x3C
		public bool isScore; //Field offset: 0x44
		public LevelBSHoop hoop; //Field offset: 0x48
		public Vector2 vector; //Field offset: 0x50

		public <>c__DisplayClass41_0() { }

		internal void <Shoot>b__0() { }

		internal void <Shoot>b__1(float t) { }

		internal void <Shoot>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass42_0
	{
		public LevelBSBasketballItemHandler <>4__this; //Field offset: 0x10
		public LevelBSHoop hoop; //Field offset: 0x18
		public Transform parent; //Field offset: 0x20
		public bool didComplete; //Field offset: 0x28
		public float velocityY; //Field offset: 0x2C
		public Vector2 position; //Field offset: 0x30
		public Vector2 fallDestination; //Field offset: 0x38
		public int tweenID; //Field offset: 0x40

		public <>c__DisplayClass42_0() { }

		internal void <ScoreInternal>b__0() { }

		internal void <ScoreInternal>b__1() { }

		internal void <ScoreInternal>b__2(float t) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass44_0
	{
		public Vector2 position; //Field offset: 0x10
		public Vector2 source; //Field offset: 0x18
		public Vector2 destination; //Field offset: 0x20
		public LevelBSBasketballItemHandler <>4__this; //Field offset: 0x28
		public float magnitude; //Field offset: 0x30
		public LevelBSHoop hoop; //Field offset: 0x38
		public Vector2 toAdd; //Field offset: 0x40

		public <>c__DisplayClass44_0() { }

		internal void <MissInternal>b__0(float t) { }

		internal void <MissInternal>b__1() { }

	}

	internal sealed class OverrideAnimationShootScoreChanceDelegate : MulticastDelegate
	{

		public OverrideAnimationShootScoreChanceDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(LevelBSBasketballItemHandler handelr, out float scoreChance, AsyncCallback callback, object object) { }

		public override bool EndInvoke(out float scoreChance, IAsyncResult result) { }

		public override bool Invoke(LevelBSBasketballItemHandler handelr, out float scoreChance) { }

	}

	[CompilerGenerated]
	private static Action<LevelBSBasketballItemHandler, LevelBSHoop> OnScoreAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<LevelBSBasketballItemHandler, LevelBSHoop> OnFailedToScoreAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<LevelBSBasketballItemHandler, LevelBSHoop> OnFailedToScoreAfterHitGroundAction; //Field offset: 0x10
	[SerializeField]
	private string _hitFloorSoundName; //Field offset: 0x20
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x28
	[SerializeField]
	private HoopType _hoopType; //Field offset: 0x30
	[SerializeField]
	private LevelCAHandlerBase _caHandler; //Field offset: 0x38
	[SerializeField]
	private List<String> _passingForwardAnimationNames; //Field offset: 0x40
	[SerializeField]
	private List<String> _passingBackwardAnimationNames; //Field offset: 0x48
	private bool _isPassing; //Field offset: 0x50
	private bool _isForwardPass; //Field offset: 0x51
	protected Transform _sortingTransform; //Field offset: 0x58
	private SortingGroup _sortingTransformSortinGroup; //Field offset: 0x60
	protected LevelItem _levelItem; //Field offset: 0x68
	private LevelCharacter _currentHolder; //Field offset: 0x70
	private AvatarHandType _characterHandType; //Field offset: 0x78
	private Random _random; //Field offset: 0x80
	[CompilerGenerated]
	private OverrideAnimationShootScoreChanceDelegate OverrideAnimationShootScoreChanceAction; //Field offset: 0x88

	public static event Action<LevelBSBasketballItemHandler, LevelBSHoop> OnFailedToScoreAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<LevelBSBasketballItemHandler, LevelBSHoop> OnFailedToScoreAfterHitGroundAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<LevelBSBasketballItemHandler, LevelBSHoop> OnScoreAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public event OverrideAnimationShootScoreChanceDelegate OverrideAnimationShootScoreChanceAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public LevelBSBasketballItemHandler() { }

	[CompilerGenerated]
	private void <SetupSortingForThrow>b__38_0() { }

	[CompilerGenerated]
	public static void add_OnFailedToScoreAction(Action<LevelBSBasketballItemHandler, LevelBSHoop> value) { }

	[CompilerGenerated]
	public static void add_OnFailedToScoreAfterHitGroundAction(Action<LevelBSBasketballItemHandler, LevelBSHoop> value) { }

	[CompilerGenerated]
	public static void add_OnScoreAction(Action<LevelBSBasketballItemHandler, LevelBSHoop> value) { }

	[CompilerGenerated]
	public void add_OverrideAnimationShootScoreChanceAction(OverrideAnimationShootScoreChanceDelegate value) { }

	private void Awake() { }

	private void ClearCurrentHolder() { }

	private void CreateSortingTransform() { }

	private void EnsureSortingTransform() { }

	protected override void MissInternal(Vector2 vector, LevelBSHoop hoop) { }

	private void OnCAHandlerAnimationBegin(LevelCAHandlerBase caHandler, ICATarget caTarget, LevelCAConfig caConfig) { }

	private void OnCharacterSpineEvent(Event spineEvent) { }

	private void OnDestroy() { }

	private void OnHolderBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	private void OnRemvoedFromCharacter(ILevelAvatar avatar) { }

	private void PassFromCurrentHolder() { }

	private void PassFromCurrentHolder(ILevelAvatar receiver) { }

	private void PlaySound(string soundName) { }

	[CompilerGenerated]
	public static void remove_OnFailedToScoreAction(Action<LevelBSBasketballItemHandler, LevelBSHoop> value) { }

	[CompilerGenerated]
	public static void remove_OnFailedToScoreAfterHitGroundAction(Action<LevelBSBasketballItemHandler, LevelBSHoop> value) { }

	[CompilerGenerated]
	public static void remove_OnScoreAction(Action<LevelBSBasketballItemHandler, LevelBSHoop> value) { }

	[CompilerGenerated]
	public void remove_OverrideAnimationShootScoreChanceAction(OverrideAnimationShootScoreChanceDelegate value) { }

	protected override void ScoreInternal(LevelBSHoop hoop) { }

	private Vector2 SetupSortingForThrow() { }

	public void Shoot(LevelBSHoop hoop, TargetType targetType, Vector2 sortingObjectPosition, bool isScore, float arcFactor, bool isRecursiveCall = false) { }

	private void ShootFromCurrentHolder(TargetType targetType, bool isScore) { }

}

