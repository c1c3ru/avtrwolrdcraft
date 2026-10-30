namespace PWC.Level;

public class LevelSoundOnDragItemHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <PlaySoundWithIntervals>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelSoundOnDragItemHandler <>4__this; //Field offset: 0x20
		private WaitForSeconds <wait>5__2; //Field offset: 0x28

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
		public <PlaySoundWithIntervals>d__13(int <>1__state) { }

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
	private GameSoundPlayer _soundPlayer; //Field offset: 0x20
	[SerializeField]
	private string _soundName; //Field offset: 0x28
	[SerializeField]
	private bool _loop; //Field offset: 0x30
	[ConditionalField("_loop", False, True, (array) null)]
	[SerializeField]
	private float _interval; //Field offset: 0x34
	[ConditionalField("_loop", False, True, (array) null)]
	[SerializeField]
	private float _firstInterval; //Field offset: 0x38
	private LevelItem _levelItem; //Field offset: 0x40
	private Coroutine _soundIntervalsCoroutine; //Field offset: 0x48

	public LevelSoundOnDragItemHandler() { }

	private void Awake() { }

	private void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnDestroy() { }

	private void OnEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	[IteratorStateMachine(typeof(<PlaySoundWithIntervals>d__13))]
	private IEnumerator PlaySoundWithIntervals() { }

	public void StartSound() { }

	public void StopSound() { }

}

