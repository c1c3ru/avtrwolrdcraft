namespace Unity.Networking.Transport;

public struct NetworkConnection : IEquatable<NetworkConnection>
{
	internal enum State
	{
		Disconnected = 0,
		Connecting = 1,
		Connected = 2,
	}

	internal int m_NetworkId; //Field offset: 0x0
	internal int m_NetworkVersion; //Field offset: 0x4

	public int InternalId
	{
		 get { } //Length: 8
	}

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public int Close(NetworkDriver driver) { }

	public int Disconnect(NetworkDriver driver) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(NetworkConnection o) { }

	public int get_InternalId() { }

	public bool get_IsCreated() { }

	public virtual int GetHashCode() { }

	public State GetState(NetworkDriver driver) { }

	public static bool op_Equality(NetworkConnection lhs, NetworkConnection rhs) { }

	public static bool op_Inequality(NetworkConnection lhs, NetworkConnection rhs) { }

	public Type PopEvent(NetworkDriver driver, out DataStreamReader stream) { }

	public Type PopEvent(NetworkDriver driver, out DataStreamReader stream, out NetworkPipeline pipeline) { }

}

