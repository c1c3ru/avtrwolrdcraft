namespace Unity.Services.Qos.V2.Models;

[DataContract(Name = "QosServersResponseBody")]
[Preserve]
internal class QosServersResponseBody
{
	[CompilerGenerated]
	private readonly QosServersList <Data>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "data", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public QosServersList Data
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public QosServersResponseBody(QosServersList data) { }

	[CompilerGenerated]
	public QosServersList get_Data() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

