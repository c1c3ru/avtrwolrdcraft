namespace Game.Level;

[AddComponentMenu(null)]
public class LevelTimeBoard : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Animate>d__4 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTimeBoard <>4__this; //Field offset: 0x20

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
		public <Animate>d__4(int <>1__state) { }

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
	private SpriteRenderer _row; //Field offset: 0x20
	[SerializeField]
	private List<Sprite> _sprites; //Field offset: 0x28
	private int _counter; //Field offset: 0x30

	public LevelTimeBoard() { }

	[IteratorStateMachine(typeof(<Animate>d__4))]
	private IEnumerator Animate() { }

	private void Start() { }

}

