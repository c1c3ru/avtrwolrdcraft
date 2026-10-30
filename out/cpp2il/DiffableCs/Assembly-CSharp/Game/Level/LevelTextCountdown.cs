namespace Game.Level;

public class LevelTextCountdown : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <StartCountdown>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTextCountdown <>4__this; //Field offset: 0x20
		private int <counter>5__2; //Field offset: 0x28

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
		public <StartCountdown>d__8(int <>1__state) { }

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
	private int _maxValue; //Field offset: 0x20
	[SerializeField]
	private float _timeBetweenCounts; //Field offset: 0x24
	[SerializeField]
	private TextMesh _textMesh; //Field offset: 0x28
	[SerializeField]
	private string _soundName; //Field offset: 0x30
	private Coroutine _coroutine; //Field offset: 0x38

	public LevelTextCountdown() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void PerformRemoteClick() { }

	[IteratorStateMachine(typeof(<StartCountdown>d__8))]
	private IEnumerator StartCountdown() { }

	public void StopCountdown() { }

}

