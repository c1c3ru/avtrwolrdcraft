namespace Game.Level.ContextualAnimation;

public class LevelCALifeguardRescueWheelItemHandler : LevelCAItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public LevelCALifeguardRescueWheelItemHandler <>4__this; //Field offset: 0x10
		public LevelCharacter character; //Field offset: 0x18

		public <>c__DisplayClass10_0() { }

		internal void <OnAnimationBegin>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public PDPrefab instance; //Field offset: 0x10
		public LevelCharacter character; //Field offset: 0x18
		public LevelCALifeguardRescueWheelItemHandler <>4__this; //Field offset: 0x20
		public LevelItem levelItem; //Field offset: 0x28

		public <>c__DisplayClass12_0() { }

		internal void <TrowItem>b__0() { }

		internal void <TrowItem>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_1
	{
		public Vector2 startPos; //Field offset: 0x10
		public Vector2 endPos; //Field offset: 0x18
		public float height; //Field offset: 0x20
		public <>c__DisplayClass12_0 CS$<>8__locals1; //Field offset: 0x28

		public <>c__DisplayClass12_1() { }

		internal void <TrowItem>b__1(float val) { }

	}

	private const float GRAVITY = 20; //Field offset: 0x0
	private int _tweenID; //Field offset: 0x88
	private Vector3 _handOffset; //Field offset: 0x8C
	private readonly float _spinSpeed; //Field offset: 0x98
	private LevelItem _detachedItem; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCALifeguardRescueWheelItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void OnBeginDragDetachedItem(DragDropItemBase dragDropItem, PointerEventData pointerEventData) { }

	private void OnChildDropAreaItemEndDropDetachedItem(LevelDropArea dropArea, LevelItem levelItem) { }

	protected virtual void OnDestroy() { }

	private void OnPreSaveProgress(Scene scene) { }

	private void TrowItem(LevelCharacter character) { }

}

