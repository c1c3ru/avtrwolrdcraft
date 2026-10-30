namespace Poly2Tri.Utility;

[DefaultMember("Item")]
public struct FixedArray3 : IEnumerable<T>, IEnumerable
{
	[CompilerGenerated]
	private sealed class <Enumerate>d__10 : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private T <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		public FixedArray3<T> <>4__this; //Field offset: 0x0
		public FixedArray3<T> <>3__<>4__this; //Field offset: 0x0
		private int <i>5__2; //Field offset: 0x0

		private override T System.Collections.Generic.IEnumerator<T>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 40
		}

		[DebuggerHidden]
		public <Enumerate>d__10(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

		[DebuggerHidden]
		private override T System.Collections.Generic.IEnumerator<T>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	public T Item0; //Field offset: 0x0
	public T Item1; //Field offset: 0x0
	public T Item2; //Field offset: 0x0

	public T Item
	{
		 get { } //Length: 100
		 set { } //Length: 104
	}

	public void Clear() { }

	public void Clear(T value) { }

	public bool Contains(T value) { }

	[IteratorStateMachine(typeof(<Enumerate>d__10))]
	private IEnumerable<T> Enumerate() { }

	public T get_Item(int index) { }

	public override IEnumerator<T> GetEnumerator() { }

	public int IndexOf(T value) { }

	public void set_Item(int index, T value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

