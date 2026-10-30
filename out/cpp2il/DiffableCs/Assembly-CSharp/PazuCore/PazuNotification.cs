namespace PazuCore;

public class PazuNotification : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <WindowCloseAnim>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PazuNotification <>4__this; //Field offset: 0x20

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
		public <WindowCloseAnim>d__8(int <>1__state) { }

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
	private GameObject window; //Field offset: 0x20
	public Text massage; //Field offset: 0x28
	private Vector3 startScale; //Field offset: 0x30
	private Coroutine _autoCloseCoroutine; //Field offset: 0x40

	public PazuNotification() { }

	[CompilerGenerated]
	private bool <WindowCloseAnim>b__8_0() { }

	private void Awake() { }

	public void CloseWindow() { }

	private void OnEnable() { }

	[IteratorStateMachine(typeof(<WindowCloseAnim>d__8))]
	private IEnumerator WindowCloseAnim() { }

	private void WindowOpenAnim() { }

}

