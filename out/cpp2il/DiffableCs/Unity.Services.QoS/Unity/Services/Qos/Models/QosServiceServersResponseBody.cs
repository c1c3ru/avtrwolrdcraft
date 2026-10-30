namespace Unity.Services.Qos.Models;

[DataContract(Name = "QosServiceServersResponseBody")]
[Preserve]
internal class QosServiceServersResponseBody
{
	[CompilerGenerated]
	private readonly QosServiceServersList <Data>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "data", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public QosServiceServersList Data
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public QosServiceServersResponseBody(QosServiceServersList data) { }

	[CompilerGenerated]
	public QosServiceServersList get_Data() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

