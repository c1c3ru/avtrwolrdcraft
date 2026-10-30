namespace Unity.Services.Qos.Models;

[DataContract(Name = "QosServiceServer")]
[Preserve]
internal class QosServiceServer
{
	[CompilerGenerated]
	private readonly List<String> <Endpoints>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <Region>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly Dictionary<String, List`1<String>> <Annotations>k__BackingField; //Field offset: 0x20

	[DataMember(Name = "annotations", EmitDefaultValue = False)]
	[Preserve]
	public Dictionary<String, List`1<String>> Annotations
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

	[DataMember(Name = "region", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Region
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public QosServiceServer(List<String> endpoints, string region, Dictionary<String, List`1<String>> annotations = null) { }

	[CompilerGenerated]
	public Dictionary<String, List`1<String>> get_Annotations() { }

	[CompilerGenerated]
	public List<String> get_Endpoints() { }

	[CompilerGenerated]
	public string get_Region() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

