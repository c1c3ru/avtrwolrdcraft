namespace UnityEngine.ResourceManagement.Profiling;

[DefaultMember("Item")]
internal class ProfilerFrameData
{
	[CompilerGenerated]
	private sealed class <Enumerate>d__17 : IEnumerable<KeyValuePair`2<T1, T2>>, IEnumerable, IEnumerator<KeyValuePair`2<T1, T2>>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private KeyValuePair<T1, T2> <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		public ProfilerFrameData<T1, T2> <>4__this; //Field offset: 0x0
		private Enumerator<T1, T2> <>7__wrap1; //Field offset: 0x0

		private override KeyValuePair<T1, T2> System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<T1,T2>>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 16
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 52
		}

		[DebuggerHidden]
		public <Enumerate>d__17(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<KeyValuePair`2<T1, T2>> System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<T1,T2>>.GetEnumerator() { }

		[DebuggerHidden]
		private override KeyValuePair<T1, T2> System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<T1,T2>>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private Dictionary<T1, T2> m_Data; //Field offset: 0x0
	private T2[] m_Array; //Field offset: 0x0
	private uint m_Version; //Field offset: 0x0
	private uint m_ArrayVersion; //Field offset: 0x0

	internal Dictionary<T1, T2> Data
	{
		internal get { } //Length: 8
	}

	public T2 Item
	{
		 get { } //Length: 200
		 set { } //Length: 384
	}

	public T2[] Values
	{
		 get { } //Length: 296
	}

	public ProfilerFrameData`2() { }

	public ProfilerFrameData`2(int count) { }

	public bool Add(T1 key, T2 value) { }

	public bool ContainsKey(T1 key) { }

	[IteratorStateMachine(typeof(<Enumerate>d__17))]
	public IEnumerable<KeyValuePair`2<T1, T2>> Enumerate() { }

	internal Dictionary<T1, T2> get_Data() { }

	public T2 get_Item(T1 key) { }

	public T2[] get_Values() { }

	internal bool Remove(T1 key) { }

	public void set_Item(T1 key, T2 value) { }

	public bool TryGetValue(T1 key, out T2 value) { }

}

