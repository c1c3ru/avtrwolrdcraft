namespace Game.Level;

public class LevelSticklightItemHandler : LevelDragActionItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public LevelSticklightItemHandler <>4__this; //Field offset: 0x10
		public Vector2 source; //Field offset: 0x18
		public Vector2 destination; //Field offset: 0x20
		public float arcFactor; //Field offset: 0x28
		public Vector2 lastPostition; //Field offset: 0x2C
		public Vector2 vector; //Field offset: 0x34

		public <>c__DisplayClass21_0() { }

		internal void <Throw>b__0() { }

		internal void <Throw>b__1(float t) { }

		internal void <Throw>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public Vector2 position; //Field offset: 0x10
		public Vector2 source; //Field offset: 0x18
		public Vector2 destination; //Field offset: 0x20
		public LevelSticklightItemHandler <>4__this; //Field offset: 0x28
		public float magnitude; //Field offset: 0x30
		public Vector2 toAdd; //Field offset: 0x34

		public <>c__DisplayClass22_0() { }

		internal void <MissInternal>b__0(float t) { }

		internal void <MissInternal>b__1() { }

	}

	[SerializeField]
	private GameObject _haloObject; //Field offset: 0xA0
	[SerializeField]
	private GameObject _maskObject; //Field offset: 0xA8
	private Transform _sortingTransform; //Field offset: 0xB0
	private SortingGroup _sortingTransformSortinGroup; //Field offset: 0xB8
	private ILevelAvatar _currentHolder; //Field offset: 0xC0
	private AvatarHandType _avatarHandType; //Field offset: 0xC8
	private bool _isOnCharacter; //Field offset: 0xCC
	private Vector2 _throwDestination; //Field offset: 0xD0
	private Vector3 _maskStartingScale; //Field offset: 0xD8

	public Vector2 ThrowDestination
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelSticklightItemHandler() { }

	[CompilerGenerated]
	private void <ThrowFromHand>b__20_0() { }

	protected virtual void Awake() { }

	private void ClearCurrentHolder() { }

	private void CreateSortingTransform() { }

	private void EnsureSortingTransform() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	public Vector2 get_ThrowDestination() { }

	private void MaskFollowSticklight(DragDropItemBase item, Vector2 pointerPosition) { }

	private void MissInternal(Vector2 vector) { }

	protected virtual void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnCharacterSpineEvent(Event spineEvent) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnHolderBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	public void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	protected virtual void OnTargetEnter(ILevelConsumer target) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

	public void set_ThrowDestination(Vector2 value) { }

	public void Throw(Vector2 sortingObjectPosition, float arcFactor) { }

	private void ThrowFromHand() { }

}

