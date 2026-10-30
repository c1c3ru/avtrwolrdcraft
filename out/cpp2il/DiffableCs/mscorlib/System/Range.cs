namespace System;

[IsReadOnly]
public struct Range : IEquatable<Range>
{
	[CompilerGenerated]
	private readonly Index <Start>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private readonly Index <End>k__BackingField; //Field offset: 0x4

	public Index End
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public Index Start
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public Range(Index start, Index end) { }

	public virtual bool Equals(object value) { }

	public override bool Equals(Range other) { }

	[CompilerGenerated]
	public Index get_End() { }

	[CompilerGenerated]
	public Index get_Start() { }

	public virtual int GetHashCode() { }

	public ValueTuple<Int32, Int32> GetOffsetAndLength(int length) { }

	public static Range StartAt(Index start) { }

	public virtual string ToString() { }

}

