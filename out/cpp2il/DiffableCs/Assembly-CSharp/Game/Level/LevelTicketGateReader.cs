namespace Game.Level;

[AddComponentMenu(null)]
public class LevelTicketGateReader : LevelConsumerAreaBase
{
	[CompilerGenerated]
	private sealed class <WaitAndClose>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTicketGateReader <>4__this; //Field offset: 0x20

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
		public <WaitAndClose>d__5(int <>1__state) { }

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
	private SpriteRenderer _spriteRenderer; //Field offset: 0x58
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x60
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x68
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x70

	public LevelTicketGateReader() { }

	public void Open() { }

	[IteratorStateMachine(typeof(<WaitAndClose>d__5))]
	private IEnumerator WaitAndClose() { }

}

