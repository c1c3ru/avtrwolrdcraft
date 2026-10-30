namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelJigglePartItemHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <UpdatePart>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelJigglePartItemHandler <>4__this; //Field offset: 0x20
		private Vector2 <lastPosition>5__2; //Field offset: 0x28
		private Vector2 <displacedPartPosition>5__3; //Field offset: 0x30
		private Vector2 <velocity>5__4; //Field offset: 0x38

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
		public <UpdatePart>d__8(int <>1__state) { }

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
	private Transform _part; //Field offset: 0x20
	private LevelItem _levelItem; //Field offset: 0x28
	private Vector2 _startingPartPosition; //Field offset: 0x30
	private Coroutine _stopCoroutine; //Field offset: 0x38

	public LevelJigglePartItemHandler() { }

	[CompilerGenerated]
	private void <OnItemEndDrag>b__7_0() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnItemBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnItemEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	[IteratorStateMachine(typeof(<UpdatePart>d__8))]
	private IEnumerator UpdatePart() { }

}

