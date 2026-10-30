namespace PWC;

public class SpriteChangerForInventoryFlag : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__3 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public SpriteChangerForInventoryFlag <>4__this; //Field offset: 0x20

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
		public <Start>d__3(int <>1__state) { }

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
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private InventoryFlagType _requiredFlagType; //Field offset: 0x28
	[SerializeField]
	private Sprite _sprite; //Field offset: 0x30

	public SpriteChangerForInventoryFlag() { }

	[IteratorStateMachine(typeof(<Start>d__3))]
	private IEnumerator Start() { }

}

