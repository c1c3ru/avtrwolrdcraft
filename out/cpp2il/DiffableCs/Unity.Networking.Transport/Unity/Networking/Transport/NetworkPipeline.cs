namespace Unity.Networking.Transport;

public struct NetworkPipeline
{
	internal int Id; //Field offset: 0x0

	public static NetworkPipeline Null
	{
		 get { } //Length: 8
	}

	public virtual bool Equals(object compare) { }

	public bool Equals(NetworkPipeline connection) { }

	public static NetworkPipeline get_Null() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(NetworkPipeline lhs, NetworkPipeline rhs) { }

	public static bool op_Inequality(NetworkPipeline lhs, NetworkPipeline rhs) { }

}

