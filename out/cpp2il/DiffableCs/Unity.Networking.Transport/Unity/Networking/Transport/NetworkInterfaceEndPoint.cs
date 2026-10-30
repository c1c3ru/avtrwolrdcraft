namespace Unity.Networking.Transport;

public struct NetworkInterfaceEndPoint : IEquatable<NetworkInterfaceEndPoint>
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <data>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	public const int k_MaxLength = 56; //Field offset: 0x0
	public int dataLength; //Field offset: 0x0
	[FixedBuffer(typeof(byte), 56)]
	public <data>e__FixedBuffer data; //Field offset: 0x4

	public bool IsValid
	{
		 get { } //Length: 16
	}

	public virtual bool Equals(object other) { }

	public override bool Equals(NetworkInterfaceEndPoint other) { }

	public bool get_IsValid() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(NetworkInterfaceEndPoint lhs, NetworkInterfaceEndPoint rhs) { }

	public static bool op_Inequality(NetworkInterfaceEndPoint lhs, NetworkInterfaceEndPoint rhs) { }

	public FixedString64Bytes ToFixedString() { }

	public virtual string ToString() { }

}

