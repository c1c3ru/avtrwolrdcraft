//Type is in global namespace

public class LevelLockPositionItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <FollowCoroutine>d__10 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelLockPositionItemHandler <>4__this; //Field offset: 0x20

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
		public <FollowCoroutine>d__10(int <>1__state) { }

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

	[SerializeField]
	private DragDropItemBase _draggableItem; //Field offset: 0x20
	[SerializeField]
	private bool _isHorizontalLocked; //Field offset: 0x28
	[SerializeField]
	private bool _isVerticalLocked; //Field offset: 0x29
	private Coroutine _coroutine; //Field offset: 0x30
	private Vector2 _startingPosition; //Field offset: 0x38

	public LevelLockPositionItemHandler() { }

	private void Awake() { }

	private void ChangePosition() { }

	[IteratorStateMachine(typeof(<FollowCoroutine>d__10))]
	private IEnumerator FollowCoroutine() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnBeginDragAction(DragDropItemBase arg1, PointerEventData arg2) { }

	private void OnDestroy() { }

	private void OnEndDragAction(DragDropItemBase arg1, PointerEventData arg2) { }

	private void OnPostInit() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

