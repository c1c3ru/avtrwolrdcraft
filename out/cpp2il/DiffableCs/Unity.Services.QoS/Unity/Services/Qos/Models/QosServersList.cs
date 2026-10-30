namespace Unity.Services.Qos.Models;

[DataContract(Name = "QosServersList")]
[Preserve]
internal class QosServersList
{
	[CompilerGenerated]
	private readonly List<QosServer> <Servers>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "servers", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public List<QosServer> Servers
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public QosServersList(List<QosServer> servers) { }

	[CompilerGenerated]
	public List<QosServer> get_Servers() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

