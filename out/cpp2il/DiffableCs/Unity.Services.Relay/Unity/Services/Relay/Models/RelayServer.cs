namespace Unity.Services.Relay.Models;

[DataContract(Name = "RelayServer")]
[Preserve]
public class RelayServer
{
	[CompilerGenerated]
	private readonly string <IpV4>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly int <Port>k__BackingField; //Field offset: 0x18

	[DataMember(Name = "ipV4", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string IpV4
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

	[Preserve]
	public RelayServer(string ipV4, int port) { }

	[CompilerGenerated]
	public string get_IpV4() { }

	[CompilerGenerated]
	public int get_Port() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

