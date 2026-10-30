namespace UnityWebSocketSharp;

internal class PayloadData : IEnumerable<Byte>, IEnumerable
{
	[CompilerGenerated]
	private sealed class <GetEnumerator>d__25 : IEnumerator<Byte>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private byte <>2__current; //Field offset: 0x14
		public PayloadData <>4__this; //Field offset: 0x18
		private Byte[] <>7__wrap1; //Field offset: 0x20
		private int <>7__wrap2; //Field offset: 0x28

		private override byte System.Collections.Generic.IEnumerator<System.Byte>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 92
		}

		[DebuggerHidden]
		public <GetEnumerator>d__25(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override byte System.Collections.Generic.IEnumerator<System.Byte>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	public static readonly PayloadData Empty; //Field offset: 0x0
	public static readonly ulong MaxLength; //Field offset: 0x8
	private Byte[] _data; //Field offset: 0x10
	private long _extDataLength; //Field offset: 0x18
	private long _length; //Field offset: 0x20

	public Byte[] ApplicationData
	{
		 get { } //Length: 160
	}

	internal ushort Code
	{
		internal get { } //Length: 156
	}

	public Byte[] ExtensionData
	{
		 get { } //Length: 192
	}

	internal long ExtensionDataLength
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	internal bool HasReservedCode
	{
		internal get { } //Length: 144
	}

	public ulong Length
	{
		 get { } //Length: 8
	}

	internal string Reason
	{
		internal get { } //Length: 196
	}

	private static PayloadData() { }

	internal PayloadData(Byte[] data) { }

	internal PayloadData(Byte[] data, long length) { }

	internal PayloadData(ushort code, string reason) { }

	public Byte[] get_ApplicationData() { }

	internal ushort get_Code() { }

	public Byte[] get_ExtensionData() { }

	internal long get_ExtensionDataLength() { }

	internal bool get_HasReservedCode() { }

	public ulong get_Length() { }

	internal string get_Reason() { }

	[IteratorStateMachine(typeof(<GetEnumerator>d__25))]
	public override IEnumerator<Byte> GetEnumerator() { }

	internal void Mask(Byte[] key) { }

	internal void set_ExtensionDataLength(long value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public Byte[] ToArray() { }

	public virtual string ToString() { }

}

