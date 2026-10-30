namespace System.IO.Compression;

internal sealed class DeflateInput
{
	[IsReadOnly]
	public struct InputState
	{
		internal readonly int _count; //Field offset: 0x0
		internal readonly int _startIndex; //Field offset: 0x4

		internal InputState(int count, int startIndex) { }

	}

	[CompilerGenerated]
	private Byte[] <Buffer>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private int <Count>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private int <StartIndex>k__BackingField; //Field offset: 0x1C

	internal Byte[] Buffer
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal int Count
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal int StartIndex
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public DeflateInput() { }

	internal void ConsumeBytes(int n) { }

	internal InputState DumpState() { }

	[CompilerGenerated]
	internal Byte[] get_Buffer() { }

	[CompilerGenerated]
	internal int get_Count() { }

	[CompilerGenerated]
	internal int get_StartIndex() { }

	internal void RestoreState(InputState state) { }

	[CompilerGenerated]
	internal void set_Buffer(Byte[] value) { }

	[CompilerGenerated]
	internal void set_Count(int value) { }

	[CompilerGenerated]
	internal void set_StartIndex(int value) { }

}

