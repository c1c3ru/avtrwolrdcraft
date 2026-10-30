namespace Unity.Services.Qos.V2.Models;

[DataContract(Name = "QosServer")]
[Preserve]
public class QosServer
{
	[CompilerGenerated]
	private readonly List<String> <Endpoints>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly QosServerAnnotations <Annotations>k__BackingField; //Field offset: 0x18

	[DataMember(Name = "annotations", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public QosServerAnnotations Annotations
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "endpoints", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public List<String> Endpoints
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public QosServer(List<String> endpoints, QosServerAnnotations annotations) { }

	[CompilerGenerated]
	public QosServerAnnotations get_Annotations() { }

	[CompilerGenerated]
	public List<String> get_Endpoints() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

