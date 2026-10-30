namespace Unity.Services.Qos.Models;

[DataContract(Name = "QosServiceServersList")]
[Preserve]
internal class QosServiceServersList
{
	[CompilerGenerated]
	private readonly List<QosServiceServer> <Servers>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "servers", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public List<QosServiceServer> Servers
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public QosServiceServersList(List<QosServiceServer> servers) { }

	[CompilerGenerated]
	public List<QosServiceServer> get_Servers() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

