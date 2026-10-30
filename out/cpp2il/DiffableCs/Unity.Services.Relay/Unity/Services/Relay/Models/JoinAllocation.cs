namespace Unity.Services.Relay.Models;

[DataContract(Name = "JoinAllocation")]
[Preserve]
public class JoinAllocation
{
	[CompilerGenerated]
	private readonly Guid <AllocationId>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly List<RelayServerEndpoint> <ServerEndpoints>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly RelayServer <RelayServer>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly Byte[] <Key>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private readonly Byte[] <ConnectionData>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private readonly Byte[] <AllocationIdBytes>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private readonly string <Region>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private readonly Byte[] <HostConnectionData>k__BackingField; //Field offset: 0x50

	[DataMember(Name = "allocationId", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public Guid AllocationId
	{
		[CompilerGenerated]
		 get { } //Length: 12
	}

	[DataMember(Name = "allocationIdBytes", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public Byte[] AllocationIdBytes
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "connectionData", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public Byte[] ConnectionData
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "hostConnectionData", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public Byte[] HostConnectionData
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "key", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public Byte[] Key
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "region", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Region
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "relayServer", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public RelayServer RelayServer
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "serverEndpoints", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public List<RelayServerEndpoint> ServerEndpoints
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public JoinAllocation(Guid allocationId, List<RelayServerEndpoint> serverEndpoints, RelayServer relayServer, Byte[] key, Byte[] connectionData, Byte[] allocationIdBytes, string region, Byte[] hostConnectionData) { }

	[CompilerGenerated]
	public Guid get_AllocationId() { }

	[CompilerGenerated]
	public Byte[] get_AllocationIdBytes() { }

	[CompilerGenerated]
	public Byte[] get_ConnectionData() { }

	[CompilerGenerated]
	public Byte[] get_HostConnectionData() { }

	[CompilerGenerated]
	public Byte[] get_Key() { }

	[CompilerGenerated]
	public string get_Region() { }

	[CompilerGenerated]
	public RelayServer get_RelayServer() { }

	[CompilerGenerated]
	public List<RelayServerEndpoint> get_ServerEndpoints() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

