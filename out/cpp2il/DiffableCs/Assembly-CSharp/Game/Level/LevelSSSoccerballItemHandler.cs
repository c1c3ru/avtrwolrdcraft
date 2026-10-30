namespace Game.Level;

public class LevelSSSoccerballItemHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public bool isScore; //Field offset: 0x10
		public LevelSSSoccerballItemHandler <>4__this; //Field offset: 0x18
		public Vector2 source; //Field offset: 0x20
		public Vector2 destination; //Field offset: 0x28
		public float arcFactor; //Field offset: 0x30
		public TargetType targetType; //Field offset: 0x34
		public Vector2 scorePoint; //Field offset: 0x38
		public bool isRecursiveCall; //Field offset: 0x40
		public Vector2 lastPostition; //Field offset: 0x44
		public bool goalKeeperSave; //Field offset: 0x4C
		public LevelSSGoal goal; //Field offset: 0x50
		public Vector2 vector; //Field offset: 0x58
		public bool upperPost; //Field offset: 0x60

		public <>c__DisplayClass25_0() { }

		internal void <Shoot>b__0() { }

		internal void <Shoot>b__1(float t) { }

		internal void <Shoot>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public LevelSSSoccerballItemHandler <>4__this; //Field offset: 0x10
		public Transform parent; //Field offset: 0x18
		public bool didComplete; //Field offset: 0x20
		public float velocityY; //Field offset: 0x24
		public Vector2 position; //Field offset: 0x28
		public Vector2 fallDestination; //Field offset: 0x30
		public int tweenID; //Field offset: 0x38

		public <>c__DisplayClass26_0() { }

		internal void <ScoreInternal>b__0() { }

		internal void <ScoreInternal>b__1() { }

		internal void <ScoreInternal>b__2(float t) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public Vector2 position; //Field offset: 0x10
		public Vector2 source; //Field offset: 0x18
		public Vector2 destination; //Field offset: 0x20
		public LevelSSSoccerballItemHandler <>4__this; //Field offset: 0x28
		public float magnitude; //Field offset: 0x30
		public Vector2 toAdd; //Field offset: 0x34

		public <>c__DisplayClass28_0() { }

		internal void <MissInternal>b__0(float t) { }

		internal void <MissInternal>b__1() { }

	}

	[CompilerGenerated]
	private static Action<LevelSSSoccerballItemHandler, LevelSSGoal> OnScoreAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<LevelSSSoccerballItemHandler, LevelSSGoal> OnFailedToScoreAction; //Field offset: 0x8
	[SerializeField]
	private string _hitFloorSoundName; //Field offset: 0x20
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x28
	private Transform _sortingTransform; //Field offset: 0x30
	private SortingGroup _sortingTransformSortinGroup; //Field offset: 0x38
	private LevelItem _levelItem; //Field offset: 0x40
	private LevelCharacter _currentHolder; //Field offset: 0x48
	private AvatarHandType _characterHandType; //Field offset: 0x50
	private LevelCAItemOnBoneHandlerBase _caHandler; //Field offset: 0x58
	private bool _isOnCharacter; //Field offset: 0x60

	public static event Action<LevelSSSoccerballItemHandler, LevelSSGoal> OnFailedToScoreAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<LevelSSSoccerballItemHandler, LevelSSGoal> OnScoreAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelSSSoccerballItemHandler() { }

	[CompilerGenerated]
	private void <ShootFromCurrentHolder>b__24_0() { }

	[CompilerGenerated]
	public static void add_OnFailedToScoreAction(Action<LevelSSSoccerballItemHandler, LevelSSGoal> value) { }

	[CompilerGenerated]
	public static void add_OnScoreAction(Action<LevelSSSoccerballItemHandler, LevelSSGoal> value) { }

	private void Awake() { }

	private void ClearCurrentHolder() { }

	private void CreateSortingTransform() { }

	private void EnsureSortingTransform() { }

	private void MissInternal(Vector2 vector) { }

	private void OnCARemovedFromCharacter(LevelCAHandlerBase handler, ICATarget target) { }

	private void OnCharacterSpineEvent(Event spineEvent) { }

	private void OnDestroy() { }

	private void OnHolderBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	private void PlaySound(string soundName) { }

	[CompilerGenerated]
	public static void remove_OnFailedToScoreAction(Action<LevelSSSoccerballItemHandler, LevelSSGoal> value) { }

	[CompilerGenerated]
	public static void remove_OnScoreAction(Action<LevelSSSoccerballItemHandler, LevelSSGoal> value) { }

	private void ScoreInternal(LevelSSGoal goal, bool isAPowerfulShot) { }

	public void Shoot(LevelSSGoal goal, TargetType targetType, Vector2 sortingObjectPosition, bool isScore, float arcFactor, bool isRecursiveCall = false, bool goalKeeperShouldAttemptAnimation = true, bool goalKeeperShouldAttemptToStop = true) { }

	private void ShootFromCurrentHolder(TargetType targetType, bool isScore, bool goalKeeperShouldAttemptToStop = true) { }

}

