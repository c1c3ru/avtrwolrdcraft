namespace Unity.Services.Relay.Models;

[DataContract(Name = "RelayServerEndpoint")]
[Preserve]
public class RelayServerEndpoint
{
	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	internal enum NetworkOptions
	{
		Udp = 1,
		Tcp = 2,
	}

	[CompilerGenerated]
	private readonly string <ConnectionType>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly NetworkOptions <Network>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly bool <Reliable>k__BackingField; //Field offset: 0x1C
	[CompilerGenerated]
	private readonly bool <Secure>k__BackingField; //Field offset: 0x1D
	[CompilerGenerated]
	private readonly string <Host>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly int <Port>k__BackingField; //Field offset: 0x28

	[DataMember(Name = "connectionType", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string ConnectionType
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "host", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Host
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "network", IsRequired = True, EmitDefaultValue = True)]
	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	public NetworkOptions Network
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "port", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public int Port
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "reliable", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public bool Reliable
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "secure", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public bool Secure
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public RelayServerEndpoint(string connectionType, NetworkOptions network, bool reliable, bool secure, string host, int port) { }

	[CompilerGenerated]
	public string get_ConnectionType() { }

	[CompilerGenerated]
	public string get_Host() { }

	[CompilerGenerated]
	public NetworkOptions get_Network() { }

	[CompilerGenerated]
	public int get_Port() { }

	[CompilerGenerated]
	public bool get_Reliable() { }

	[CompilerGenerated]
	public bool get_Secure() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

