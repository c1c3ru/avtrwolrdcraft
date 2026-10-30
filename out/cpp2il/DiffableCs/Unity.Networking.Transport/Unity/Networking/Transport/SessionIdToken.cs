namespace Unity.Networking.Transport;

internal struct SessionIdToken : IEquatable<SessionIdToken>, IComparable<SessionIdToken>
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <Value>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	public const int k_Length = 8; //Field offset: 0x0
	[FixedBuffer(typeof(byte), 8)]
	public <Value>e__FixedBuffer Value; //Field offset: 0x0

	private int Compare(SessionIdToken other) { }

	public override int CompareTo(SessionIdToken other) { }

	public override bool Equals(SessionIdToken other) { }

	public virtual bool Equals(object other) { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(SessionIdToken lhs, SessionIdToken rhs) { }

	public static bool op_Inequality(SessionIdToken lhs, SessionIdToken rhs) { }

}

