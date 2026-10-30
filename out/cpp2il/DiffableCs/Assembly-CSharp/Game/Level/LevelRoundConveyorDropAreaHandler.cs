namespace Game.Level;

public class LevelRoundConveyorDropAreaHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public Nullable<Vector2> duplicatePoint; //Field offset: 0x10
		public LevelRoundConveyorDropAreaHandler <>4__this; //Field offset: 0x20

		public <>c__DisplayClass13_0() { }

		internal bool <Awake>b__0(Vector2 p) { }

		internal float <Awake>b__1(Vector2 p) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_1
	{
		public Vector2 point; //Field offset: 0x10

		public <>c__DisplayClass13_1() { }

		internal bool <Awake>b__2(Vector2 p) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public LevelItem levelItem; //Field offset: 0x10
		public LevelRoundConveyorDropAreaHandler <>4__this; //Field offset: 0x18
		public List<Vector2> animationPoints; //Field offset: 0x20

		public <>c__DisplayClass18_0() { }

		internal void <MoveItems>g__OnEndLand|0(LevelDropArea levelDropArea) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public LevelRoundConveyorDropAreaHandler <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18
		public Func<Boolean> <>9__1; //Field offset: 0x20
		public Action <>9__2; //Field offset: 0x28

		public <>c__DisplayClass19_0() { }

		internal void <OnLevelItemClick>b__0() { }

		internal bool <OnLevelItemClick>b__1() { }

		internal void <OnLevelItemClick>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public LevelCharacter <character>5__2; //Field offset: 0x10

		public <>c__DisplayClass21_0() { }

		internal void <StartMoveAnimation>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <SyncWaterDeep>d__22 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelWaterAreaItemHandler handler; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <SyncWaterDeep>d__22(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private class ConveyorAnimationParams
	{
		public LevelItem AnimationItem; //Field offset: 0x10
		public List<Vector2> AnimationPoints; //Field offset: 0x18
		public int Index; //Field offset: 0x20
		public bool FirstCall; //Field offset: 0x24

		public ConveyorAnimationParams() { }

	}

	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x28
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x30
	[SerializeField]
	protected string _conveyorMovmentSoundName; //Field offset: 0x38
	[SerializeField]
	protected Vector2 _centerPoint; //Field offset: 0x40
	[SerializeField]
	private float _speed; //Field offset: 0x48
	[SerializeField]
	private bool _moveClockwize; //Field offset: 0x4C
	[SerializeField]
	private int _bottomLayerOrder; //Field offset: 0x50
	[SerializeField]
	private int _topLayerOrder; //Field offset: 0x54
	private List<Vector2> _conveyorAnimationPoints; //Field offset: 0x58
	private readonly Dictionary<LevelItem, Int32> _tweenIDs; //Field offset: 0x60
	private readonly Dictionary<LevelItem, Coroutine> _syncWaterItems; //Field offset: 0x68

	public LevelRoundConveyorDropAreaHandler() { }

	private void Awake() { }

	private void CancelMovement(LevelItem levelItem) { }

	private int GetNextPointIndexOnConveyor(Vector3 position) { }

	private void MoveItems(LevelItem levelItem, bool needEndLand) { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelItemClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	private void OnLevelPostInit() { }

	private void SortAllItems() { }

	private void StartMoveAnimation(object completeParams) { }

	[IteratorStateMachine(typeof(<SyncWaterDeep>d__22))]
	private IEnumerator SyncWaterDeep(LevelWaterAreaItemHandler handler) { }

}

